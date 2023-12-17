import React, { useEffect, useRef, useState } from "react";
import { HomeFilled } from "@ant-design/icons";
import { Space, Input, Tag, Tooltip, theme } from "antd";
const FilterTags = (props) => {
  const { getTags } = props;
  const { token } = theme.useToken();
  const [tags, setTags] = useState([]);
  const [inputVisible, setInputVisible] = useState(false);
  const [inputValue, setInputValue] = useState("");
  const [editInputIndex, setEditInputIndex] = useState(-1);
  const [editInputValue, setEditInputValue] = useState("");
  const inputRef = useRef(null);
  const editInputRef = useRef(null);

  // 输入焦点
  useEffect(() => {
    if (inputVisible) {
      inputRef.current?.focus();
    }
  }, [inputVisible]);

  // 编辑焦点
  useEffect(() => {
    editInputRef.current?.focus();
  }, [inputValue]);

  useEffect(() => {
    let savedTags = localStorage.getItem("tags");
    if (savedTags === null) savedTags = "[]";
    setTags(JSON.parse(savedTags));
    // setTags(savedTags);
  }, []);

  // tags 处理
  const saveTags = (newTags) => {
    setTags(newTags);
    getTags(newTags);
    localStorage.setItem("tags", JSON.stringify(newTags));
  };
  // tags 叉叉按钮
  const handleClose = (removedTag) => {
    const newTags = tags.filter((tag) => tag !== removedTag);
    saveTags(newTags);
  };

  // 输入框
  const showInput = () => {
    setInputVisible(true);
  };
  const handleInputChange = (e) => {
    setInputValue(e.target.value);
  };
  const handleInputConfirm = () => {
    if (inputValue && tags.indexOf(inputValue) === -1) {
      saveTags([...tags, inputValue]);
    }
    setInputVisible(false);
    setInputValue("");
  };
  const handleEditInputChange = (e) => {
    setEditInputValue(e.target.value);
  };
  const handleEditInputConfirm = () => {
    const newTags = [...tags];
    newTags[editInputIndex] = editInputValue;
    saveTags(newTags);
    setEditInputIndex(-1);
    setInputValue("");
  };

  // 样式
  const tagInputStyle = {
    width: 80,
    verticalAlign: "top",
    height: 30,
    fontSize: 14,
    display: "inline-flex",
    alignItems: "center",
  };
  const tagPlusStyle = {
    background: token.colorBgContainer,
    borderStyle: "bor",
    height: 30,
    fontSize: 14,
    display: "inline-flex",
    alignItems: "center",
  };
  const tagStyle = {
    userSelect: "none",
    height: 30,
    fontSize: 14,
    display: "inline-flex",
    alignItems: "center",
  };

  // renderer
  return (
    <Space size={[0, 8]} wrap style={{ marginLeft: 16 }}>
      <Space size={[0, 8]} wrap>
        {/* tags */}
        {tags !== null &&
          tags.map((tag, index) => {
            // 输入框
            if (editInputIndex === index) {
              return (
                <Input
                  ref={editInputRef}
                  key={tag}
                  size="middle"
                  style={tagInputStyle}
                  value={editInputValue}
                  onChange={handleEditInputChange}
                  onBlur={handleEditInputConfirm}
                  onPressEnter={handleEditInputConfirm}
                />
              );
            }
            const isLongTag = tag.length > 20;
            // tag 元素
            const tagElem = (
              <Tag
                key={tag}
                closable={true}
                bordered={false}
                style={tagStyle}
                onClose={() => handleClose(tag)}
              >
                {/* 编辑 */}
                <span
                  onDoubleClick={(e) => {
                    if (index !== 0) {
                      setEditInputIndex(index);
                      setEditInputValue(tag);
                      e.preventDefault();
                    }
                  }}
                >
                  {isLongTag ? `${tag.slice(0, 20)}...` : tag}
                </span>
              </Tag>
            );
            return isLongTag ? (
              <Tooltip title={tag} key={tag}>
                {tagElem}
              </Tooltip>
            ) : (
              tagElem
            );
          })}
      </Space>

      {/* 新增 */}
      {inputVisible ? (
        <Input
          ref={inputRef}
          type="text"
          size="middle"
          style={tagInputStyle}
          value={inputValue}
          onChange={handleInputChange}
          onBlur={handleInputConfirm}
          onPressEnter={handleInputConfirm}
        />
      ) : (
        <Tag style={tagPlusStyle} onClick={showInput}>
          <HomeFilled />
          <div style={{ margin: "3px" }}></div>添加筛选条件
        </Tag>
      )}
    </Space>
  );
};
export default FilterTags;
