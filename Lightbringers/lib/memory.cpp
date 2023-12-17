#pragma once
#include <windows.h>

typedef UINT32 MemPtr; // 表示内存地址或偏移量

// 实现内存读取逻辑
BOOL ReadMem(HANDLE hProcess, MemPtr offset, LPVOID data, SIZE_T size)
{
  return ReadProcessMemory(hProcess, reinterpret_cast<LPCVOID>(offset), data,
                           size, nullptr);
}

INT8 ReadMemory8(HANDLE hProcess, MemPtr offset)
{
  INT8 data;
  ReadMem(hProcess, offset, &data, sizeof(INT8));
  return data;
}

INT16 ReadMemory16(HANDLE hProcess, MemPtr offset)
{
  INT16 data;
  ReadMem(hProcess, offset, &data, sizeof(INT16));
  return data;
}

INT32 ReadMemory32(HANDLE hProcess, MemPtr offset)
{
  INT32 data;
  ReadMem(hProcess, offset, &data, sizeof(INT32));
  return data;
}

INT64 ReadMemory64(HANDLE hProcess, MemPtr offset)
{
  INT64 data;
  ReadMem(hProcess, offset, &data, sizeof(INT64));
  return data;
}

FLOAT ReadMemoryFloat(HANDLE hProcess, MemPtr offset)
{
  FLOAT data;
  ReadMem(hProcess, offset, &data, sizeof(FLOAT));
  return data;
}

MemPtr ReadMemoryPtr(HANDLE hProcess, MemPtr offset)
{
  MemPtr memPtr = (MemPtr)ReadMemory32(hProcess, offset);
  return memPtr;
}

// 实现内存写入逻辑
BOOL WriteMem(HANDLE hProcess, MemPtr offset, LPCVOID data, SIZE_T size)
{
  return WriteProcessMemory(hProcess, reinterpret_cast<LPVOID>(offset), data,
                            size, nullptr);
}

BOOL WriteMemory32(HANDLE hProcess, MemPtr offset, INT32 data)
{
  return WriteMem(hProcess, offset, &data, sizeof(INT32));
}

// 实现内存分配逻辑
// MemPtr AllocateMem(HANDLE hProcess, SIZE_T size)
// {
//   LPVOID addr =
//       VirtualAllocEx(hProcess, nullptr, size, MEM_COMMIT | MEM_RESERVE,
//                      PAGE_EXECUTE_READWRITE);
//   return (MemPtr)addr;
// }

// 实现内存释放逻辑
void FreeMem(HANDLE hProcess, MemPtr addr)
{
  VirtualFreeEx(hProcess, reinterpret_cast<LPVOID>(addr), 0, MEM_RELEASE);
}