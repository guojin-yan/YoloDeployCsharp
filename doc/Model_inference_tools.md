# 模型推理工具安装

## OpenVinoSharp

&emsp;    [OpenVINO™](www.openvino.ai)是一个用于优化和部署深度学习模型的开源工具包，是英特尔基于自身现有的硬件平台开发的一种可以加快高性能计算机视觉和深度学习视觉应用开发速度工具套件，用于快速开发应用程序和解决方案，以解决各种任务（包括人类视觉模拟、自动语音识别、自然语言处理和推荐系统等）。

&emsp;    官方发行的[OpenVINO™](www.openvino.ai)未提供C#编程语言接口，因此在使用时无法实现在C#中利用[OpenVINO™](www.openvino.ai)进行模型部署。在该项目中，利用动态链接库功能，调用官方依赖库，实现在C#中部署深度学习模型，为方便使用，在该项目中提供了NuGet包方便使用，为了方便大家再此基础上进行开发，该项目提供了详细的技术文档。

<img title="更新日志" src="https://s2.loli.net/2023/01/26/LdbeOYGgwZvHcBQ.png" alt="" width="300">

## <img title="安装" src="https://s2.loli.net/2023/01/26/bm6WsE5cfoVvj7i.png" alt="" width="50"> 安装

### OpenVINO安装

&emsp;OpenVINO安装，请参考[openvino_installation.md](.\docs\openvino_installation.md)安装指导文档。

### OpenVinoSharp

- **获取OpenVinoSharp项目源码****

```
GitHub:
git clone https://github.com/guojin-yan/OpenVinoSharp.git
Gitee:
git clone https://gitee.com/guojin-yan/OpenVinoSharp.git
```

- **添加项目引用**

&emsp;   ``OpenVinoSharp``项目主要包含``OpenVinoSharpExterm`` C++ 接口项目和``OpenVinoSharp`` C# 类项目，将该项目添加到当前解决中，并增加对``OpenVinoSharp`` C# 类项目的引用即可。

&emsp;   由于不同电脑安装的OpenVino位置不同，因此在使用中可能会获取不到依赖项，因此建议此处按照OpenVino位置重新配置和编译``OpenVinoSharpExterm`` C++ 接口项目，C++ 项目配置参考[【OpenVINO】OpenVINO 2022.1更新2022.3教程_椒颜皮皮虾྅的博客-CSDN博客](https://blog.csdn.net/Grape_yan/article/details/128772065)

### OpenVinoSharp NuGet包安装

- **（1）下载NuGet包**

&emsp;使用Visual Studio自带的NuGet管理包，搜索OpenVinoSharp.win，找到对应的包，并将其安装到项目中。

<img title="nuget" src="https://s2.loli.net/2023/02/09/vpkBefE3bSlGuVU.png" alt="" width="500">

- **（2）复制依赖项**

&emsp;由于项目依赖较多的外部依赖项，因此为了方便使用，此处提供了所需的依赖。

&emsp;打开下载的NuGet下载路径，路径一般为``C:\Users\(用户名)\.nuget\packages\``，并找到``openvinosharp.win``，将``external lib``文件夹中的所有文件复制到程序运行目录中。

<img title="nuget" src="https://s2.loli.net/2023/02/09/CpdNnRMXJhUz19Y.png" alt="" width="500">

## TensorRTSharp

&emsp;   NVIDIA®TensorRT的核心™ 是一个C++库，有助于在NVIDIA图形处理单元（GPU）上进行高性能推理。TensorRT采用一个经过训练的网络，该网络由一个网络定义和一组经过训练的参数组成，并生成一个高度优化的运行时引擎，为该网络执行推理。TensorRT通过C++和Python提供API，帮助通过网络定义API表达深度学习模型，或通过解析器加载预定义模型，从而使TensorRT能够在NVIDIA GPU上优化和运行它们。TensorRT应用了图优化、层融合等优化，同时还利用高度优化的内核的不同集合找到了该模型的最快实现。TensorRT还提供了一个运行时，您可以使用该运行时在开普勒一代以后的所有NVIDIA GPU上执行该网络。TensorRT还包括Tegra中引入的可选高速混合精度功能™ X1，并用Pascal™, Volta™, Turing™, and NVIDIA® Ampere GPU 架构。

&emsp;   在推理过程中，基于 TensorRT 的应用程序的执行速度可比 CPU 平台的速度快 40 倍。借助 TensorRT，您可以优化在所有主要框架中训练的神经网络模型，精确校正低精度，并最终将模型部署到超大规模数据中心、嵌入式或汽车产品平台中。

&emsp;    官方发行的 TensorRT未提供C#编程语言接口，因此在使用时无法实现在C#中利用 TensorRT进行模型部署。在该项目中，利用动态链接库功能，调用官方依赖库，实现在C#中部署深度学习模型。

<img title="更新日志" src="https://s2.loli.net/2023/04/11/Otsq6zAaZnwxP1U.png" alt="" width="300">

### <img title="安装" src="https://s2.loli.net/2023/01/26/bm6WsE5cfoVvj7i.png" alt="" width="50"> 安装

### TensorRT安装

&emsp;   TensorRT依赖于CUDA加速，因此需要同时安装CUDA与TensorRT才可以使用，且CUDA与TensorRT版本之间需要对应，否者使用会出现较多问题，因此此处并未提供Nuget包，组要根据自己电脑配置悬着合适的版本安装后重新编译本项目源码，下面是TensorRT安装教程：[【TensorRT】NVIDIA TensorRT 安装 (Windows C++)_椒颜皮皮虾྅的博客-CSDN博客](https://blog.csdn.net/Grape_yan/article/details/127320959)

### TensorRTSharp 配置

- **获取TensorRTSharp项目源码****

```
GitHub:
git clone https://github.com/guojin-yan/TensorRTSharp.git
Gitee:
git clone https://gitee.com/guojin-yan/TensorRTSharp.git
```

- **添加项目引用**

&emsp;   ``TensorRTSharp``项目主要包含``TensorRTSharpExterm`` C++ 接口项目和``TensorRTSharp`` C# 类项目，将该项目添加到当前解决中，并增加对``TensorRTSharp`` C# 类项目的引用即可。

&emsp;   由于不同电脑安装的TensorRT和CUDA位置不同，因此在使用中可能会获取不到依赖项，因此建议此处按照TensorRT和CUDA位置重新配置和编译``TensorRTSharpExterm`` C++ 接口项目，C++ 项目配置参考[【TensorRT】NVIDIA TensorRT 安装 (Windows C++)_椒颜皮皮虾྅的博客-CSDN博客](https://blog.csdn.net/Grape_yan/article/details/127320959)。