import requests

url = "http://www.kfc.com.cn/kfccda/ashx/GetStoreList.ashx?op=cname"
params = {
    'cname': '杭州',
    'pid': '',
    'pageIndex': '1',
    'pageSize': '101',
}
headers = {
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36 Edg/115.0.1901.183'
}

res = requests.get(url=url, params=params, headers=headers)
res_json = res.json()
table = res_json['Table1']
for i in table:
    print(i['storeName'])