using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TensorRTSharp
{
    internal class NativeMethods
    {
        private const string tensorrt_dll_path = @"TensorRTSharpExterm.dll";

        [DllImport(tensorrt_dll_path, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static void onnx_to_engine(string onnx_file_path, string engine_file_path, int type);
        [DllImport(tensorrt_dll_path, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr nvinfer_init(string engine_filename);
        [DllImport(tensorrt_dll_path, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr creat_gpu_buffer(IntPtr nvinfer_ptr);
        [DllImport(tensorrt_dll_path, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr load_image_data(IntPtr nvinfer_ptr, string node_name, ref byte image_data, ulong image_size, int BN_means);
        [DllImport(tensorrt_dll_path, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr infer(IntPtr nvinfer_ptr);
        [DllImport(tensorrt_dll_path, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static void read_infer_result(IntPtr nvinfer_ptr, string node_name_wchar, ref float result);
        [DllImport(tensorrt_dll_path, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static void nvinfer_delete(IntPtr nvinfer_ptr);
    }
}
