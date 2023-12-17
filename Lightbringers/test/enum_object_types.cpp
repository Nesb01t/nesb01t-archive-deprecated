#include "../services/process_helper.cpp"
#include "../services/command_line_ui.cpp"
#include "../lib/object_manager.cpp"
#include "../lib/memory.cpp"
#include <iostream>

using namespace std;

int main()
{
    // get process
    ProcessHelper ph;
    ph.PrintHelper();

    // get last object
    struct Object *obj = GetObjects(ph.hProcess);
    vector<string> print_info;
    while (obj->prev != NULL)
    {
        string info = "Type: " + to_string(obj->type) + " ObjType: " + to_string(obj->obj_type);
        print_info.push_back(info);
        obj = obj->prev;
    }

    // print info
    for (int i = 0; i < print_info.size(); i++)
    {
        cout << print_info[i] << endl;
    }

    // pause
    system("pause");
}