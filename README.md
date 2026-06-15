# 东宇卫浴企业官网

余姚市东宇卫浴制品有限公司企业官方网站。

## 技术栈

- **后端框架**：ASP.NET Web Forms (.NET Framework 4.0)
- **语言**：C#
- **数据库**：SQL Server
- **数据访问**：原生 ADO.NET (DbHelperSQL + SqlParameter)
- **前端**：jQuery 1.9.1、Swiper.js、WOW.js
- **富文本编辑器**：FCKeditor.Net 2.6.3

## 项目结构

```
├── App_Code/
│   ├── DBUtility/          # 数据库工具类
│   ├── DataAccess/         # 数据访问层 (DAL)
│   └── Entity/             # 实体模型层
├── admin/                  # 后台管理系统
├── css/                    # 样式表
├── en/                     # 英文版页面
├── images/                 # 图片资源
├── js/                     # JavaScript 脚本
├── uploadfiles/            # 用户上传文件
├── UserControl/            # 自定义用户控件
├── MasterPage.master       # 中文母版页
├── en/MasterPage.master    # 英文母版页
└── Web.config              # 应用配置
```

## 功能模块

- 产品展示（中英双语）
- 新闻动态
- 关于东宇（公司简介、生产基地、发展历程）
- 工艺及设备
- 联系我们
- 后台管理（产品管理、新闻管理、分类管理）
