import func.get_page as getPage
import requests

firstLang = 'zh'
targetLang = 'en'
words = '你好吗wow'

# URL = 'https://fanyi.baidu.com/#' + firstLang + '/' + targetLang + '/' + words
POST_URL = 'https://fanyi.baidu.com/v2transapi'
HEADER = {
    'User-Agent': "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36 Edg/115.0.1901.183"
}
DATA = {
    'from': 'zh',
    'to': 'en',
    'query': words,
    'transtype': 'realtime',
    'simple_means_flag': 3,
    'sign': '40917.294116',
    'token': '7f02c70cf155b0de760e2a6448967858',
    'domain': 'common',
    'ts': '1690167678346'
}
response = requests.post(url=POST_URL, data=DATA, headers=HEADER)
print(response.json())
