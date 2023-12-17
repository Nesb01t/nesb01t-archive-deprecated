#include <string>
#include <windows.h>
#include "../services/command_line_ui.cpp"
using namespace std;

int main()
{
    CommandLineUI ui;
    ui.Add("你好");
    Sleep(10000);
}
