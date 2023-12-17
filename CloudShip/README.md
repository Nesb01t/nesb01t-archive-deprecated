<h1 align="center">CloudShip</h1>

<p align="center">🌥️ 轻量云端 Web/APP 社区，通过 Koa + Node.js 实现 json、csv 后端数据热更新，在多种平台开箱即用(Web/PC/APP/小程序)</p>

<p align="center">如果遇到开发问题或者希望加入讨论，欢迎加入 QQ群 602399584</p>

---

### 如果遇到任何问题(按照推荐程度优先级排序)

1. 在 [Github](https://github.com/Nesb01t/CloudShip/issues/new) 提交新的 Issue
2. 加入 QQ 群 602399584 和开发者面对面反馈问题

### 如果你想要参与开发，则需要如下几点额外需求

1. 前端：对 vue2, uni-app 以及 uView 的基本了解，要了解更多相关信息请看 [【Vue.js 官方】](https://cn.vuejs.org/guide/introduction.html) [【uni-app 手册】](https://uniapp.dcloud.net.cn/) [【uView 手册】](https://xuqu.gitee.io/components/intro.html)
2. 后端：对 Koa 以及 node.js 的基础运用，要了解更多相关信息请看 [【Koa 文档】](https://koa.bootcss.com/) [【node.js API】](https://nodejs.org/api/)
3. 具有不依赖文档阅读代码的能力

### 开发环境配置

1. 克隆本项目
2. 后端配置：
   1. 进入目录 `backend`
   2. 执行 `npm install` 安装依赖库
   3. 执行 `node main` 开启本地开发环境
3. 前端配置：
   1. 进入目录 `frontend`
   2. 执行 `npm install` 安装依赖库
   3. 使用 HBuilderX 载入项目并发布运行

### 项目版本控制须知

本项目采用一个简单的 Git 分支模型：当您在进行开发的时候，请基于`main`创建新的分支，**切勿**直接基于`master`或者`main`分支进行开发，新的分支格式**必须**遵循`dev/{qualifier}-{name}`，`{name}`**必须**是您的ID。

1. 如果新的代码包含的是*BUG 修复*，则`{qualifier}`**必须**为`Fix`，`{name}`**应当**为 BUG 的简要叙述
2. 如果新的代码包含的是*新功能*，则`{qualifier}`**必须**为`Feat`或者`Feature`，`{name}`**应当**为新特性的简要叙述
3. 如果新的代码是*重构或者代码质量提升*，则`{qualifier}`**必须**为`Refactor`，`{name}`**应当**为重构部分的简要叙述
4. 如果您的贡献包含不止一种上面提到的类型，则应当遵循和您的贡献最为相关的一项，并在 commit 信息中提及其他类型上的贡献
5. `master`分支**必须**当且仅当在新版本将要被发布的时候更新

在开发完成后，请在[【这里】](https://github.com/FTLIKON/EachStar/pulls)发布 Pull Request 请求合并到`dev/main`分支


### 无数据库化
#### 优点：

- 支持非编程从业者进行本来复杂的数据迁移；
- 通过序列化/逆序列化 (.json) 对象实现更健壮的代码环境；
- 可扩展性较强，容易维护数据一致性；
- 可选的外部工具查询和分析功能；

#### 缺点：

- 弱安全性和权限控制，容易遭到篡改甚至物理攻击；
- 数据量非常大时性能将会逐渐变弱；
