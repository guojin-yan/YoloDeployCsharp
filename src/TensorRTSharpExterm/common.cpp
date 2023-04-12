#include"common.h"


// @brief 将wchar_t*字符串指针转换为string字符串格式
// @param wchar 输入字符指针
// @return 转换出的string字符串 
std::string wchar_to_string(const wchar_t* wchar) {
    // 获取输入指针的长度
    int path_size = WideCharToMultiByte(CP_OEMCP, 0, wchar, wcslen(wchar), NULL, 0, NULL, NULL);
    char* chars = new char[path_size + 1];
    // 将双字节字符串转换成单字节字符串
    WideCharToMultiByte(CP_OEMCP, 0, wchar, wcslen(wchar), chars, path_size, NULL, NULL);
    chars[path_size] = '\0';
    std::string pattern = chars;
    delete chars; //释放内存
    return pattern;
}

// @brief 将wchar_t*字符串指针转换为string字符串格式
// @param wchar 输入字符指针
// @return 转换出的string字符串 
char* wchar_to_char(const wchar_t* wchar) {
    // 获取输入指针的长度
    int path_size = WideCharToMultiByte(CP_OEMCP, 0, wchar, wcslen(wchar), NULL, 0, NULL, NULL);
    char* chars = new char[path_size + 1];
    // 将双字节字符串转换成单字节字符串
    WideCharToMultiByte(CP_OEMCP, 0, wchar, wcslen(wchar), chars, path_size, NULL, NULL);
    chars[path_size] = '\0';
    return chars;
}

// @brief 将图片的矩阵数据转换为opencv的mat数据
// @param data 图片矩阵
// @param size 图片矩阵长度
// @return 转换后的mat数据
cv::Mat data_to_mat(uchar* data, size_t size) {
    //将图片数组数据读取到容器中
    std::vector<uchar> buf;
    for (int i = 0; i < size; i++) {
        buf.push_back(*data);
        data++;
    }
    // 利用图片解码，将容器中的数据转换为mat类型
    return cv::imdecode(cv::Mat(buf), 1);
}



// @brief 构建放射变换矩阵
// @param center 中心点
// @param input_size 输入尺寸
// @param rot 角度
// @param output_size 输出尺寸
// @param shift 
// @rrturn 变换矩阵
cv::Mat get_affine_transform(cv::Point center, cv::Size input_size, int rot, cv::Size output_size,
    cv::Point2f shift) {

    // 输入尺寸宽度
    int src_w = input_size.width;

    // 输出尺寸
    int dst_w = output_size.width;
    int dst_h = output_size.height;

    // 旋转角度
    float rot_rad = 3.1715926f * rot / 180.0;
    int pt = (int)src_w * -0.5;
    float sn = std::sin(rot_rad);
    float cs = std::cos(rot_rad);

    cv::Point2f src_dir(-1.0 * pt * sn, pt * cs);
    cv::Point2f dst_dir(0.0, dst_w * -0.5);
    // 输入三个点
    cv::Point2f src[3];
    src[0] = cv::Point2f(center.x + input_size.width * shift.x, center.y + input_size.height * shift.y);
    src[1] = cv::Point2f(center.x + src_dir.x + input_size.width * shift.x, center.y + src_dir.y + input_size.height * shift.y);
    cv::Point2f direction = src[0] - src[1];
    src[2] = cv::Point2f(src[1].x - direction.y, src[1].y - direction.x);
    // 输出三个点
    cv::Point2f dst[3];
    dst[0] = cv::Point2f(dst_w * 0.5, dst_h * 0.5);
    dst[1] = cv::Point2f(dst_w * 0.5 + dst_dir.x, dst_h * 0.5 + dst_dir.y);
    direction = dst[0] - dst[1];
    dst[2] = cv::Point2f(dst[1].x - direction.y, dst[1].y - direction.x);

    return cv::getAffineTransform(src, dst);

}
