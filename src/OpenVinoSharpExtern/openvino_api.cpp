// OpenVINO C++ dll code for C#
// 该项目支持模型格式：
//   1. paddlepaddle飞桨模型(.pdmodel)
//   2. onnx中间格式(.onnx)
//   3. OpenVINO的IR格式(.xml)
// 针对该项目所使用测试网络：
//   1. PaddleClas 图像分类模型 花卉种类识别网络的(.pdmodel)、(.onnx)、(.xml)格式；
//   2. Paddledetection 目标检测模型 车辆识别网络的(.pdmodel)格式；
// ONLY support batchsize = 1


#include"openvino_api.h"





// @brief 初始化openvino核心结构体，读取本地推理模型，将模型加载到设备，并创建推理请求
// @note 可支持的推理模型的格式为：(.pdmodel)、(.onnx)、(.xml)格式
// @note 可支持设备选择（AUTO）自动选择、（CPU）处理器、（GPU）显卡
// @param w_model_dir 推理模型本地地址
// @param w_device 加载设备名称
// @param w_cache_dir 缓存路径
// @param return_ptr CoreStruct指针
// @return 异常标志
void* core_init(const wchar_t* w_model_dir, const wchar_t* w_device,
    const wchar_t* w_cache_dir){
    //读取接口输入参数
    std::string model_dir = wchar_to_string(w_model_dir);// 推理模型本地地址
    std::string device = wchar_to_string(w_device);// 加载设备名称
    std::string cache_dir = wchar_to_string(w_cache_dir); // 缓存地址
    // 初始化推理核心
    CoreStruct* openvino_core = new CoreStruct(); // 创建推理引擎指针
    openvino_core->model_ptr = openvino_core->core.read_model(model_dir); // 读取推理模型
    if (cache_dir != "") {
        openvino_core->core.set_property(ov::cache_dir(cache_dir)); // 设置缓存路径
    }
    openvino_core->compiled_model = openvino_core->core.compile_model(openvino_core->model_ptr, device); // 将模型加载到设备
    openvino_core->infer_request = openvino_core->compiled_model.create_infer_request(); // 创建推理请求
    return (void*)openvino_core;
}


// @brief 为输入tensor设置新形状，如果新的总大小大于前一个，则取消之前的设置
// @param core_ptr 推理核心指针
// @param w_node_name 输入节点名
// @param input_shape 输入形状数据数组
// @param input_size 输入数组大小
// @param return_ptr CoreStruct指针
// @return 异常标志
void* set_input_sharp(void* core_ptr, const wchar_t* w_node_name, size_t* input_shape,
    int input_size) {
    // 读取推理模型地址
    CoreStruct* openvino_core = (CoreStruct*)core_ptr;
    std::string node_name = wchar_to_string(w_node_name);
    // 获取指定节点的tensor
    ov::Tensor tensor = openvino_core->infer_request.get_tensor(node_name);
    ov::Shape shape(input_shape, input_shape + input_size);
    // 设置节点输入数据的形状
    tensor.set_shape(shape);
    return (void*)openvino_core;
}


