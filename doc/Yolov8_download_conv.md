# Yolov8部署模型获取与转换

## 1. 安装转换插件

### 1.1 安装ultralytics

```python
pip install ultralytics
```

### 1.2 安装ONNX

导出ONNX格式模型要求插件

```
pip install onnx
```

### 1.3 安装OpenVINO

导出IR模型要求插件

```shell
pip install openvino-dev
```



## 2. 获取Yolov8部署模型

### 2.1 Detection

**下载模型：**

```shell
wget https://github.com/ultralytics/assets/releases/download/v0.0.0/yolov8n.pt
```

**模型转换—ONNX**

```shell
yolo export model=yolov8s.pt imgsz=640 format=onnx opset=12
```

### 2.2 Segmentation

**下载模型：**

```
wget https://github.com/ultralytics/assets/releases/download/v0.0.0/yolov8s-seg.pt
```

**模型转换—ONNX**

```shell
yolo export model=yolov8s-seg.pt imgsz=640 format=onnx opset=12
```

### 2.3 Classification

**下载模型：**

```shell
wget https://github.com/ultralytics/assets/releases/download/v0.0.0/yolov8s-cls.pt
```

**模型转换—ONNX**

```shell
yolo export model=yolov8s-cls.pt imgsz=640 format=onnx opset=12
```

### 2.4 Pose

**下载模型：**

```shell
wget https://github.com/ultralytics/assets/releases/download/v0.0.0/yolov8s-pose.pt
```

**模型转换—ONNX**

```shell
yolo export model=yolov8s-pose.pt imgsz=640 format=onnx opset=12
```

### 
