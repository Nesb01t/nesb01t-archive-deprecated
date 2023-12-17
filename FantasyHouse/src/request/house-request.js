import axios from "axios";
import { HouseDict } from "./house-dict.js";

async function getHouseList(queryServer) {
  // 生成请求 url
  const SERVER = HouseDict.server_dict[queryServer];
  const TS = "00000000";
  const url =
    "https://house.ffxiv.cyou/api/sales?server=" + SERVER + "&ts=" + TS;

  const res = await axios.get(url);
  const resJson = res.data;
  const houseList = [];
  let auctioningTime;
  for (let i of resJson) {
    const area = HouseDict.getAreaByIndex(i.Area); // 区域
    const slot = i.Slot + 1; // 几区
    const location = i.ID; // 号码
    const size = HouseDict.getSizeByIndex(i.Size); // 房型
    if (i.EndTime > 0) auctioningTime = i.EndTime;
    houseList.push(area + slot + "区" + location + "号" + size + "房");
  }
  let date = new Date(auctioningTime * 1000);
  let dateString = "推测数据尚不牢靠, 请您进入游戏查看~";
  return { houseList, dateString };
}

export default getHouseList;
