const path = require("path");
const { app, BrowserWindow } = require("electron");

let mainWindow;

function createWindow() {
  mainWindow = new BrowserWindow({
    width: 1055,
    height: 900,
    resizable: false,
    webPreferences: {
      nodeIntegration: true,
    },
    autoHideMenuBar: true,
    opacity: 0.95
  });
  // mainWindow.loadURL("http://localhost:3000");
  // mainWindow.openDevTools();
  mainWindow.loadFile(`${__dirname}/build/index.html`);
}

app.on("ready", createWindow);
app.on("window-all-closed", function () {
  if (process.platform !== "darwin") {
    app.quit();
  }
});
app.on("activate", function () {
  if (mainWindow === null) {
    createWindow();
  }
});
