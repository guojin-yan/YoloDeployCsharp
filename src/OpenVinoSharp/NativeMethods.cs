using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenVinoSharp
{
    internal class NativeMethods
    {
        private const string dll_extern = @"E:\Git_space\Csharp_deploy_Yolov8\src\Release\x64\OpenVinoSharpExtern.dll";

        [DllImport(dll_extern, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr core_init(string model_dir, string device, string w_cache_dir);

        [DllImport(dll_extern, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr set_input_sharp(IntPtr core, string node_name, 
            ref ulong input_shape, int input_size);

        [DllImport(dll_extern, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr load_image_input_data(IntPtr core, string input_node_name, 
            ref byte image_data, ulong image_size, int type);

        [DllImport(dll_extern, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr load_input_data(IntPtr core, string input_node_name, ref float input_data);

        [DllImport(dll_extern, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr core_infer(IntPtr core);

        [DllImport(dll_extern, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static void read_infer_result_F32(IntPtr core, string node_name, ref float result);

        [DllImport(dll_extern, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static void read_infer_result_I32(IntPtr core, string node_name, ref int result);
        [DllImport(dll_extern, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static void read_infer_result_I64(IntPtr core, string node_name, ref long result);

        [DllImport(dll_extern, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public extern static void core_delet(IntPtr core);
    }
}
