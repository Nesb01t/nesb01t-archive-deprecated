#include "../lib/object_manager.cpp"
#include "../lib/utils.cpp"
#include <windows.h>
#include <fstream>
#include <string>

class ProcessHelper
{
private:
    BOOL isAccessed;
    string gameTitle;
    HWND hWnd;
    BOOL isInGame;

public:
    HANDLE hProcess;
    ProcessHelper()
    {
        UpdateInfo();
    };

    VOID UpdateInfo()
    {
        isAccessed = GetPrivilege();
        gameTitle = ReadGameTitle();
        hWnd = GetHwnd();
        hProcess = GetProcessHandle();
        isInGame = GetIsingame();
    }

    VOID PrintHelper()
    {
        string prefix = "[ProcessHelper] ";
        cout << prefix << "isAccessed: " << isAccessed << endl;
        cout << prefix << "gameTitle: " << gameTitle << endl;
        cout << prefix << "hWnd: " << hWnd << endl;
        cout << prefix << "hProcess: " << hProcess << endl;
        cout << prefix << "isInGame: " << isInGame << endl;
    }

    BOOL CheckGameAccess()
    {
        if (hProcess != NULL && isInGame != 0 && isAccessed != 0)
        {
            return TRUE;
        }
        return FALSE;
    }

    // 进程
    BOOL GetPrivilege()
    {
        BOOL access = EnableDebugPrivilege(TRUE);
        return access;
    }

    string ReadGameTitle()
    {
        // 打开文件流
        ifstream file("./process_gametitle.txt");

        // 读取文件内容
        string game_title;
        getline(file, game_title);

        file.close();
        return game_title;
    }

    HWND GetHwnd()
    {
        // 查找窗口
        return FindWindowA(NULL, gameTitle.c_str());
    }

    HANDLE GetProcessHandle()
    {
        DWORD processId = 0;
        GetWindowThreadProcessId(hWnd, &processId);
        return OpenProcess(PROCESS_ALL_ACCESS, FALSE, processId);
    }

    // 游戏内
    BOOL GetIsingame()
    {
        isInGame = ReadMemory32(hProcess, O_is_ingame);
        return isInGame != 0;
    }
};