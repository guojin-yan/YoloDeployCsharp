namespace OpenVinoSharp
{
    public class Core
    {
        private IntPtr core_ptr = new IntPtr();

        // @brief core类默认初始化方法
        public Core() { }
        // @brief core类参数输入初始化方法
        // @param model_file 本地推理模型地址路径
        // @param device_name 设备名称
        public Core(string model, string device, string cache_dir = "")
        {
            // 初始化推理核心
            core_ptr = NativeMethods.core_init(model, device, cache_dir);
        }
        // @brief 设置推理模型的输入节点的大小
        // @param input_node_name 输入节点名
        // @param input_size 输入形状大小数组
        public void set_input_sharp(string node_name, ulong[] input_size)
        {
            // 获取输入数组长度
            int length = input_size.Length;
            core_ptr = NativeMethods.set_input_sharp(core_ptr, node_name, ref input_size[0], length);
        }

        // @brief 加载推理数据
        // @param input_node_name 输入节点名
        // @param input_data 输入数据数组
        public void load_input_data(string node_name, float[] input_data)
        {
            core_ptr = NativeMethods.load_input_data(core_ptr, node_name, ref input_data[0]);
        }
        // @brief 加载图片推理数据
        // @param input_node_name 输入节点名
        // @param image_data 图片矩阵
        // @param image_size 图片矩阵长度
        public void load_input_data(string node_name, byte[] image_data, ulong image_size, int type)
        {
            core_ptr = NativeMethods.load_image_input_data(core_ptr, node_name, ref image_data[0], image_size, type);
        }
        // @brief 模型推理
        public void infer()
        {
            core_ptr = NativeMethods.core_infer(core_ptr);
        }
        // @brief 读取推理结果数据
        // @param output_node_name 输出节点名
        // @param data_size 输出数据长度
        // @return 推理结果数组
        public T[] read_infer_result<T>(string node_name, int data_size)
        {
            // 获取设定类型
            string t = typeof(T).ToString();
            // 新建返回值数组
            T[] result = new T[data_size];
            if (t == "System.Int32")
            { // 读取数据类型为整形数据
                int[] inference_result = new int[data_size];
                NativeMethods.read_infer_result_I32(core_ptr, node_name, ref inference_result[0]);
                result = (T[])Convert.ChangeType(inference_result, typeof(T[]));
                return result;
            }
            else if (t == "System.Int64")
            {
                long[] inference_result = new long[data_size];
                NativeMethods.read_infer_result_I64(core_ptr, node_name, ref inference_result[0]);
                result = (T[])Convert.ChangeType(inference_result, typeof(T[]));
                return result;
            }
            else
            { // 读取数据类型为浮点型数据
                float[] inference_result = new float[data_size];
                NativeMethods.read_infer_result_F32(core_ptr, node_name, ref inference_result[0]);
                result = (T[])Convert.ChangeType(inference_result, typeof(T[]));
                return result;
            }
        }
        // @brief 删除创建的地址
        public void delet()
        {
            NativeMethods.core_delet(core_ptr);
        }

    }
}