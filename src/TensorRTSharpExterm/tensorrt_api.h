#pragma once
#include <fstream>
#include <iostream>
#include <vector>
#include <numeric>
#include "NvInfer.h"
#include "NvOnnxParser.h"
#include <opencv2/opencv.hpp>
#include<windows.h>


// @brief 用于创建IBuilder、IRuntime或IRefitter实例的记录器用于通过该接口创建的所有对象。
// 在释放所有创建的对象之前，记录器应一直有效。
// 主要是实例化ILogger类下的log()方法。
class Logger : public nvinfer1::ILogger {
	void log(Severity severity, const char* message)  noexcept {
		// suppress info-level messages
		if (severity != Severity::kINFO)
			std::cout << message << std::endl;
	}
} gLogger;

// @brief 推理核心结构体
typedef struct tensorRT_nvinfer {
	Logger logger;
	// 反序列化引擎
	nvinfer1::IRuntime* runtime;
	// 推理引擎
	// 保存模型的模型结构、模型参数以及最优计算kernel配置；
	// 不能跨平台和跨TensorRT版本移植
	nvinfer1::ICudaEngine* engine;
	// 上下文
	// 储存中间值，实际进行推理的对象
	// 由engine创建，可创建多个对象，进行多推理任务
	nvinfer1::IExecutionContext* context;
	// cudn缓存标志
	cudaStream_t stream;
	// GPU显存输入/输出缓冲
	void** data_buffer;
} NvinferStruct;

// @brief 将本地onnx模型转为tensorrt中的engine格式，并保存到本地
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void STDMETHODCALLTYPE  onnx_to_engine(const wchar_t* onnx_file_path_wchar,
	const wchar_t* engine_file_path_wchar, int type);
// @brief 读取本地engine模型，并初始化NvinferStruct
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void* STDMETHODCALLTYPE nvinfer_init(const wchar_t* engine_filename_wchar);
// @brief 创建GPU显存输入/输出缓冲区
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void* STDMETHODCALLTYPE creat_gpu_buffer(void* nvinfer_ptr);
// @brief 加载图片输入数据到缓冲区
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void* STDMETHODCALLTYPE load_image_data(void* nvinfer_ptr,
	const wchar_t* node_name_wchar, uchar * image_data, size_t image_size, int BN_means);
// @brief 模型推理
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void* STDMETHODCALLTYPE infer(void* nvinfer_ptr);
// @brief 读取推理数据
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void STDMETHODCALLTYPE  read_infer_result(void* nvinfer_ptr,
	const wchar_t* node_name_wchar, float* output_result);
// @brief 删除内存地址
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void STDMETHODCALLTYPE nvinfer_delete(void* nvinfer_ptr);
