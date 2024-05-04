<div><center><b>
    <font color="34,63,93" size="7"> 
        基于C#(.NET Framework)的YOLO系列深度学习模型部署平台
    </font>
</b></center></div> 
## 1. 项目介绍

&emsp;    基于.NET Framework 4.8 开发的深度学习模型部署测试平台，提供了YOLO框架的主流系列模型，包括YOLOv8~v9，以及其系列下的Det、Seg、Pose、Obb、Cls等应用场景，同时支持图像与视频检测。模型部署引擎使用的是OpenVINO™、TensorRT、ONNX runtime以及OpenCV DNN，支持CPU、IGPU以及GPU多种设备推理。

&emsp;    其中，OpenVINO™以及TensorRT的C#接口均为自行开发，项目链接为：

OpenVINO™ C# API ：

```
https://github.com/guojin-yan/OpenVINO-CSharp-API.git
```

TensorRT C# API ：

```
https://github.com/guojin-yan/TensorRT-CSharp-API.git
```

&emsp;    演示视频：

- 微信：[C#模型部署平台：基于YOLOv8目标检测模型的视频检测](https://mp.weixin.qq.com/s/tT_21llcfGvkkq-HjdEOiw)
- 哔哩哔哩：[C#模型部署平台：基于YOLOv8目标检测模型的视频检测_哔哩哔哩_bilibili](https://www.bilibili.com/video/BV1yf421m7Hr)

&emsp;    C#&YOLO系列深度学习模型部署平台页面主要包括四个区域，分别为：模型选择和加载区域、推理区域、输入图像展示区域以及输出结果图像展示区域。如下图所示：

<div align=center><img src="https://s2.loli.net/2024/05/04/4guwKFP1srACTNy.png" width=800></div>

&emsp;    如下图所示，演示的是使用YOLOv5 Det模型的推理情况，

<div align=center><img src="https://s2.loli.net/2024/05/04/spkhbSmQM3fxTP8.png" width=800></div>

&emsp;    同样的方式，我们可以实现多种模型在不同平台的上的推理，如下图所示：

| <img src="https://s2.loli.net/2024/05/04/KVY7Ou8f9LbeBUQ.png"> | <img src="https://s2.loli.net/2024/05/04/3ZYqjoGr12kdmsu.png"> |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| <img src="https://s2.loli.net/2024/05/04/hrRJAUEBTIaKkSz.png"> | <img src="https://s2.loli.net/2024/05/04/p81FLfojsnYQkdm.png"> |

## 2. 支持模型

&emsp;    项目在开发时，同时开发了YOLOv5~v9以及YOLO World等YOLO系列模型，模型部署工具使用的是OpenVINO 、TensorRT 、ONNX runtime、OpenCV DNN，但有一些模型部署工具对模型的算子存在不支持情况，因此，对该项目中所使用的所有模型进行了测试，如下表所示：


|      Model      | OpenVINO CPU | OpenVINO GPU | TensorRT GPU | ONNX runtime CPU | ONNX runtime GPU | OpenCV DNN |
| :-------------: | :----------: | :----------: | :----------: | :--------------: | :--------------: | :--------: |
| **YOLOv5 Det**  |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLOv5 Seg**  |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLOv5 Cls**  |      ✅       |              |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLOv6 Det**  |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLOv7 Det**  |      ✅       |      ✅       |              |        ✅         |        ✅         |            |
| **YOLOv8 Det**  |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLOv8 Seg**  |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLOv8 Pose** |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLOv8 Obb**  |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLOv8 Cls**  |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLOv9 Det**  |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |            |
| **YOLOv9 Seg**  |      ✅       |      ✅       |      ✅       |        ✅         |        ✅         |     ✅      |
| **YOLO World**  |      ✅       |              |      ✅       |        ✅         |        ✅         |            |



## 3. 时间测试

&emsp;    在开发的模型部署平台上进行时间测试，当前的测试环境为：

- CPU：11th Intel Core i7-1165G7 2.8GHz
- IGPU：Intel Iris Xe Graphics
- GPU：NVIDIA GeForce RTX 2060

在同一环境下，对其中一些模型进行了测试，如下表所示：

|      Model      | OpenVINO CPU | OpenVINO IGPU | TensorRT GPU | ONNX runtime CPU | ONNX runtime GPU | OpenCV DNN |
| :-------------: | :----------: | :-----------: | :----------: | :--------------: | :--------------: | :--------: |
| **YOLOv5s Det** |   53.78 ms   |   28.84 ms    |   22.95 ms   |     95.68 ms     |     29.22 ms     | 178.53 ms  |
| **YOLOv5s Seg** |  119.53 ms   |   43.49 ms    |   31.17 ms   |    144.68 ms     |     42.27 ms     | 500.26 ms  |
| **YOLOv6s Det** |   98.66 ms   |   43.50 ms    |   19.93 ms   |    147.14 ms     |    25.90 msd     | 155.20 ms  |
| **YOLOv8s Det** |   77.06 ms   |   37.54 ms    |   20.04 ms   |    134.05 ms     |     25.82 ms     | 191.34 ms  |
| **YOLOv8s Seg** |  105.55 ms   |   48.45 ms    |   25.91 ms   |    200.01 ms     |     37.24 ms     | 532.16 ms  |

&emsp;    通过测试结果可以看出：

- 在GPU上：使用独立显卡加速的TensorRT在推理速度上表现是十分优秀的，但使用集成显卡加速的OpenVINO其推理速度也不容小觑，如果上到英特尔的独立显卡，其推理速度应该还会有很大程度上的提升，而ONNX runtime使用独立显卡加速，其推理性能上与TensorRT相比稍逊色；
- 在CPU上，OpenVINO 的表现时十分突出的，在使用极少的CPU占用上，其推理速度已经有了很大的提升，而ONNX runtime以及OpenCV DNN占用CPU很大的情况下，其推理速度远不如OpenVINO。



## 4. 总结

&emsp;    项目源码目前已经在GitHub上开源，项目链接为：

```
https://github.com/guojin-yan/YoloDeployCsharp.git
```

&emsp;    各位开发者可以根据自己情况加逆行下载，并进行项目配置，其中一些内容的配置可以参考一下文章：

- [最新发布！TensorRT C# API ：基于C#与TensorRT部署深度学习模型](https://mp.weixin.qq.com/s/Sw9ukiM9ZKOuzzGePVV4mg)

- [在 Windows 上使用 OpenVINO™ C# API 部署 Yolov8-obb 实现任意方向的目标检测 | 开发者实战](https://mp.weixin.qq.com/s/Cj18ih8G1aw4lrOUqW-06w)

&emsp;    最后如果各位开发者在使用中有任何问题，欢迎大家与我联系。

<div align=center><img src="https://s2.loli.net/2024/01/29/VIPU1MSwjEh2QAY.png" width=800></div>

