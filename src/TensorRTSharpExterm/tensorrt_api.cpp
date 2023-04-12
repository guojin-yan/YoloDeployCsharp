#include "tensorrt_api.h"
#include "common.h"

// @brief 将本地onnx模型转为tensorrt中的engine格式，并保存到本地
// @param onnx_file_path_wchar onnx模型本地地址
// @param engine_file_path_wchar engine模型本地地址
// @param type 输出模型精度，
void  onnx_to_engine(const wchar_t* onnx_file_path_wchar, const wchar_t* engine_file_path_wchar, int type) {
	std::string onnx_file_path = wchar_to_string(onnx_file_path_wchar);
	std::string engine_file_path = wchar_to_string(engine_file_path_wchar);

	// 构建器，获取cuda内核目录以获取最快的实现
	// 用于创建config、network、engine的其他对象的核心类
	nvinfer1::IBuilder* builder = nvinfer1::createInferBuilder(gLogger);
	// 定义网络属性
	const auto explicit_batch = 1U << static_cast<uint32_t>(nvinfer1::NetworkDefinitionCreationFlag::kEXPLICIT_BATCH);
	// 解析onnx网络文件
	// tensorRT模型类
	nvinfer1::INetworkDefinition* network = builder->createNetworkV2(explicit_batch);
	// onnx文件解析类
	// 将onnx文件解析，并填充rensorRT网络结构
	nvonnxparser::IParser* parser = nvonnxparser::createParser(*network, gLogger);
	// 解析onnx文件
	parser->parseFromFile(onnx_file_path.c_str(), 2);
	for (int i = 0; i < parser->getNbErrors(); ++i) {
		std::cout << "load error: " << parser->getError(i)->desc() << std::endl;
	}
	printf("tensorRT load mask onnx model successfully!!!...\n");

	// 创建推理引擎
	// 创建生成器配置对象。
	nvinfer1::IBuilderConfig* config = builder->createBuilderConfig();
	// 设置最大工作空间大小。
	config->setMaxWorkspaceSize(16 * (1 << 20));
	// 设置模型输出精度
	if (type == 1) {
		config->setFlag(nvinfer1::BuilderFlag::kFP16);
	}
	if (type == 2) {
		config->setFlag(nvinfer1::BuilderFlag::kINT8);
	}
	// 创建推理引擎
	nvinfer1::ICudaEngine* engine = builder->buildEngineWithConfig(*network, *config);
	// 将推理银枪保存到本地
	std::cout << "try to save engine file now~~~" << std::endl;
	std::ofstream file_ptr(engine_file_path, std::ios::binary);
	if (!file_ptr) {
		std::cerr << "could not open plan output file" << std::endl;
		return;
	}
	// 将模型转化为文件流数据
	nvinfer1::IHostMemory* model_stream = engine->serialize();
	// 将文件保存到本地
	file_ptr.write(reinterpret_cast<const char*>(model_stream->data()), model_stream->size());
	// 销毁创建的对象
	model_stream->destroy();
	engine->destroy();
	network->destroy();
	parser->destroy();
	std::cout << "convert onnx model to TensorRT engine model successfully!" << std::endl;
}


// @brief 读取本地engine模型，并初始化NvinferStruct
// @param engine_filename_wchar engine本地模型地址
// @param num_ionode 显存缓冲区数量
// @return NvinferStruct结构体指针
void* nvinfer_init(const wchar_t* engine_filename_wchar) {
	// 读取本地模型文件
	std::string engine_filename = wchar_to_string(engine_filename_wchar);
	// 以二进制方式读取问价
	std::ifstream file_ptr(engine_filename, std::ios::binary);
	if (!file_ptr.good()) {
		std::cerr << "文件无法打开，请确定文件是否可用！" << std::endl;
	}

	size_t size = 0;
	file_ptr.seekg(0, file_ptr.end);	// 将读指针从文件末尾开始移动0个字节
	size = file_ptr.tellg();	// 返回读指针的位置，此时读指针的位置就是文件的字节数
	file_ptr.seekg(0, file_ptr.beg);	// 将读指针从文件开头开始移动0个字节
	char* model_stream = new char[size];
	file_ptr.read(model_stream, size);
	// 关闭文件
	file_ptr.close();

	// 创建推理核心结构体，初始化变量
	NvinferStruct* p = new NvinferStruct();
	// 初始化反序列化引擎
	p->runtime = nvinfer1::createInferRuntime(gLogger);
	// 初始化推理引擎
	p->engine = p->runtime->deserializeCudaEngine(model_stream, size);
	// 创建上下文
	p->context = p->engine->createExecutionContext();
	int num_ionode = p->engine->getNbBindings();
	// 创建gpu数据缓冲区
	p->data_buffer = new void* [num_ionode];
	delete[] model_stream;
	return (void*)p;
}

// @brief 创建GPU显存输入/输出缓冲区
// @param nvinfer_ptr NvinferStruct结构体指针
// @para node_name_wchar 网络节点名称
// @param data_length 缓冲区数据长度
// @return NvinferStruct结构体指针
void* creat_gpu_buffer(void* nvinfer_ptr) {
	// 重构NvinferStruct
	NvinferStruct* p = (NvinferStruct*)nvinfer_ptr;
	int num_ionode = p->engine->getNbBindings();
	for (int i = 0; i < num_ionode; i++) {
		nvinfer1::Dims shape_d = p->engine->getBindingDimensions(i);
		std::vector<int> shape(shape_d.d, shape_d.d + shape_d.nbDims);
		size_t size = std::accumulate(shape.begin(), shape.end(), 1, std::multiplies<int>());
		cudaMalloc(&(p->data_buffer[i]), size * sizeof(float));
	}
	return (void*)p;
}

