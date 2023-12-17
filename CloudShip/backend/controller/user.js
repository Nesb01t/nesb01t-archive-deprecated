const fileUtils = require("../utils/file");

class UserController {
  constructor() { }
  /**
   * 更新用户数据
   */
  async updateUserInfo(ctx) {
    const body = ctx.request.body;
    // 存在用户
    if (!await isUserRegistered(body.id)) {
      ctx.states = 400;
      ctx.body = "user not found";
      return;
    }

    // 修改用户属性
    const user = await fileUtils.readFile("user", body.id);
    Object.assign(user, body);

    // 存储
    const success = await fileUtils.writeFile("user", body.id, user);
    if (success) {
      ctx.status = 200;
      ctx.body = "update user info success";
    } else {
      ctx.states = 400;
      ctx.body = "update user info failed";
    }
  }

  /**
   * 创建头像文件
   */
  async updateUserProfile(ctx) {
    const file = ctx.request.files.profile;
    const body = ctx.request.body;

    // 存在用户且文件有效
    if (!await isUserRegistered(body.id)) {
      ctx.states = 400;
      ctx.body = "user not found";
      return;
    }
    if (file) {
      ctx.status = 200;
      ctx.body = "update user profile success";
    }
    // 修改用户属性
    const user = await fileUtils.readFile("user", body.id);
    const profileObj = {
      "profile": file.newFilename
    }
    Object.assign(user, profileObj);

    // 存储
    const success = await fileUtils.writeFile("user", user.id, user);
    if (success) {
      ctx.status = 200;
      ctx.body = "update user profile success";
    } else {
      ctx.states = 400;
      ctx.body = "update user profile failed";
    }
    // await fileUtils.uploadFile("profile", file.newFilename, file);
  }

  /**
   * 获取用户数据
   */
  async getUserInfo(ctx) {
    const body = ctx.query;
    const userId = body.id;
    const user = await fileUtils.readFile("user", userId);
    if (user == false) {
      ctx.status = 400;
      ctx.body = "cant find user";
    }
    delete user.password;
    ctx.body = JSON.stringify(user);
  }

  /**
   * 获取用户列表
   */
  async getUserList(ctx) {
    const userList = await fileUtils.getFileList("user");
    const itemList = [];
    for (const userId of userList) {
      const user = await fileUtils.readFile("user", userId);
      if (user.states !== undefined) {
        if (user.states.name !== undefined) {
          itemList.push({ id: userId, name: user.states.name })
        }
      }
    }

    if (userList == false) {
      ctx.status = 400;
      ctx.body = "no user list";
    }
    ctx.status = 200;
    console.log(itemList);
    ctx.body = JSON.stringify(itemList);
  }
}

/**
 * 用户是否注册
 */
async function isUserRegistered(userId) {
  return fileUtils.isFileExist("user", userId);
}

module.exports = UserController;
