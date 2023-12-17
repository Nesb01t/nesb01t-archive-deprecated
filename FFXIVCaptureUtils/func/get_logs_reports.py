import requests

url = 'https://cn.fflogs.com:443/v1/reports/user/nesb01t?api_key=865d42a53607f4927c0e19c8529ea86b'

res = requests.get(url=url)
text = res.json()
print(text)