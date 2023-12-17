from bs4 import BeautifulSoup

# 加载本地


def native_soup(filePath):
    filePath = '../index.html'
    fp = open(filePath, 'r', encoding='utf-8')
    soup = BeautifulSoup(fp, 'lxml')
    print(soup)

# 加载互联网


def internet_soup(response):
    page_text = response.text
    soup = BeautifulSoup(page_text, 'lxml')
