# 获取Yolov8部署模型

**下载模型：**

```shell
wget https://github.com/ultralytics/assets/releases/download/v0.0.0/yolov8n.pt
```

**模型转换**

```shell
yolo export model=yolov8s.pt imgsz=640 format=onnx opset=12
```

