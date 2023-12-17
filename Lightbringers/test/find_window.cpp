#include <iostream>
#include <windows.h>
#include <fstream>

using namespace std;

int main()
{
  // 打开文件流
  ifstream file("find_gamewindow.txt");
  if (!file.is_open())
  {
    cout << "open txt failed!" << endl;
    return 0;
  }

  // 读取文件内容
  string game_title;
  getline(file, game_title);
  cout << "get game title is: " << game_title << endl;

  // 查找窗口
  HWND hwnd = FindWindowA(NULL, game_title.c_str());
  if (hwnd == NULL)
  {
    cout << "find window failed, window title is: " << game_title.c_str() << endl;
    return 0;
  }
  cout << "find window success, window hwnd is: " << hwnd << endl;
  return 0;
}