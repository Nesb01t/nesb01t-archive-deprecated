#include <iostream>
#include <thread>
#include <chrono>
#include <vector>

using namespace std;

/// @brief 命令行输出工具
class CommandLineUI
{
private:
    thread refreshThread;
    bool isRunning = true;
    int refreshInterval = 100;
    vector<string> message;

    HANDLE hOutput;
    HANDLE hOutBuff;
    COORD coord = {0, 0};
    DWORD bytes = 0;
    char data[3200];

public:
    CommandLineUI()
    {
        refreshThread = thread([this]()
                               {
            while(isRunning){
                Update();
                this_thread::sleep_for(chrono::milliseconds(this->refreshInterval));
            } });
    }

    void Update()
    {
        system("cls");
        for (int i = 0; i < message.size(); i++)
        {
            cout << message[i] << endl;
        }
    }

    void Add(string str)
    {
        message.push_back(str);
    }

    void Clear()
    {
        message.clear();
    }

    void Set(string str)
    {
        message.clear();
        message.push_back(str);
    }

    void Set(vector<string> str)
    {
        message.clear();
        message = str;
    }
};