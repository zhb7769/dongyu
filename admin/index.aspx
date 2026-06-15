<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="admin_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台首页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <!--header begin-->
        <div id="header">
            <div class="wra hei68">
                <div class="logo">
                    <img src="images/admin-logo.gif" alt="" />
                </div>
                <div class="homeclick">
                    <a href="../index.aspx" target="_blank">
                        <img src="images/view.gif" alt="查看首页" /></a>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="wra">
                <!--欢迎-->
                <div class="sign">
                    <div class="Status">
                        <ul>
                            <li>欢迎您！<asp:Label ID="lblName" runat="server"></asp:Label></li>
                            <li><a href="comtact/admin.aspx">账号管理</a></li>
                            <li class="Information">您有 <a href="message/Message.aspx">
                                <asp:Literal ID="litM_Num" runat="server" Text="0"></asp:Literal>
                            </a>条新留言</li>
                            <div class="clear">
                            </div>
                        </ul>
                    </div>
                    <div class="Operation">
                        <ul>
                            <%--<li class="Cancel"><a href="">注销</a></li>--%>
                            <li class="Sign-out">
                                <asp:LinkButton ID="lkbtnExit" runat="server" OnClick="lkbtnExit_Click">退出</asp:LinkButton></li>
                            <div class="clear">
                            </div>
                        </ul>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <!--欢迎-->
            </div>
        </div>
        <!--header end-->
        <!--container begin -->
        <div id="content">
            <!--leftbar begin-->
            <div class="Leftbar">
                <div class="title">
                    常用功能操作
                </div>
                <div class="con">
                    <ul class="nav-item">
                        <li>
                            <h1>
                                <a href="#">产品管理</a>
                            </h1>
                            <div class="nav-item02">
                                <a href="product/ProductClassInfo.aspx">添加分类</a>
                                <a href="product/ProductClass.aspx">分类管理</a>
                                <a href="product/ProductInfo.aspx">添加产品</a>
                                <a href="product/Products.aspx">产品管理</a>
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
                                <a href="article/ArticleClassInfo.aspx">添加分类</a> <a href="article/ArticleClassList.aspx">分类管理</a> <a href="article/ArticleInfo.aspx">添加文章</a> <a href="article/ArticleList.aspx">文章管理</a>
                            </div>
                        </li>
                        <li>
                            <h1>
                                <a href="#">新闻管理</a></h1>
                            <div class="nav-item02">
                                <a href="news/NewsClassInfo.aspx">添加分类</a> <a href="news/NewsClass.aspx">分类管理</a>
                                <a href="news/NewsInfo.aspx">添加新闻</a> <a href="news/News.aspx">新闻管理</a>
                            </div>
                        </li>
                        <li>
                            <h1>
                                <a href="comtact/Comtact.aspx">联系方式</a></h1>
                        </li>
                        <li>
                            <h1>
                                <a href="message/Message.aspx">留言管理</a></h1>
                        </li>
                        <li>
                            <h1>
                                <a href="#">下载中心</a>
                            </h1>
                            <div class="nav-item02">
                                <a href="annex/DownloadClass.aspx">分类管理</a>
                                <a href="annex/Annex.aspx">下载管理</a>
                            </div>
                        </li>
                        <li>
                            <h1>
                                <a href="#">售后服务</a>
                            </h1>
                            <div class="nav-item02">
                                <a href="AfterService/AfterService.aspx">售后服务列表</a>
                            </div>
                        </li>
                        <li>
                            <h1>
                                <a href="#">产品注册</a>
                            </h1>
                            <div class="nav-item02">
                                <a href="ProductReg/ProductReg.aspx">产品注册列表</a>
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
            <!--leftbar end-->
            <div class="Main">
                <div class="Showpath">
                    网站管理平台 > <span class="guide-txt">网站首页</span>
                </div>
                <!--欢迎及上次登录 开始-->
                <div class="cMain">
                    <div class="cMain-l">
                    </div>
                    <div class="cMain-Txt">
                        <%-- <span class="last">上次登录：2011-08-09 15:22 （不是您登录的？<a href="login.aspx" class="font-blue">请点这里</a>）</span>--%>
                        <span class="welcome"><span class="font-blue">
                            <asp:Literal ID="litAdminName" runat="server"></asp:Literal></span> &nbsp; 您好，欢迎使用天之传媒后台管理系统</span>
                    </div>
                    <div class="cMain-r">
                    </div>
                    <div class="clear"></div>
                </div>
                <!--欢迎及上次登录 结束-->
                <!--快捷导航 开始-->
                <ul class="MainNav">
                    <li><a href="product/ProductInfo.aspx">
                        <img src="images/ico/fb.gif" /><br />
                        发布产品</a></li>
                    <li><a href="product/Products.aspx">
                        <img src="images/ico/order.gif" /><br />
                        产品管理</a></li>
                    <li><a href="news/NewsInfo.aspx">
                        <img src="images/ico/order-ss.gif" /><br />
                        发布新闻</a></li>
                    <li><a href="news/News.aspx">
                        <img src="images/ico/kc.gif" /><br />
                        新闻管理</a></li>
                    <li><a href="message/Message.aspx">
                        <img src="images/ico/ad.gif" /><br />
                        留言管理</a></li>
                    <%--<li><a href="seo/Seo.aspx">
                    <img src="images/ico/seo.gif" /><br />
                    网站优化</a></li>--%>
                    <div class="clear">
                    </div>
                </ul>
                <!--快捷导航 结束-->
                <div class="slide">
                    <%--<img src="images/slider.jpg" width="690" height="300" alt="" />--%>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <!--container end -->

        <script language="javascript" type="text/javascript">


            $(".nav-item li h1").click(function () {

                $(this).siblings().slideDown("fast")
                $(this).parent().siblings().find(".nav-item02").slideUp("fast")

            })


            guide = $(".guide-txt").text()


            for (var i = 0; i < 9; i++) {
                if ($('.nav-item li h1 a:eq(' + i + ')').text() == guide) {
                    $('.nav-item li h1 a:eq(' + i + ')').parent().siblings().show()
                }
            }

        </script>

    </form>
</body>
</html>
