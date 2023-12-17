#define O_base (0x400000) // 基地址

#define O_player_guid (0x741E30)          // 玩家的全局唯一标识符地址
#define O_target_guid (0x74E2d8)          // 目标的全局唯一标识符地址
#define O_is_ingame (0xB4B424)            // 游戏是否处于运行状态的地址
#define O_last_hardware_action (0xCF0BC8) // 最后一次硬件操作的时间戳地址

#define O_obj_mgr_curr (0x00741414) // 当前对象管理器地址
#define O_obj_mgr_off (0xAC)        // 对象管理器偏移量
#define O_obj_mgr_next (0x3C)       // 下一个对象管理器地址的偏移量
#define O_obj_mgr_first (0xAC)      // 第一个对象管理器地址的偏移量
#define O_obj_mgr_local_guid (0xC0) // 本地对象管理器的全局唯一标识符地址

#define O_wow_obj_data_ptr (0x8)                // WoW对象数据指针地址的偏移量
#define O_wow_obj_type (0x14)                   // WoW对象类型地址的偏移量
#define O_wow_obj_guid (0x30)                   // WoW对象全局唯一标识符地址的偏移量
#define O_wow_obj_pos_y (0x9B8)                 // WoW对象纵坐标地址的偏移量
#define O_wow_obj_pos_x (O_wow_obj_pos_y + 0x4) // WoW对象横坐标地址的偏移量
#define O_wow_obj_pos_z (O_wow_obj_pos_y + 0x8) // WoW对象高度坐标地址的偏移量
#define O_wow_obj_rotation \
  (O_wow_obj_pos_x + 0x10)              // WoW对象旋转角度地址的偏移量
#define O_wow_obj_movementflags (0x9E8) // WoW对象移动标志地址
#define O_wow_obj_speed (0xA34)         // WoW对象速度地址

#define O_wow_gameobj_pos_y (0x2C4) // WoW游戏对象纵坐标地址的偏移量
#define O_wow_gameobj_pos_x \
  (O_wow_gameobj_pos_y + 0x4) // WoW游戏对象横坐标地址的偏移量
#define O_wow_gameobj_pos_z \
  (O_wow_gameobj_pos_y + 0x8) // WoW游戏对象高度坐标地址的偏移量

#define O_wow_unit_charm (0x18)  // WoW单位被控制的标志地址的偏移量
#define O_wow_unit_summon (0x20) // WoW单位召唤物的标志地址的偏移量
#define O_wow_unit_charmedby \
  (0x28) // WoW单位控制该单位的单位的全局唯一标识符地址的偏移量
#define O_wow_unit_summonedby \
  (0x30) // WoW单位召唤该单位的单位的全局唯一标识符地址的偏移量
#define O_wow_unit_createdby \
  (0x38)                         // WoW单位创建该单位的单位的全局唯一标识符地址的偏移量
#define O_wow_unit_target (0x40) // WoW单位当前目标的全局唯一标识符地址的偏移量
#define O_wow_unit_channelobject \
  (0x50)                            // WoW单位引导法术的对象的全局唯一标识符地址的偏移量
#define O_wow_unit_hp_curr (0x58)   // WoW单位当前生命值地址的偏移量
#define O_wow_unit_mana_curr (0x5C) // WoW单位当前法力值地址的偏移量
#define O_wow_unit_hp_max (0x70)    // WoW单位最大生命值地址的偏移量
#define O_wow_unit_mana_max (0x74)  // WoW单位最大法力值地址的偏移量
#define O_wow_unit_level (0x88)     // WoW单位等级地址

#define O_wow_unitname_objname1 \
  (0x214) // WoW单位名称的第一个部分（对象名称）地址的偏移量
#define O_wow_unitname_objname2 \
  (0x8)                                 // WoW单位名称的第二个部分（对象名称）地址的偏移量
#define O_wow_unitname_itemtype (0x2DC) // WoW单位名称的物品类型地址的偏移量
#define O_wow_unitname_unitname1 \
  (0xB30) // WoW单位名称的第一个部分（单位名称）地址的偏移量