// @brief 将图片数据加载到tensor中的数据内存上
// @param core_ptr 推理核心指针
// @param w_node_name 输入节点名
// @param image_data 输入图片数据矩阵
// @param image_size 图片矩阵长度
// @param return_ptr CoreStruct指针
// @return 异常标志
void* load_image_input_data(void* core_ptr, const wchar_t* w_node_name, uchar* image_data,
    size_t image_size,int type) { 
    
    // 读取推理模型地址
    CoreStruct* openvino_core = (CoreStruct*)core_ptr;
    std::string node_name = wchar_to_string(w_node_name);
    // 获取输入节点tensor
    ov::Tensor input_image_tensor = openvino_core->infer_request.get_tensor(node_name);
    int input_H = input_image_tensor.get_shape()[2]; //获得"image"节点的Height
    int input_W = input_image_tensor.get_shape()[3]; //获得"image"节点的Width

    // 对输入图片进行预处理
    cv::Mat input_image = data_to_mat(image_data, image_size); // 读取输入图片
    cv::Mat blob_image;
    cv::cvtColor(input_image, blob_image, cv::COLOR_BGR2RGB); // 将图片通道由 BGR 转为 RGB
    if (type == 0) {
        // 对输入图片按照tensor输入要求进行缩放
        cv::resize(blob_image, blob_image, cv::Size(input_W, input_H), 0, 0, cv::INTER_LINEAR);
        // 图像数据归一化，减均值mean，除以方差std
        // PaddleDetection模型使用imagenet数据集的均值 Mean = [0.485, 0.456, 0.406]和方差 std = [0.229, 0.224, 0.225]
        std::vector<float> mean_values{ 0.485 * 255, 0.456 * 255, 0.406 * 255 };
        std::vector<float> std_values{ 0.229 * 255, 0.224 * 255, 0.225 * 255 };
        std::vector<cv::Mat> rgb_channels(3);
        cv::split(blob_image, rgb_channels); // 分离图片数据通道
        for (auto i = 0; i < rgb_channels.size(); i++) {
            //分通道依此对每一个通道数据进行归一化处理
            rgb_channels[i].convertTo(rgb_channels[i], CV_32FC1, 1.0 / std_values[i], (0.0 - mean_values[i]) / std_values[i]);
        }
        cv::merge(rgb_channels, blob_image); // 合并图片数据通道
    }
    else if (type == 1) {
        // 对输入图片按照tensor输入要求进行缩放
        cv::resize(blob_image, blob_image, cv::Size(input_W, input_H), 0, 0, cv::INTER_LINEAR);
        // 图像数据归一化
        std::vector<float> std_values{ 1.0 * 255, 1.0 * 255, 1.0 * 255 };
        std::vector<cv::Mat> rgb_channels(3);
        cv::split(blob_image, rgb_channels); // 分离图片数据通道
        for (auto i = 0; i < rgb_channels.size(); i++) {
            //分通道依此对每一个通道数据进行归一化处理
            rgb_channels[i].convertTo(rgb_channels[i], CV_32FC1, 1.0 / std_values[i], 0);
        }
        cv::merge(rgb_channels, blob_image); // 合并图片数据通道
    }
    else if (type == 2) {
        // 对输入图片按照tensor输入要求进行缩放
        cv::resize(blob_image, blob_image, cv::Size(input_W, input_H), 0, 0, cv::INTER_LINEAR);
        // 图像数据归一化
        std::vector<float> std_values{ 1.0, 1.0, 1.0 };
        std::vector<cv::Mat> rgb_channels(3);
        cv::split(blob_image, rgb_channels); // 分离图片数据通道
        for (auto i = 0; i < rgb_channels.size(); i++) {
            //分通道依此对每一个通道数据进行归一化处理
            rgb_channels[i].convertTo(rgb_channels[i], CV_32FC1, 1.0 / std_values[i], 0);
        }
        cv::merge(rgb_channels, blob_image); // 合并图片数据通道
    }
    else if (type == 3) {
        // 获取仿射变换信息
        cv::Point center(blob_image.cols / 2, blob_image.rows / 2); // 变换中心
        cv::Size input_size(blob_image.cols, blob_image.rows); // 输入尺寸
        int rot = 0; // 角度
        cv::Size output_size(input_W, input_H); // 输出尺寸

        // 获取仿射变换矩阵
        cv::Mat warp_mat(2, 3, CV_32FC1);
        warp_mat = get_affine_transform(center, input_size, rot, output_size);
        // 仿射变化
        cv::warpAffine(blob_image, blob_image, warp_mat, output_size, cv::INTER_LINEAR);
        // 图像数据归一化
        std::vector<float> mean_values{ 0.485 * 255, 0.456 * 255, 0.406 * 255 };
        std::vector<float> std_values{ 0.229 * 255, 0.224 * 255, 0.225 * 255 };
        std::vector<cv::Mat> rgb_channels(3);
        cv::split(blob_image, rgb_channels); // 分离图片数据通道
        for (auto i = 0; i < rgb_channels.size(); i++) {
            //分通道依此对每一个通道数据进行归一化处理
            rgb_channels[i].convertTo(rgb_channels[i], CV_32FC1, 1.0 / std_values[i], (0.0 - mean_values[i]) / std_values[i]);
        }
        cv::merge(rgb_channels, blob_image); // 合并图片数据通道
    }
    else if (type == 4) {
        // 获取仿射变换信息
        cv::Point center(blob_image.cols / 2, blob_image.rows / 2); // 变换中心
        cv::Size input_size(blob_image.cols, blob_image.rows); // 输入尺寸
        int rot = 0; // 角度
        cv::Size output_size(input_W, input_H); // 输出尺寸

        // 获取仿射变换矩阵
        cv::Mat warp_mat;
        warp_mat = get_affine_transform(center, input_size, rot, output_size);
        // 仿射变化
        cv::warpAffine(blob_image, blob_image, warp_mat, output_size, cv::INTER_LINEAR);
        // 图像数据归一化
        std::vector<float> std_values{ 1.0 * 255, 1.0 * 255, 1.0 * 255 };
        std::vector<cv::Mat> rgb_channels(3);
        cv::split(blob_image, rgb_channels); // 分离图片数据通道
        for (auto i = 0; i < rgb_channels.size(); i++) {
            //分通道依此对每一个通道数据进行归一化处理
            rgb_channels[i].convertTo(rgb_channels[i], CV_32FC1, 1.0 / std_values[i], 0);
        }
        cv::merge(rgb_channels, blob_image); // 合并图片数据通道
    }
    else if (type == 5) {
        // 获取仿射变换信息
        cv::Point center(blob_image.cols / 2, blob_image.rows / 2); // 变换中心
        cv::Size input_size(blob_image.cols, blob_image.rows); // 输入尺寸
        int rot = 0; // 角度
        cv::Size output_size(input_W, input_H); // 输出尺寸

        // 获取仿射变换矩阵
        cv::Mat warp_mat;
        warp_mat = get_affine_transform(center, input_size, rot, output_size);
        // 仿射变化
        cv::warpAffine(blob_image, blob_image, warp_mat, output_size, cv::INTER_LINEAR);
        // 图像数据归一化
        std::vector<float> std_values{ 1.0, 1.0, 1.0 };
        std::vector<cv::Mat> rgb_channels(3);
        cv::split(blob_image, rgb_channels); // 分离图片数据通道
        for (auto i = 0; i < rgb_channels.size(); i++) {
            //分通道依此对每一个通道数据进行归一化处理
            rgb_channels[i].convertTo(rgb_channels[i], CV_32FC1, 1.0 / std_values[i], 0);
        }
        cv::merge(rgb_channels, blob_image); // 合并图片数据通道
    }
    // 将图片数据填充到tensor数据内存中
    fill_tensor_data_image(input_image_tensor, blob_image);

    return (void*)openvino_core;
    
}

