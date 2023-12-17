import React from "react";
import { Button, Dropdown, Space, Tag } from "antd";
import ServerSelector from "./server-selector.js";
import getHouseList from "../request/house-request.js";
import FilterTags from "./filter-tags.js";
import HouseList from "./house-list.js";

class HouseView extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      houseList: [], // 原始房屋列表
      filterOptions: [], // 筛选后房屋列表
      selectServer: "红茶川", // 选择服务器
      auctioningTime: "", // 买房时间点
    };
  }

  // 获取筛选后的列表
  getFilteredList = () => {
    let list = this.state.houseList;
    if (this.state.filterOptions.length === 0) return list;

    let ansList = [];
    for (let i in list) {
      if (
        this.state.filterOptions.every((substring) => {
          return list[i].includes(substring);
        })
      ) {
        ansList.push(list[i]);
      }
    }
    return ansList;
  };

  // 获取房屋数据
  handleClick = async () => {
    const res = await getHouseList(this.state.selectServer);
    this.setState((prevState) => ({
      houseList: res.houseList,
      auctioningTime: res.dateString,
    }));
  };

  // 选择 - 获取数据
  handleSelect = (selected) => {
    this.setState((prevState) => ({
      selectServer: selected,
    }));
    this.handleClick();
  };

  // 更新 getTags
  handleTags = (tags) => {
    this.setState((prevState) => ({
      filterOptions: tags,
    }));
  };

  render() {
    return (
      <div>
        {/* 选择区域 */}
        <div style={{ display: "flex", margin: "8px" }}>
          <ServerSelector onSelect={this.handleSelect}></ServerSelector>
          <Button type="dashed" onClick={this.handleClick}>
            刷新数据
          </Button>
          <Button
            type="dashed"
            onClick={(e) => {
              e.preventDefault();
            }}
            style={{ marginLeft: "8px" }}
            disabled
          >
            在下方点击 + 筛选条件, 有效的筛选条件例如: 红茶川 或 20区 或 20 或
            红
          </Button>
        </div>

        {/* 数据筛选区域 */}
        <div style={{ display: "flex", margin: "8px" }}>
          <FilterTags getTags={this.handleTags}></FilterTags>
        </div>

        {/* 数据展示区域 */}
        <div>
          <HouseList data={this.getFilteredList()}></HouseList>
        </div>

        <div style={{ margin: "15px", marginLeft: "20px", color: "darkgray", fontSize:"14px" }}>
          最近的买房时间: {this.state.auctioningTime}
        </div>
      </div>
    );
  }
}

export default HouseView;
