namespace yolo_openvino_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //TimeTest.test("E:/Model/Yolo/yolov10s.onnx", "E:/Data/image/demo_2.jpg", "CPU");
            YoloDet.predict("E:/Model/Yolo/yolo12x.onnx", "E:/Data/image/demo_2.jpg", "CPU");

        }
    }
}
