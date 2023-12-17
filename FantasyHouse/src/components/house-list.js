import InfiniteScroll from "react-infinite-scroll-component";
import { Card, List, Button } from "antd";
import React, { useState } from "react";
const { Meta } = Card;

function HouseList(props) {
  // Style

  const mainStyle = {
    display: "flex",
    border: "1px solid rgba(140, 140, 140, 0.35)",
  };
  const listViewStyle = {
    width: "210px",
    height: "730px",
    marginRight: "20px",
    overflowY: "auto",
    overflowX: "hidden",
    scrollbarWidth: "thin",
    scrollbarColor: "#c8c8c8 transparent",
  };
  const cardViewStyle = {
    margin: "10px",
    height: "710px",
    width: "800px",
  };

  // List
  const houseList = props.data;
  const dataSource = houseList.map((i) => {
    return {
      title: i,
    };
  });

  // Card
  const urls = {
    "海雾村1-30": "https://pic.imgdb.cn/item/64d629941ddac507cc4ff5a2.jpg",
    "海雾村31-60": "https://pic.imgdb.cn/item/64d629891ddac507cc4fd335.jpg",
    "薰衣草苗圃1-30": "https://pic.imgdb.cn/item/64d6298d1ddac507cc4fde3d.jpg",
    "薰衣草苗圃31-60": "https://pic.imgdb.cn/item/64d6298d1ddac507cc4fdee2.jpg",
    "高脚孤丘1-30": "https://pic.imgdb.cn/item/64d629941ddac507cc4ff46b.jpg",
    "高脚孤丘31-60": "https://pic.imgdb.cn/item/64d629941ddac507cc4ff4ee.jpg",
    "白银乡1-30": "https://pic.imgdb.cn/item/64d629931ddac507cc4ff20f.jpg",
    "白银乡31-60": "https://pic.imgdb.cn/item/64d629931ddac507cc4ff383.jpg",
    "穹顶皓天1-30": "https://pic.imgdb.cn/item/64d6298b1ddac507cc4fd909.png",
    "穹顶皓天31-60": "https://pic.imgdb.cn/item/64d6298d1ddac507cc4fdda8.png",
  };
  const [cardData, setCardData] = useState({
    message: "选择服务器获取房屋列表后，点击这里查看具体房屋信息",
  });
  const handleClick = (raw) => {
    let data = raw.match(/([^\d]+)([0-9]+)区([0-9]+)号([A-Z]+)房/);
    let area = data[1];
    let slot = data[2];
    let location = data[3];
    let size = data[4];
    let card = {};

    card.title = raw;
    card.discription = "房屋描述功能仍在更新中...";
    if (location <= 30) {
      card.pictureURL = urls[area + "1-30"];
    } else {
      card.pictureURL = urls[area + "31-60"];
    }
    setCardData(card);
    console.log(data, card);
  };

  return (
    <div style={mainStyle}>
      <InfiniteScroll dataLength={houseList.length} style={listViewStyle}>
        <List
          size="small"
          itemLayout="horizontal"
          dataSource={dataSource}
          renderItem={(item, index) => (
            <List.Item
              style={{ margin: "0px", padding: "5 0 0 10px" }}
              onClick={() => handleClick(item.title)}
            >
              <List.Item.Meta
                title={
                  <Button type="text" style={{ marginLeft: "2px" }}>
                    {item.title}
                  </Button>
                }
              ></List.Item.Meta>
            </List.Item>
          )}
        ></List>
      </InfiniteScroll>
      <Card
        style={cardViewStyle}
        cover={
          cardData.pictureURL !== undefined && (
            <img
              alt="未找到图床"
              src={cardData.pictureURL}
              style={{ maxHeight: "615px" }}
            ></img>
          )
        }
      >
        <Meta title={cardData.title} description={cardData.discription} />
      </Card>
    </div>
  );
}

export default HouseList;
