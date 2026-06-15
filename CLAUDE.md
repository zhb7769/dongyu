# CLAUDE.md — 东宇卫浴企业官网项目

## 项目概述

余姚市东宇卫浴制品有限公司企业官网，基于 **ASP.NET Web Forms (.NET Framework 4.0)** 构建的传统三层架构企业展示网站，含前台展示与后台管理。

## 技术栈

| 层级 | 技术 |
|------|------|
| 后端框架 | ASP.NET Web Forms (.NET Framework 4.0) |
| 语言 | C# |
| 数据库 | SQL Server |
| ORM | 无（原生 ADO.NET + DbHelperSQL） |
| 前端 JS | jQuery 1.9.1、Swiper.js、WOW.js |
| 富文本编辑 | FCKeditor.Net 2.6.3 |
| CSS | 原生 CSS + animate.css |

## 目录结构

```
dongyu/
├── App_Code/
│   ├── DBUtility/          # 数据库工具类（DbHelperSQL 等）
│   ├── DataAccess/         # 数据访问层（DAL）
│   └── Entity/             # 实体模型层（Model）
├── App_Data/               # 数据存储
├── admin/                  # 后台管理系统
├── bin/                    # 编译输出程序集
├── css/                    # 样式表
├── en/                     # 英文版页面
├── images/                 # 图片资源
├── js/                     # JavaScript 脚本
├── uploadfiles/            # 用户上传文件
├── UserControl/            # 自定义用户控件（分页器等）
├── MasterPage.master       # 母版页
├── Web.config              # 应用配置
└── dongyu.sln              # VS 解决方案文件
```

## 代码风格（参考 lindong 项目）

本项目代码风格与 `C:\project\lindong` 项目保持一致，遵循以下规范：

### 命名规范

| 类别 | 规则 | 示例 |
|------|------|------|
| 类名 | PascalCase | `Product`、`Admin`、`News` |
| 命名空间 | `NetWise.{层名}` | `NetWise.Entity`、`NetWise.DataAccess` |
| 公有属性 | PascalCase | `P_Id`、`CN_Name`、`EN_Name` |
| 私有字段 | 下划线 + camelCase | `_p_id`、`_cn_name` |
| 布尔属性 | `Is` 前缀 | `IsTop`、`IsPage` |
| 方法名 | PascalCase | `GetList()`、`Exists()`、`Add()` |
| 局部变量 | camelCase | `strWhere`、`model`、`startIndex` |
| ASPX 页面 | PascalCase | `Index.aspx`、`Product.aspx` |

### 实体类（Entity）模式

```csharp
using System;
namespace NetWise.Entity
{
    [Serializable]
    public partial class Product
    {
        public Product() { }

        #region Model
        private int _p_id;
        private string _cn_name;

        public int P_Id { set { _p_id = value; } get { return _p_id; } }
        public string CN_Name { set { _cn_name = value; } get { return _cn_name; } }
        #endregion
    }
}
```

### 数据访问层（DataAccess）模式

```csharp
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using NetWise.Entity;
using NetWise.DBUtility;

namespace NetWise.DataAccess
{
    public partial class Product
    {
        #region BasicMethod
        public bool Exists(int P_Id) { /* ... */ }
        public int Add(NetWise.Entity.Product model) { /* ... */ }
        public bool Update(NetWise.Entity.Product model) { /* ... */ }
        public bool Delete(int P_Id) { /* ... */ }
        public NetWise.Entity.Product GetModel(int P_Id) { /* ... */ }
        public DataRowToModel(DataRow row) { /* ... */ }
        public DataSet GetList(string strWhere) { /* ... */ }
        #endregion

        #region ExtensionMethod
        // 业务扩展方法
        #endregion
    }
}
```

**关键规则：**
- 使用 `#region BasicMethod` 和 `#region ExtensionMethod` 组织代码块
- SQL 语句使用 `StringBuilder` 拼接
- 参数化查询使用 `SqlParameter[]` 数组
- 数据库操作通过 `DbHelperSQL` 工具类执行
- 实体转换使用 `DataRowToModel(DataRow)` 方法

### ASPX 页面模式

```aspx
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- 页面级 CSS / meta -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- 页面主体内容 -->
</asp:Content>
```

### Code-Behind 模式

```csharp
using System;
using System.Web.UI;
using NetWise.DataAccess;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        // 数据绑定逻辑
    }
}
```

### 前端代码风格

