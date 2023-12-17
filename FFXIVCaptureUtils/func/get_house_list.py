import requests
import dictionary as dict

query_intro = '红茶川'

# 生成接口请求
SERVER = dict.server_dict[query_intro]
TS = '00000000'
url = 'https://house.ffxiv.cyou/api/sales?server=' + SERVER + '&ts=' + TS
res = requests.get(url=url)
res_json = res.json()

# 遍历房屋条目
for i in res_json:
    area = dict.getAreaByIndex(i['Area'])  # 区域
    slot = i['Slot'] + 1  # 几区
    location = i['ID']  # 号码
    size = dict.getSizeByIndex(i['Size'])  # 房型

    # log
    print(area, slot, "区", location, "号", size, '房')
