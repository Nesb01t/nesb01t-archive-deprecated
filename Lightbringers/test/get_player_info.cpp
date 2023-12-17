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

    // get player
    struct Object *obj = GetObjects(ph.hProcess);
    while (obj->prev != NULL)
    {
        if (obj->type == O_T_PLAYER)
            break;
        obj = obj->prev;
    }

    // print info
    vector<string> player_info;
    player_info.push_back("GUID: " + to_string(obj->guid));
    player_info.push_back("Name: " + string(obj->name));
    player_info.push_back("Type: " + to_string(obj->type));
    player_info.push_back("X: " + to_string(obj->pos_x));
    player_info.push_back("Y: " + to_string(obj->pos_y));
    player_info.push_back("Z: " + to_string(obj->pos_z));
    player_info.push_back("Rotation: " + to_string(obj->rotation));
    player_info.push_back("HP: " + to_string(obj->hp_curr) + "/" + to_string(obj->hp_max));
    player_info.push_back("Mana: " + to_string(obj->mana_curr) + "/" + to_string(obj->mana_max));
    player_info.push_back("Level: " + to_string(obj->level));
    player_info.push_back("ObjType: " + to_string(obj->obj_type));
    for (int i = 0; i < player_info.size(); i++)
    {
        cout << player_info[i] << endl;
    }

    // pause
    system("pause");
}