import requests
import json

url = "https://movie.douban.com/j/chart/top_list"
params = {
    'type': 17,
    'interval_id': '100:90',
    'action': '',
    'start': 0,  # 第几部电影开始取
    'limit': 101  # 一次请求的数量
}
headers = {
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36 Edg/115.0.1901.183'
}

res = requests.get(url=url, params=params, headers=headers)
res_json = res.json()
for i in res_json:
    first_region = i['regions'][0]
    if (first_region == '日本'):
        print(i['title'])

# 写入文件 douban.json
fp = open('./douban.json', 'w', encoding='utf-8')
json.dump(res_json, fp=fp, ensure_ascii=False)
