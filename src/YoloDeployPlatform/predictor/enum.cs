using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoloDeployPlatform.predictor
{
    public static class MyEnum
    {
        public static T GetModelType<T>(string strType)
        {
            T t = (T)ModelType.Parse(typeof(T), strType);
            return t;
        }
        public static T GetEngineType<T>(string strType)
        {
            T t = (T)EngineType.Parse(typeof(T), strType);
            return t;
        }
    }
    public enum EngineType
    {
        OpenVINO,
        TensorRT,
        ONNX,
        OpenCV,
        NULL
    }

    public enum ModelType 
    {
        YOLOv5Det,
        YOLOv5Seg,
        YOLOv5Cls,
        YOLOv6Det,
        YOLOv7Det,
        YOLOv8Det,
        YOLOv8Seg,
        YOLOv8Cls,
        YOLOv8Pose,
        YOLOv8Obb,
        YOLOv9Det,
        YOLOv9Seg,
        YOLOWorld,
        YOLOv10Det
    }
}
