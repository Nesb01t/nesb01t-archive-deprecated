import requests

URL = 'https://www.baidu.com/'
HEADER = {
    'User-Agent': "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36 Edg/115.0.1901.183"
}

response = requests.get(url=URL, headers=HEADER)
page_text = response.text
with open('../index.html', 'w', encoding='utf-8') as file:
    file.write(page_text)
