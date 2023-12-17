const fs = require("fs");
const path = require("path");

defaultContext = {};

module.exports = {
  /**
   * 获取文件列表
   */
  async getFileList(dirName) {
    let dirPath = path.join(__dirname, "../../data/" + dirName + "/");
    let fileList = [];
    // await fs.readdir(dirPath, async (err, files) => {
    //   if (err) {
    //     console.log(err);
    //     return;
    //   } else {
    //     for (const file of files) {
    //       fileList.push(file);
    //     }
    //     return fileList;
    //   }
    // });
    var readDir = fs.readdirSync(dirPath);
    for (file of readDir) {
      var name = file.replace(".json", "");
      fileList.push(name);
    }
    return fileList;
  },

  /**
   * 上传文件
   */
  async uploadFile(dirName, fileName, file) {
    const reader = fs.createReadStream(file.filepath);
    let filePath = path.join(__dirname, "data/" + dirName + "/" + fileName);
    const upStream = fs.createWriteStream(filePath);
    reader.pipe(upStream);
  },

  /**
   * 在指定位置创建文件并写入内容
   * 如果已创建则只写入
   */
  async writeFile(dirName, fileName, context) {
    // 初始化文件夹
    var existFolder = await fs.existsSync("../data/" + dirName);
    if (!existFolder) {
      fs.mkdirSync("../data/" + dirName);
    }

    try {
      fs.writeFileSync(
        "../data/" + dirName + "/" + fileName + ".json",
        JSON.stringify(context)
      );
      return true;
    } catch (err) {
      return false;
    }
  },

  /**
   * 判断文件是否存在
   */
  async isFileExist(dirName, fileName) {
    var bool = fs.existsSync("../data/" + dirName + "/" + fileName + ".json");
    return bool;
  },

  /**
   * 读取JSON中的对象
   */
  async readFile(dirName, fileName) {
    // 用户存在
    var fileExist = fs.existsSync(
      "../data/" + dirName + "/" + fileName + ".json"
    );
    if (!fileExist) {
      return false;
    }

    // 读取内容
    var context = await fs.readFileSync(
      "../data/" + dirName + "/" + fileName + ".json"
    );
    return JSON.parse(context);
  },
};
