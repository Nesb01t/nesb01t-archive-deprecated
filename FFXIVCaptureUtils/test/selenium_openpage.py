from selenium import webdriver
import time

driver = webdriver.Edge()
driver.get('file:///E:\FFXIVHouseCapture\index.html')
time.sleep(3)
driver.close()