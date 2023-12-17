#include "../services/process_helper.cpp"
#include "../services/command_line_ui.cpp"
#include "../lib/object_manager.cpp"
#include "../lib/memory.cpp"
#include <iostream>

using namespace std;

int main()
{
    // init ui & process
    CommandLineUI ui;
    ProcessHelper ph;
    ph.PrintHelper();

    while (true)
    {
        // get player
        struct Object *obj = GetObjects(ph.hProcess);
        while (obj->prev != NULL)
        {
            if (obj->guid == player_guid)
                break;
            obj = obj->prev;
        }

        // print info
        vector<string> info;
        info.push_back("=== LightBringers - Player Info Rader ===");
        info.push_back("ObjectGUID: " + to_string(obj->guid));
        // info.push_back("Name: " + string(obj->name));
        info.push_back("Type: " + to_string(obj->type));
        info.push_back("X: " + to_string(obj->pos_x));
        info.push_back("Y: " + to_string(obj->pos_y));
        info.push_back("Z: " + to_string(obj->pos_z));
        info.push_back("Rotation: " + to_string(obj->rotation));
        info.push_back("HP: " + to_string(obj->hp_curr) + "/" + to_string(obj->hp_max));
        info.push_back("Mana: " + to_string(obj->mana_curr) + "/" + to_string(obj->mana_max));
        info.push_back("Level: " + to_string(obj->level));
        info.push_back("ObjType: " + to_string(obj->obj_type));

        // cycle reset
        ui.Set(info);
        Sleep(10);
    }

    // end
    system("pause");
    return 0;
}