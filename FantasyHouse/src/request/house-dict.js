/// 地区
var area_dict = {
  海雾村: "0",
  薰衣草苗圃: "1",
  高脚孤丘: "2",
  白银乡: "3",
  穹顶皓天: "4",
};

/// 服务器
var server_dict = {
  // 陆行鸟
  红玉海: "1167",
  神意之地: "1081",
  拉诺西亚: "1042",
  幻影群岛: "1044",
  萌芽池: "1060",
  宇宙和音: "1173",
  沃仙曦染: "1174",
  晨曦王座: "1175",

  // 莫古力
  白银乡: "1172",
  白金幻象: "1076",
  神拳痕: "1171",
  潮风亭: "1170",
  旅人栈桥: "1113",
  拂晓之间: "1121",
  龙巢神殿: "1166",
  梦羽宝境: "1175",

  // 猫小胖
  紫水栈桥: "1043",
  延夏: "1169",
  静语庄园: "1106",
  摩杜纳: "1045",
  海猫茶屋: "1177",
  柔风海湾: "1178",
  琥珀原: "1179",

  // 豆豆柴
  水晶塔: "1192",
  银泪湖: "1183",
  太阳海岸: "1180",
  伊修加德: "1186",
  红茶川: "1201",
};

/// 房屋类型
var size_dict = {
  S: "0",
  M: "1",
  L: "2",
};

/// 获取地区对应 index
function getAreaByIndex(index) {
  for (let i in area_dict) {
    if (index.toString() === area_dict[i]) {
      return i;
    }
  }
}

/// 获取服务区对应 index
function getSizeByIndex(index) {
  for (let i in size_dict) {
    if (index.toString() === size_dict[i]) {
      return i;
    }
  }
}

export var HouseDict = {
  server_dict,
  size_dict,
  getAreaByIndex,
  getSizeByIndex,
};
