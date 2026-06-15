<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Memu.ascx.cs" Inherits="admin_userControl_Memu" %>
<div class="Leftbar">
    <div class="title">
        常用功能操作
    </div>
    <div class="con">
        <ul class="nav-item">
            <li>
                <h1>
                    <a href="#">产品管理</a></h1>
                <div class="nav-item02">
                    <a href="../product/ProductClassInfo.aspx">添加分类</a> <a href="../product/ProductClass.aspx">分类管理</a> <a href="../product/ProductInfo.aspx">添加产品</a> <a href="../product/Products.aspx">产品管理</a>
                    <%--<a href="../product/Property.aspx">产品属性</a>--%>
                </div>
            </li>
            <li>
                <h1>
                    <a href="#">配件管理</a></h1>
                <div class="nav-item02">
                    <a href="/admin/product_new/ProductClassInfo.aspx">添加分类</a> <a href="/admin/product_new/ProductClass.aspx">分类管理</a> <a href="/admin/product_new/ProductInfo.aspx">添加配件</a> <a href="/admin/product_new/Products.aspx">配件管理</a>
                </div>
            </li>
            <li>
                <h1>
                    <a href="#">文章管理</a></h1>
                <div class="nav-item02">
                    <a href="../article/ArticleClassInfo.aspx">添加分类</a> <a href="../article/ArticleClassList.aspx">分类管理</a> <a href="../article/ArticleInfo.aspx">添加文章</a> <a href="../article/ArticleList.aspx">文章管理</a>
                </div>
            </li>
            <li>
                <h1>
                    <a href="#">新闻管理</a></h1>
                <div class="nav-item02">
                    <a href="../news/NewsClassInfo.aspx">添加分类</a> <a href="../news/NewsClass.aspx">分类管理</a>
                    <a href="../news/NewsInfo.aspx">添加新闻</a> <a href="../news/News.aspx">新闻管理</a>
                </div>
            </li>
            <li>
                <h1>
                    <a href="../comtact/Comtact.aspx">联系方式</a></h1>
            </li>
            <li>
                <h1>
                    <a href="../message/Message.aspx">留言管理</a></h1>
            </li>
            <li>
                <h1>
                    <a href="#">下载中心</a>
                </h1>
                <div class="nav-item02">
                    <a href="../annex/DownloadClass.aspx">分类管理</a>
                    <a href="../annex/Annex.aspx">下载管理</a>
                </div>
            </li>
            <li>
                <h1>
                    <a href="#">售后服务</a>
                </h1>
                <div class="nav-item02">
                    <a href="../AfterService/AfterService.aspx">售后服务列表</a>
                </div>
            </li>
            <li>
                <h1>
                    <a href="#">产品注册</a>
                </h1>
                <div class="nav-item02">
                    <a href="../ProductReg/ProductReg.aspx">产品注册列表</a>
                </div>
            </li>
        </ul>
        <ul class="Fixed">
            <li>服务热线:<br />
                <span class="tel"><span style="font-size: 14px;">13777166664</span></span><br />
                <span style="color: #71b7f8">版权所有 &copy; <a href="http://www.tz-media.cn" target="_blank" style="color: #71b7f8">天之传媒</a></span>
            </li>
        </ul>
    </div>
</div>
