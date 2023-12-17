#pragma once
#include "../constants/enum.h"
#include "../constants/offset.h"
#include "memory.cpp"
#include <iostream>
#include <windows.h>

using namespace std;

struct Object;
struct Object
{
    UINT64 guid;            // 对象的唯一标识符
    UINT64 summoned_by;     // 召唤该对象的对象的唯一标识符
    FLOAT pos_x;            // 对象的 X 坐标
    FLOAT pos_y;            // 对象的 Y 坐标
    FLOAT pos_z;            // 对象的 Z 坐标
    FLOAT rotation;         // 对象的旋转角度
    MemPtr base_addr;       // 对象的基址
    MemPtr unitfields_addr; // 对象的单位字段地址
    UINT16 type;            // 对象的类型
    char name[50];          // 对象的名称

    UINT32 hp_curr;   // 当前生命值
    UINT32 hp_max;    // 最大生命值
    UINT32 mana_curr; // 当前法力值
    UINT32 mana_max;  // 最大法力值
    UINT32 level;     // 对象的等级

    UINT32 obj_type; // 对象的类型

    struct Object *prev; // 上一个对象的指针
};

MemPtr player_base = (MemPtr)0;
UINT64 player_guid = 0;

struct Object *GetObjects(HANDLE hProcess)
{
    player_guid = ReadMemory64(hProcess, O_base + O_player_guid); // GUID

    // 读取第一个对象的指针
    MemPtr ptr_obj_first =
        ReadMemoryPtr(hProcess, ReadMemoryPtr(hProcess, O_base + O_obj_mgr_curr) +
                                    O_obj_mgr_off);

    MemPtr obj_base_addr = ptr_obj_first; // 保存第一个对象的指针作为基址

    struct Object *obj_cur = NULL;                         // 初始化一个对象 obj_cur
    while (obj_base_addr != 0 && (obj_base_addr % 2 == 0)) // 基址不为 0 且为偶数
    {
        // 分配一个新的对象结构体 obj_new
        struct Object *obj_new = (struct Object *)calloc(1, sizeof(struct Object));
        obj_new->prev = obj_cur; // 使新的对象结构体的 prev 成员指向上一个对象结构体

        // 将 obj_new 赋值给 obj_cur
        // 表示当前对象为 obj_new
        obj_cur = obj_new;

        obj_cur->base_addr = obj_base_addr; // 设置 base_addr 成员为 当前对象的基址
        obj_cur->guid = ReadMemory64(hProcess, obj_cur->base_addr + O_wow_obj_guid);
        obj_cur->type = ReadMemory16(hProcess, obj_cur->base_addr + O_wow_obj_type);

        switch (obj_cur->type) // 根据对象类型进行不同处理
        {
        case O_T_UNIT:   // 单位
        case O_T_PLAYER: // 玩家
            obj_cur->unitfields_addr =
                ReadMemoryPtr(hProcess, obj_cur->base_addr + O_wow_obj_data_ptr);
            obj_cur->hp_curr =
                ReadMemory32(hProcess, obj_cur->unitfields_addr + O_wow_unit_hp_curr);
            obj_cur->hp_max =
                ReadMemory32(hProcess, obj_cur->unitfields_addr + O_wow_unit_hp_max);
            obj_cur->summoned_by = ReadMemory64(hProcess, obj_cur->unitfields_addr +
                                                              O_wow_unit_summonedby);
            obj_cur->level =
                ReadMemory64(hProcess, obj_cur->unitfields_addr + O_wow_unit_level);

            obj_cur->pos_x =
                ReadMemoryFloat(hProcess, obj_cur->base_addr + O_wow_obj_pos_x);
            obj_cur->pos_y =
                ReadMemoryFloat(hProcess, obj_cur->base_addr + O_wow_obj_pos_y);
            obj_cur->pos_z =
                ReadMemoryFloat(hProcess, obj_cur->base_addr + O_wow_obj_pos_z);
            obj_cur->rotation =
                ReadMemoryFloat(hProcess, obj_cur->base_addr + O_wow_obj_rotation);

            switch (obj_cur->type)
            {
            case O_T_UNIT: // 单位
                ReadProcessMemory(
                    hProcess,
                    (LPCVOID)ReadMemoryPtr(
                        hProcess,
                        ReadMemoryPtr(hProcess,
                                      obj_cur->base_addr + O_wow_unitname_unitname1)),
                    obj_cur->name, sizeof(obj_cur->name), NULL);
                break;
            case O_T_PLAYER: // 玩家
                if (player_guid == obj_cur->guid)
                {
                    player_base = obj_cur->base_addr;
                    player_guid = obj_cur->guid;
                }
                ReadProcessMemory(
                    hProcess,
                    (LPCVOID)ReadMemoryPtr(
                        hProcess,
                        ReadMemoryPtr(hProcess,
                                      obj_cur->base_addr + O_wow_unitname_objname1)),
                    obj_cur->name, sizeof(obj_cur->name), NULL);
                break;
            }
            break;

        case O_T_GAMEOBJ: // 游戏对象
            obj_cur->pos_x =
                ReadMemoryFloat(hProcess, obj_cur->base_addr + O_wow_gameobj_pos_x);
            obj_cur->pos_y =
                ReadMemoryFloat(hProcess, obj_cur->base_addr + O_wow_gameobj_pos_y);
            obj_cur->pos_z =
                ReadMemoryFloat(hProcess, obj_cur->base_addr + O_wow_gameobj_pos_z);

            obj_cur->unitfields_addr =
                ReadMemoryPtr(hProcess, obj_cur->base_addr + O_wow_obj_data_ptr);
            // 读取游戏对象的名称
            ReadProcessMemory(
                hProcess,
                (LPCVOID)(ReadMemory32(
                    hProcess, (ReadMemory32(hProcess, (obj_cur->base_addr +
                                                       O_wow_unitname_objname1)) +
                               O_wow_unitname_objname2))),
                obj_cur->name, sizeof(obj_cur->name), NULL);
                
            obj_cur->type =
                ReadMemory32(hProcess, obj_cur->base_addr + O_wow_unitname_itemtype);

            break;
        }

        // 获取下一个对象的地址
        obj_base_addr =
            ReadMemoryPtr(hProcess, obj_cur->base_addr + O_obj_mgr_next);
    }

    return obj_cur;
}
void DelObjects(struct Object *obj);