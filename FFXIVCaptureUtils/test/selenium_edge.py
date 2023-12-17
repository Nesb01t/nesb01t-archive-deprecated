from selenium import webdriver
import time

def test():
    edge = webdriver.Edge()
    edge.get('https://househelper.ffxiv.cyou/#/')
    time.sleep(3)
    edge.quit()

test()