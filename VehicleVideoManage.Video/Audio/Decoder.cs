using System;
using System.Runtime.InteropServices;

namespace VehicleVideoManage.Video.Audio
{
	public class Decoder
	{
		[DllImport("libopencore-amrnb-0.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Decoder_Interface_init();

		[DllImport("libopencore-amrnb-0.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Decoder_Interface_Decode(IntPtr state, byte[] inBuffer, short[] outBuffer, int bfi);

		[DllImport("libopencore-amrnb-0.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Decoder_Interface_exit(IntPtr state);
	}
}
