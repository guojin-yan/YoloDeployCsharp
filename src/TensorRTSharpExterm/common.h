#pragma once
#pragma once


#include<time.h>
#include<iostream>
#include<map>
#include<string>
#include<vector>
#include "opencv2/opencv.hpp"
#include<windows.h>


// @brief 将wchar_t*字符串指针转换为string字符串格式
std::string wchar_to_string(const wchar_t* wchar);
// @brief 将wchar_t*字符串指针转换为string字符串格式
char* wchar_to_char(const wchar_t* wchar);

// @brief 将图片的矩阵数据转换为opencv的mat数据
cv::Mat data_to_mat(uchar* data, size_t size);


// @brief 构建放射变换矩阵
cv::Mat get_affine_transform(cv::Point center, cv::Size input_size, int rot, cv::Size output_size,
	cv::Point2f shift = cv::Point2f(0, 0));