// @brief 将其他数据加载到tensor中的数据内存上
// @param core_ptr 推理核心指针
// @param w_node_name 输入节点名
// @param input_data 输入数据数组
// @param [out] return_ptr CoreStruct指针
// @return 异常标志
void* load_input_data(void* core_ptr, const wchar_t* w_node_name, float* input_data) { 
    // 读取推理模型地址
    CoreStruct* openvino_core = (CoreStruct*)core_ptr;
    std::string input_node_name = wchar_to_string(w_node_name);
    // 读取指定节点tensor
    ov::Tensor input_image_tensor = openvino_core->infer_request.get_tensor(input_node_name);
    std::vector<size_t> input_shape = input_image_tensor.get_shape(); //获得输入节点的形状
    int input_size = std::accumulate(input_shape.begin(), input_shape.end(), 1, std::multiplies<int>()); // 获取长度
    // 将数据填充到tensor数据内存上
    fill_tensor_data_float(input_image_tensor, input_data, input_size);
    return (void*)openvino_core;
}

// @brief 对加载好的推理模型进行推理
// @param core_ptr 推理核心指针
// @param return_ptr CoreStruct指针
// @return 异常标志
void* core_infer(void* core_ptr){
    // 读取推理模型地址
    CoreStruct* openvino_core = (CoreStruct*)core_ptr;
    // 模型预测
    openvino_core->infer_request.infer();

    return (void*)openvino_core;
}

