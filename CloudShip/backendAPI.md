### 1. Auth - 用户注册登录

> URL - http://localhost:3000/auth/login
>
> HTTP 请求方式 - POST
>
> | 参数     | 必选 | 类型    | 说明    |
> | :------- | :--- | :------ | :------ |
> | id       | true | integer | 用户 ID |
> | password | true | string  | 密码    |

### 2. User - 用户信息更新

> URL - http://localhost:3000/user/update
>
> HTTP 请求方式 - POST
>
> | 参数     | 必选  | 类型    | 说明                 |
> | :------- | :---- | :------ | :------------------- |
> | id       | true  | integer | 用户 ID              |
> | password | false | string  | 密码                 |
> | states   | false | object  | 包含自定义参数的对象 |

### 3. User - 用户信息获取

> URL - http://localhost:3000/user/info?id
>
> HTTP 请求方式 - GET
>
> | 参数 | 必选 | 类型    | 说明    |
> | :--- | :--- | :------ | :------ |
> | id   | true | integer | 用户 ID |

### 4. User - 用户列表获取

> URL - http://localhost:3000/user/list
>
> HTTP 请求方式 - GET
>
> | 参数 | 必选 | 类型 | 说明 |
> | :--- | :--- | :--- | :--- |
> | /    | /    | /    | /    |

### 5. User - 上传用户头像

> URL - http://localhost:3000/user/profile
>
> HTTP 请求方式 - POST
>
> | 参数    | 必选 | 类型           | 说明       |
> | :------ | :--- | :------------- | :--------- |
> | profile | true | form-data File | 上传的文件 |

### 6. Undefined - 用户特殊备注

> 计划中...