- **JavaScript**：基于 jQuery，使用 `$(document).ready()` 初始化
- **CSS 类名**：语义化命名，使用下划线分隔（`.nav_fix`、`.prod_img`、`.ind_banner`）
- **布局工具类**：`.f_fl`（左浮动）、`.f_fr`（右浮动）、`.f_fc`（居中）
- **颜色变量**：使用 CSS 自定义属性统一主题色
- **响应式**：通过 `min-width` 媒体查询适配（基准 1300px）

### 双语支持

项目支持中英双语，命名约定：
- `CN_` 前缀表示中文内容字段（如 `CN_Name`、`CN_Content`）
- `EN_` 前缀表示英文内容字段（如 `EN_Name`、`EN_Content`）
- 英文版页面放在 `en/` 目录下

## 架构说明

```
┌─────────────────────────────────────────┐
│              ASPX 页面（UI 层）           │
│         MasterPage + ContentPage         │
├─────────────────────────────────────────┤
│           Code-Behind（逻辑层）           │
│          Page_Load + 事件处理            │
├─────────────────────────────────────────┤
│          DataAccess（数据访问层）         │
│     Exists / Add / Update / Delete /     │
│        GetModel / GetList                │
├─────────────────────────────────────────┤
│            Entity（实体模型层）           │
│        属性映射数据库字段                 │
├─────────────────────────────────────────┤
│           DBUtility（工具层）             │
│         DbHelperSQL 数据库操作            │
└─────────────────────────────────────────┘
```

## 后台管理

- 路径：`/admin/`
- 认证：Session 状态管理 + 验证码登录
- 功能：产品管理、新闻管理、公司信息、文件上传
- 富文本编辑：FCKeditor

## 编译命令

在项目根目录 `C:\project\dongyu` 下执行：

```bash
# 编译项目（注意：在 Git Bash 中使用双斜杠 // 转义 MSBuild 参数）
"/c/Windows/Microsoft.NET/Framework/v4.0.30319/MSBuild.exe" dongyu.sln //t:Build //p:Configuration=Debug
```

## 文件编码规范

**所有 .aspx、.aspx.cs、.cs 文件必须使用以下编码格式：**

- **编码**：UTF-8 with BOM（带 BOM 头 `\xEF\xBB\xBF`）
- **行尾符**：CRLF（`\r\n`，Windows 风格）

> ⚠️ Write/Edit 工具默认输出 LF 行尾且不带 BOM，会导致 ASP.NET aspnet_compiler 报"服务器标记的格式不正确"错误。
> 写完文件后需执行以下转换：
>
> ```bash
> # 转换单个文件为 UTF-8 BOM + CRLF
> sed 's/$/\r/' "文件路径" > "文件路径.tmp"
> printf '\xef\xbb\xbf' > "文件路径"
> cat "文件路径.tmp" >> "文件路径"
> rm "文件路径.tmp"
> ```
>
> 可用 `file 文件路径` 验证，正确输出应包含：`UTF-8 (with BOM) text, with CRLF line terminators`

## 数据库操作

项目使用 SQL Server 数据库，通过 `sqlcmd` 命令行工具操作（mcp-dbutils 不支持 MSSQL）：

```bash
# 连接参数
# server=47.89.194.240  database=dongyu  user=sa

# 示例：查看表结构
sqlcmd -S 47.89.194.240 -U sa -P <password> -d dongyu -Q "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '表名'" -s "|" -W

# 示例：添加字段
sqlcmd -S 47.89.194.240 -U sa -P <password> -d dongyu -Q "ALTER TABLE 表名 ADD 字段名 NText NULL"
```

## 开发注意事项

1. **不要引入 ORM**：项目使用原生 ADO.NET，保持 DbHelperSQL + SqlParameter 风格
2. **不要升级 jQuery**：前端依赖 jQuery 1.9.1，保持版本一致
3. **保持三层分离**：新增功能时严格按 Entity → DataAccess → ASPX 的顺序编写
4. **参数化查询**：所有 SQL 操作必须使用 `SqlParameter`，禁止字符串拼接用户输入
5. **region 组织**：DataAccess 类必须包含 `#region BasicMethod` 和 `#region ExtensionMethod`
6. **双语字段**：新增实体属性时同步添加 `CN_` 和 `EN_` 前缀版本
7. **分页控件**：使用 `UserControl/` 中现有的 Pager 控件，不要新建
8. **文件上传**：上传目录为 `uploadfiles/`，保持一致
