#pragma once


#include<time.h>
#include<iostream>
#include<map>
#include<string>
#include<vector>
#include "openvino/openvino.hpp"
#include "opencv2/opencv.hpp"
#include<windows.h>



// @breaf 异常状态
enum class ExceptionStatus : int {
	NotOccurred = 0, // 未发生异常
	Occurred = 1 // 发生异常
};


// @brief 将wchar_t*字符串指针转换为string字符串格式
std::string wchar_to_string(const wchar_t* wchar);

// @brief 将图片的矩阵数据转换为opencv的mat数据
cv::Mat data_to_mat(uchar* data, size_t size);

// @brief 对网络的输入为图片数据的节点进行赋值，实现图片数据输入网络
void fill_tensor_data_image(ov::Tensor& input_tensor, const cv::Mat& input_image);

// @brief 对网络的输入为fkloat数据的节点进行赋值，实现float数据输入网络
void fill_tensor_data_float(ov::Tensor& input_tensor, float* input_data, int data_size);

// @brief 构建放射变换矩阵
cv::Mat get_affine_transform(cv::Point center, cv::Size input_size, int rot, cv::Size output_size,
	cv::Point2f shift = cv::Point2f(0, 0));