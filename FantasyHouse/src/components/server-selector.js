import React, { useState } from "react";
import { Button, Dropdown, message } from "antd";
import { DownOutlined, SmileOutlined } from "@ant-design/icons";
import serverTrans from "../unit/server-trans.js";

const items = Object.keys(serverTrans.dataCentreList).map((i) => ({
  key: serverTrans.dataCentreList[i],
  label: serverTrans.dataCentreList[i],
  children: Object.keys(serverTrans.serverList[i]).map((j) => ({
    key: serverTrans.serverList[i][j],
    label: serverTrans.serverList[i][j],
  })),
}));

function ServerSelector({ onSelect }) {
  const [selected, setSelected] = useState("红茶川");

  const onClick = ({ key }) => {
    setSelected(key);
    onSelect(key);
  };

  return (
    <div>
      <Dropdown arrow menu={{ items, onClick }}>
        <a onClick={(e) => e.preventDefault()}>
          <Button type="link" style={{ "marginLeft": "8px" }}>
            {selected}
            <DownOutlined></DownOutlined>
          </Button>
        </a>
      </Dropdown>
    </div>
  );
}

export default ServerSelector;
