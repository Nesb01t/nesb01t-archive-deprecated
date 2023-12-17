import requests

# 最终组成的 URL
URL = 'https://fanyi.baidu.com/#zh/en/%E4%BD%A0%E5%A5%BD'

# 生成或设定的 HEADER
HEADER = {
    'User-Agent': "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36 Edg/115.0.1901.183"
}

def run(url=URL, header=HEADER):
    response = requests.get(url=URL, headers=HEADER)
    page_text = response.text
    return page_text