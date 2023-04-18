#pragma once
#include<time.h>
#include<iostream>
#include<map>
#include<string>
#include<vector>
#include "openvino/openvino.hpp"
#include "opencv2/opencv.hpp"
#include<windows.h>

#include"common.h"

// @brief 推理核心结构体
typedef struct openvino_core_struct {
	ov::Core core; // core对象
	std::shared_ptr<ov::Model> model_ptr; // 读取模型指针
	ov::CompiledModel compiled_model; // 模型加载到设备对象
	ov::InferRequest infer_request; // 推理请求对象
} CoreStruct;



// @brief 初始化openvino核心结构体，读取本地推理模型，将模型加载到设备，并创建推理请求
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void* STDMETHODCALLTYPE core_init(
	const wchar_t* w_model_dir, const wchar_t* w_device, const wchar_t* w_cache_dir);

// @brief 为输入tensor设置新形状，如果新的总大小大于前一个，则取消之前的设置
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void* STDMETHODCALLTYPE set_input_sharp(
	void* core_ptr, const wchar_t* w_node_name, size_t * input_shape, int input_size);

// @brief 将图片数据加载到tensor中的数据内存上
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void* STDMETHODCALLTYPE load_image_input_data(
	void* core_ptr, const wchar_t* w_node_name, uchar * image_data, size_t image_size, int type);

// @brief 将其他数据加载到tensor中的数据内存上
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void* STDMETHODCALLTYPE load_input_data(
	void* core_ptr, const wchar_t* w_node_name, float* input_data);

// @brief 对加载好的推理模型进行推理
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void* STDMETHODCALLTYPE core_infer(void* core_ptr);

// @brief 查询float类型的推理结果
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void STDMETHODCALLTYPE read_infer_result_F32(
	void* core_ptr, const wchar_t* w_node_name, float* infer_result);

// @brief 查询int类型的推理结果
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void STDMETHODCALLTYPE read_infer_result_I32(
	void* core_ptr, const wchar_t* w_node_name, int* infer_result);

// @brief 查询long long类型的推理结果
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void STDMETHODCALLTYPE read_infer_result_I64(
	void* core_ptr, const wchar_t* w_node_name, long long* infer_result);

// @brief 删除推理核心结构体指针，释放占用内存
EXTERN_C __MIDL_DECLSPEC_DLLEXPORT void STDMETHODCALLTYPE core_delet(void* core_ptr);







