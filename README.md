# 基于C# WinForm平台部署Yolov8

#  Yolov8模型

&emsp;  由Ultralytics开发的Ultralytics YOLOv8是一种尖端的，最先进的（SOTA）模型，它建立在以前的YOLO版本成功的基础上，并引入了新功能和改进，以进一步提高性能和灵活性。YOLOv8 设计为快速、准确且易于使用，使其成为各种对象检测、图像分割和图像分类任务的绝佳选择。

&emsp;  YOLOv8是YOLO系列目标检测算法的最新版本，相比于之前的版本，YOLOv8具有更快的推理速度、更高的精度、更加易于训练和调整、更广泛的硬件支持以及原生支持自定义数据集等优势。这些优势使得YOLOv8成为了目前业界最流行和成功的目标检测算法之一。

<img width="1024" src="https://user-images.githubusercontent.com/26833433/212094133-6bb8c21c-3d47-41df-a512-81c5931054ae.png">

# WinForm部署平台

下图展示了搭建的WinForm模型部署平台，该模型部署平台支持多种推理方式与多种Yolov8模型。

![image-20230419105906820](https://s2.loli.net/2023/04/19/EnMZH1LWV7yhBxj.png)

关于模型部署的更多细节文档，请参考以下文档：

[OpenVINO_yolov8.md ](https://github.com/guojin-yan/Csharp_deploy_Yolov8/blob/master/doc/OpenVINO_yolov8.md)

[TensorRT_yolov8.md ](https://github.com/guojin-yan/Csharp_deploy_Yolov8/blob/master/doc/TensorRT_yolov8.md)