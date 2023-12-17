using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LumosBringers.Lib;

/// <summary>
/// 实现内存读写逻辑的类
/// </summary>
public static class MemoryHelper
{
    private const int MEM_COMMIT = 0x1000;
    private const int MEM_RESERVE = 0x2000;
    private const int MEM_RELEASE = 0x8000;
    private const int PAGE_EXECUTE_READWRITE = 0x40;

    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize,
        out int lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer,
        uint nSize, out int lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize,
        uint flAllocationType, uint flProtect);


    [DllImport("kernel32.dll")]
    private static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);

    public static bool ReadMem(IntPtr hProcess, IntPtr offset, byte[] data, uint size)
    {
        IntPtr lpBaseAddress = (IntPtr)offset;
        return ReadProcessMemory(hProcess, lpBaseAddress, data, size, out _);
    }

    public static byte ReadMem8(IntPtr hProcess, IntPtr offset)
    {
        byte[] data = new byte[sizeof(byte)];
        ReadMem(hProcess, offset, data, sizeof(byte));
        return data[0];
    }

    public static short ReadMem16(IntPtr hProcess, IntPtr offset)
    {
        byte[] data = new byte[sizeof(short)];
        ReadMem(hProcess, offset, data, sizeof(short));
        return BitConverter.ToInt16(data, 0);
    }

    public static int ReadMem32(IntPtr hProcess, IntPtr offset)
    {
        byte[] data = new byte[sizeof(int)];
        ReadMem(hProcess, offset, data, sizeof(int));
        return BitConverter.ToInt32(data, 0);
    }

    public static long ReadMem64(IntPtr hProcess, IntPtr offset)
    {
        byte[] data = new byte[sizeof(long)];
        ReadMem(hProcess, offset, data, sizeof(long));
        return BitConverter.ToInt64(data, 0);
    }

    public static float ReadMemFloat(IntPtr hProcess, IntPtr offset)
    {
        byte[] data = new byte[sizeof(float)];
        ReadMem(hProcess, offset, data, sizeof(float));
        return BitConverter.ToSingle(data, 0);
    }

    public static string ReadMemStr(IntPtr hProcess, IntPtr offset, uint size)
    {
        byte[] data = new byte[size];
        ReadMem(hProcess, offset, data, size);

        // 测试输出源 byte
        // string s = "";
        // foreach (var b in data)
        // {
        //     s += b.ToString("X2");
        // }

        return Encoding.BigEndianUnicode.GetString(data);
    }

    public static IntPtr ReadMemPtr(IntPtr hProcess, IntPtr offset)
    {
        int value = ReadMem32(hProcess, offset);
        return value;
    }

    public static bool WriteMem(IntPtr hProcess, IntPtr offset, byte[] data, uint size)
    {
        IntPtr lpBaseAddress = (IntPtr)offset;
        return WriteProcessMemory(hProcess, lpBaseAddress, data, size, out _);
    }

    public static bool WriteMem32(IntPtr hProcess, IntPtr offset, int data)
    {
        byte[] buffer = BitConverter.GetBytes(data);
        return WriteMem(hProcess, offset, buffer, sizeof(int));
    }

    public static bool WriteMemFloat(IntPtr hProcess, IntPtr offset, float data)
    {
        byte[] buffer = BitConverter.GetBytes(data);
        return WriteMem(hProcess, offset, buffer, sizeof(float));
    }

    public static IntPtr AllocateMem(IntPtr hProcess, uint size)
    {
        return VirtualAllocEx(hProcess, IntPtr.Zero, size, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
    }

    public static void FreeMem(IntPtr hProcess, IntPtr addr)
    {
        VirtualFreeEx(hProcess, addr, 0, MEM_RELEASE);
    }
}