// @brief 查询float类型的推理结果
// @param core_ptr 推理核心指针
// @param w_node_name 输出节点名
// @param [out]  inference_result 推理结果数组
// @return 异常标志
void read_infer_result_F32(void* core_ptr, const wchar_t* w_node_name, float* infer_result) {
    // 读取推理模型地址
    CoreStruct* openvino_core = (CoreStruct*)core_ptr;
    std::string output_node_name = wchar_to_string(w_node_name);
    // 读取指定节点的tensor
    const ov::Tensor& output_tensor = openvino_core->infer_request.get_tensor(output_node_name);
    std::vector<size_t> input_shape = output_tensor.get_shape(); //获得输入节点的形状
    int output_size = std::accumulate(input_shape.begin(), input_shape.end(), 1, std::multiplies<int>()); // 获取长度
    // 获取网络节点数据地址
    const float* results = output_tensor.data<const float>();
    // 将输出结果复制到输出地址指针中
    for (int i = 0; i < output_size; i++) {
        *infer_result = results[i];
        infer_result++;
    }
}

// @brief 查询int类型的推理结果
// @param core_ptr 推理核心指针
// @param w_node_name 输出节点名
// @param [out]  inference_result 推理结果数组
// @return 异常标志
void read_infer_result_I32(void* core_ptr, const wchar_t* w_node_name, int* infer_result) {
    // 读取推理模型地址
    CoreStruct* openvino_core = (CoreStruct*)core_ptr;
    std::string output_node_name = wchar_to_string(w_node_name);
    // 读取指定节点的tensor
    const ov::Tensor& output_tensor = openvino_core->infer_request.get_tensor(output_node_name);
    std::vector<size_t> input_shape = output_tensor.get_shape(); //获得输入节点的形状
    int output_size = std::accumulate(input_shape.begin(), input_shape.end(), 1, std::multiplies<int>()); // 获取长度
    // 获取网络节点数据地址
    const int* results = output_tensor.data<const int>();
    // 将输出结果赋值到输出地址指针中
    for (int i = 0; i < output_size; i++) {
        *infer_result = results[i];
        infer_result++;
    }
}

// @brief 查询long long类型的推理结果
// @param core_ptr 推理核心指针
// @param w_node_name 输出节点名
// @param [out]  inference_result 推理结果数组
// @return 异常标志
void read_infer_result_I64(void* core_ptr, const wchar_t* w_node_name, long long* infer_result) {
    // 读取推理模型地址
    CoreStruct* openvino_core = (CoreStruct*)core_ptr;
    std::string output_node_name = wchar_to_string(w_node_name);
    // 读取指定节点的tensor
    const ov::Tensor& output_tensor = openvino_core->infer_request.get_tensor(output_node_name);
    std::vector<size_t> input_shape = output_tensor.get_shape(); //获得输入节点的形状
    int output_size = std::accumulate(input_shape.begin(), input_shape.end(), 1, std::multiplies<int>()); // 获取长度
    // 获取网络节点数据地址
    const long long* results = output_tensor.data<const long long>();
    // 将输出结果赋值到输出地址指针中
    for (int i = 0; i < output_size; i++) {
        *infer_result = results[i];
        infer_result++;
    }
}


// @brief 删除推理核心结构体指针，释放占用内存
// @param core_ptr 推理核心指针
// @return 异常标志
void core_delet(void* core_ptr) {
    //读取推理模型地址
    CoreStruct* openvino_core = (CoreStruct*)core_ptr;
    // 删除占用内存
    delete openvino_core;
}
