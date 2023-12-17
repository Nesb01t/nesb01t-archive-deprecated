# Hello, dalamud!

一个简单的插件案例

## Main Points

* 具有简单功能的插件
  * Slash 指令
  * 主要 UI
  * 设置 UI
  * 图片加载
  * 支持 json
* 简单地进行插件配置
* 项目组成
  * 复制所有必须的插件到 output 文件夹
    * 不要复制卫月提供的依赖
    * 输出文件夹可以被直接压缩，确保真正需要的插件都在里面
  * VS 中隐藏 data 文件减少冗余
    * 允许将 data 文件放在非通常VS默认的路径

展示类似的事情是如何做到的

## 如何使用
### 构建

1. 用 VS 或 Rider 打开 `SamplePlugin.sln`
2. 构建解决方案. 默认将会进行 `Debug` 构建, 你也可以在 IDE 切换到 `Release`
3. 构建结果将在 `SamplePlugin/bin/x64/Debug/SamplePlugin.dll` (或 `Release`)

### 在游戏中使用

1. 启动游戏并输入 `/xlsettings` 或者输入 `xlsettings` 在卫月控制台(Dalamod Console) 以打开卫月的插件管理器
    * 在这里点击 `实验性(Experimental)`, 添加 `SamplePlugin.dll` 的绝对路径到 Dev Plugins 里面去
2. 接下来在聊天框输入 `/xlplugins` 或者 `xlplugins` (卫月控制台) 打开插件安装器
    * 在这里进入 `Dev Tools > Installed Dev Plugins`, 此时将会看见 `SamplePlugin`, 启动它
3. 你将可以使用 `/pmycommand` (聊天) 或者 `pmycommand` (控制台)!

### 为你自己的用途重新配置

基础地, 只是替换所有依赖 `SamplePlugin` 在所有文件夹和文件名字中

Dalamud 会加载所有 json 数据 (默认的, `SamplePlugin/SamplePlugin.json`) 在你的 dll 旁边作为 metadata, 包括插件描述等等. 确保更新你的插件的相关信息!
