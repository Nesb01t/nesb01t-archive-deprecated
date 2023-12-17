const { writeFile } = require("../utils/file");
const fileUtils = require("../utils/file");
const validateUtils = require("../utils/validate");

class AuthController {
  constructor() { }
  /**
   * 登录注册
   */
  async userLogin(ctx) {
    const body = ctx.request.body;
    const userId = body.id;
    const userPassword = body.password;

    // 判断ID和密码是否合法
    if (userId == undefined) {
      ctx.status = 400;
      ctx.body = "user id undefined";
      return;
    }
    if (!validateUtils.isTwelveDigits(userId)) {
      ctx.status = 400;
      ctx.body = "user id invalid";
      return;
    }
    if (userPassword == undefined) {
      ctx.status = 400;
      ctx.body = "user password undefined";
      return;
    }

    // 是否需要注册
    var userRegistered = await isUserRegistered(userId);
    if (!userRegistered) {
      userRegister(userId, userPassword);
      ctx.status = 200;
      ctx.body = "creating new account";
      return;
    }

    // 是否密码错误
    var user = await fileUtils.readFile("user", userId);
    if (userPassword !== user.password) {
      ctx.status = 400;
      ctx.body = "wrong password";
      return;
    } else {
      ctx.status = 200;
      ctx.body = "login success!";
      return;
    }
  }
}

/**
 * 用户是否注册
 */
async function isUserRegistered(userId) {
  return fileUtils.isFileExist("user", userId);
}

/**
 * 用户注册入库
 */
async function userRegister(userId, userPassword) {
  var fileContext = { id: parseInt(userId), password: userPassword };
  writeFile("user", userId, fileContext);
  console.log(fileContext);
}

module.exports = AuthController;