// @brief 加载图片输入数据到缓冲区
// @param nvinfer_ptr NvinferStruct结构体指针
// @para node_name_wchar 网络节点名称
// @param image_data 图片矩阵数据
// @param image_size 图片数据长度
// @return NvinferStruct结构体指针
void* load_image_data(void* nvinfer_ptr,
	const wchar_t* node_name_wchar, uchar * image_data, size_t image_size, int BN_means) {
	// 重构NvinferStruct
	NvinferStruct* p = (NvinferStruct*)nvinfer_ptr;

	// 获取输入节点信息
	const char* node_name = wchar_to_char(node_name_wchar);
	int node_index = p->engine->getBindingIndex(node_name);
	// 获取输入节点未读信息
	nvinfer1::Dims node_dim = p->engine->getBindingDimensions(node_index);
	int node_shape_w = node_dim.d[2];
	int node_shape_h = node_dim.d[3];
	// 输入节点二维形状
	cv::Size node_shape(node_shape_w, node_shape_h);
	// 输入节点二维大小
	size_t node_data_length = node_shape_w * node_shape_h;

	// 预处理输入数据
	cv::Mat input_image = data_to_mat(image_data, image_size);
	cv::Mat BN_image;
	if (BN_means == 0) {
		cv::cvtColor(input_image, input_image, cv::COLOR_BGR2RGB); // 将图片通道由 BGR 转为 RGB
		// 对输入图片按照tensor输入要求进行缩放
		cv::resize(input_image, BN_image, node_shape, 0, 0, cv::INTER_LINEAR);
		// 图像数据归一化
		std::vector<cv::Mat> rgb_channels(3);
		cv::split(BN_image, rgb_channels); // 分离图片数据通道
		// PaddleDetection模型使用imagenet数据集的均值 Mean = [0.485, 0.456, 0.406]和方差 std = [0.229, 0.224, 0.225]
		std::vector<float> mean_values{ 0.485 * 255, 0.456 * 255, 0.406 * 255 };
		std::vector<float> std_values{ 0.229 * 255, 0.224 * 255, 0.225 * 255 };
		for (auto i = 0; i < rgb_channels.size(); i++) {
			//分通道依此对每一个通道数据进行归一化处理
			rgb_channels[i].convertTo(rgb_channels[i], CV_32FC1, 1.0 / std_values[i], (0.0 - mean_values[i]) / std_values[i]);
		}
		cv::merge(rgb_channels, BN_image);
		std::vector<cv::Mat>().swap(rgb_channels);
	}
	else if (BN_means == 1) {
		// 将图像归一化，并放缩到指定大小
		BN_image = cv::dnn::blobFromImage(input_image, 1 / 255.0, node_shape, cv::Scalar(0, 0, 0), true, false);

	}


	// 创建cuda流
	cudaStreamCreate(&p->stream);
	std::vector<float> input_data(node_data_length * 3);
	// 将图片数据copy到输入流中
	memcpy(input_data.data(), BN_image.ptr<float>(), node_data_length * 3 * sizeof(float));

	// 将输入数据由内存到GPU显存
	cudaMemcpyAsync(p->data_buffer[node_index], input_data.data(), node_data_length * 3 * sizeof(float), cudaMemcpyHostToDevice, p->stream);

	std::vector<float>().swap(input_data);
	input_image.release();
	BN_image.release();
	return (void*)p;
}


// @brief 模型推理
// @param nvinfer_ptr NvinferStruct结构体指针
// @return NvinferStruct结构体指针
extern "C"  __declspec(dllexport) void* __stdcall infer(void* nvinfer_ptr) {
	NvinferStruct* p = (NvinferStruct*)nvinfer_ptr;
	// 模型推理
	p->context->enqueueV2(p->data_buffer, p->stream, nullptr);
	return (void*)p;
}


// @brief 读取推理数据
// @param nvinfer_ptr NvinferStruct结构体指针
// @para node_name_wchar 网络节点名称
// @param output_result 输出数据指针
extern "C"  __declspec(dllexport) void __stdcall read_infer_result(void* nvinfer_ptr,
	const wchar_t* node_name_wchar, float* output_result) {
	// 重构NvinferStruct
	NvinferStruct* p = (NvinferStruct*)nvinfer_ptr;

	// 获取输出节点信息
	const char* node_name = wchar_to_char(node_name_wchar);
	int node_index = p->engine->getBindingIndex(node_name);
	// 读取输出数据
	nvinfer1::Dims shape_d = p->engine->getBindingDimensions(node_index);
	std::vector<int> shape(shape_d.d, shape_d.d + shape_d.nbDims);
	size_t size = std::accumulate(shape.begin(), shape.end(), 1, std::multiplies<int>());
	// 创建输出数据
	std::vector<float> output_data(size);
	// 将输出数据由GPU显存到内存
	cudaMemcpyAsync(output_data.data(), p->data_buffer[node_index], size * sizeof(float), cudaMemcpyDeviceToHost, p->stream);

	for (int i = 0; i < size; i++) {
		*output_result = output_data[i];
		output_result++;
	}
	// 清空数据
	std::vector<float>().swap(output_data);
}

// @brief 删除内存地址
// @param nvinfer_ptr NvinferStruct结构体指针
extern "C"  __declspec(dllexport) void __stdcall nvinfer_delete(void* nvinfer_ptr) {
	NvinferStruct* p = (NvinferStruct*)nvinfer_ptr;

	delete p->data_buffer;
	p->context->destroy();
	p->engine->destroy();
	p->runtime->destroy();
	delete p;
}