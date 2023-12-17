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
    struct Object *last_object = GetObjects(ph.hProcess);

    // print last object info
    vector<string> last_object_info;
    last_object_info.push_back("GUID: " + to_string(last_object->guid));
    last_object_info.push_back("Name: " + string(last_object->name));
    last_object_info.push_back("Type: " + to_string(last_object->type));
    last_object_info.push_back("X: " + to_string(last_object->pos_x));
    last_object_info.push_back("Y: " + to_string(last_object->pos_y));
    last_object_info.push_back("Z: " + to_string(last_object->pos_z));
    last_object_info.push_back("Rotation: " + to_string(last_object->rotation));
    last_object_info.push_back("HP: " + to_string(last_object->hp_curr) + "/" + to_string(last_object->hp_max));
    last_object_info.push_back("Mana: " + to_string(last_object->mana_curr) + "/" + to_string(last_object->mana_max));
    last_object_info.push_back("Level: " + to_string(last_object->level));
    last_object_info.push_back("ObjType: " + to_string(last_object->obj_type));
    for (int i = 0; i < last_object_info.size(); i++)
    {
        cout << last_object_info[i] << endl;
    }

    // pause
    system("pause");
}