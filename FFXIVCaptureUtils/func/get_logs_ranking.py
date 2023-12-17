import requests
import time
from datetime import datetime

user_name = '圣光夹心饼干'
api_key = '865d42a53607f4927c0e19c8529ea86b'
url = 'https://cn.fflogs.com:443/v1/parses/character/' + \
    user_name + '/红玉海/CN?zone=43&api_key=' + api_key
res = requests.get(url=url)


text = res.json()
for i in text:
    dungeonName = i["encounterName"]
    instanceSpec = i["spec"]
    startTime = i["startTime"]
    startTimeDate = datetime.fromtimestamp(startTime / 1000)
    instanceRank = i["percentile"]
    instancePath = i["ilvlKeyOrPatch"]
    print(dungeonName, instancePath, instanceRank, instanceSpec, startTimeDate)
