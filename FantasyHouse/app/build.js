const path = require("path");
const builder = require("electron-builder");

builder
  .build({
    projectDir: path.resolve(__dirname),
    win: ["portable", "nsis"], // portable 為 Windows 的免安裝程式，nsis 為安裝程式
    config: {
      appId: "com.nesb01t.electron", // 應用程式 ID
      productName: "FantasyHouseCN", // 應用程式名稱
      copyright: "MIT", // 授權宣告
      directories: {
        output: "release",
      },
      win: {
        icon: path.resolve(__dirname, "icon.png"), // 設定打包後的 icon
        target: "nsis",
      },
      nsis: {
        oneClick: false,
      },
      files: ["build/**/*", "main.js"],
      extends: null,
    },
  })
  .then(
    (data) => console.log(data),
    (err) => console.error(err)
  );
