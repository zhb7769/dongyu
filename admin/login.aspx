<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台登录</title>
    <meta name="description" content="后台登录" />
    <link rel="stylesheet" href="css/login0816.css" type="text/css" />
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
<style type="text/css">
    #divSCA
    {
        position: absolute;
        width: 440px;
        height: 223px;
        background: url(images0617/tanchu.png) no-repeat;
        z-index: 10001;
        display: none;
        text-align: right;
        padding-top: 15px;
        padding-right: 20px;
    }
    #divSCA img
    {
        cursor: pointer;
    }
</style>

<script type="text/javascript">
    function refreshCc() {
        var ccImg = document.getElementById("ValidateImg");
        var ccImgSrc = "";
        if (ccImg) {
            nowTime = new Date()
            ccImgSrc = "../ValidateCode.aspx?=" + nowTime.getTime();
        }
        ccImg.src = ccImgSrc;
    }
    
	function openDiv() { alert("请联系客服人员！");
		$("#divSCA").OpenDiv();
	}
		function closeDiv() {
		$("#divSCA").CloseDiv();	
	}
</script>
</head>
<body>
    <form id="form1" runat="server">

    <div class="layout-head">
        <div class="layout-content">
        <a href="#" class="head-logo">
                <img src="images0617/login.gif" alt="login" /></a>
            <div class="menu-list">
                <span style="font-size: 20px; font-family: '微软雅黑'; float: right; line-height: 56px;">
                    服务热线：13777166664<span class="menu-item" style="float: right"></span></span>
            </div>
        </div>
        
    </div>
  
    <div id="divSCA">
        <img src="images0617/close.jpg" onclick="closeDiv()" alt="close" />
    </div>
    <div class="layout-main">
        <div class="banner_area" id="banner_list">
            <div style="opacity: 1;" class="main_box">
                <div class="main_cont">
                    <div class="banner-passport">
                        <div class="pass-bg">
                           <div style=" margin-left:40px; margin-top:5px; text-align:left;"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
                         </div>
                        <div class="pass-content" style="margin-top:7px;">
                            <div id="zzPassForm" class="tang-pass-login">
                                <p class="pass-form-item pass-form-item-userName" style="display: block">
                                    <input name="userName" class="pass-text-input pass-text-input-userName" type="text"
                                        id="userName" runat="server"  placeholder="登录名" />
                                </p>
                                <p class="pass-form-item pass-form-item-password" style="display: block">
                                    <input name="password" class="pass-text-input pass-text-input-password" type="password"
                                        id="password" runat="server" placeholder="登录密码"/></p>
                                <p class="pass-form-item pass-form-item-verifyCode">
                                    <input class="pass-text-input pass-text-input-verifyCode" maxlength="4" type="text"
                                        style="line-height: 24px;" name="CheckCode" id="CheckCode" runat="server" placeholder="验证码"/>
                                   <span style="float: left"><a style="cursor:pointer;"><img id="ValidateImg" name="ValidateImg" height="22" style="margin-left: 5px;" title="看不清，换一个"
                                            onclick="javascript:refreshCc();" src="../ValidateCode.aspx" alt="看不清，换一个" /></a></span>
                                    <a class="pass-change-verifyCode" onclick="javascript:refreshCc();">看不清?</a>
                                    &nbsp;&nbsp;<span class="pass-error pass-error-verifyCode"></span>
                                </p>
                                <p class="pass-form-item pass-form-item-memberPass" style="display:none;">
                                    <input type="checkbox" id="ckbName" name="ckbName" runat="server" class="pass-checkbox-input" />
                                    <label class="">
                                        记住我的登录状态</label></p>
                                <p class="pass-form-item pass-form-item-submit">
                                    <asp:Button ID="btnLogin" runat="server" Text="登 录"  CssClass="pass-button pass-button-submit" onclick="btnLogin_Click" />
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div style="opacity: 1;" class="banner_box banner_logo">
                <div class="banner_cont">
                    
                </div>
            </div>
            
        </div>
        <div class="point">
            <div class="status" id="status">
            </div>
        </div>
          <div class="index-main">
            <div class="main-nav">
                <ul class="nav-list">
                    <li><a class="nav-item item-index">
                        <b class="yahei">网站建设</b><span>打造宁波网站建设高端品牌！</span> </a></li>
                    <li><a class="nav-item item-links">
                        <b class="yahei">样本画册</b><span>为您塑造更具价值的企业宣传画册！</span> </a></li>
                    <li><a class="nav-item item-key"><b class="yahei">网站优化</b><span>提高网站排名，全面提升网站的价值</span>
                    </a></li>
                    <li><a  class="nav-item item-safe"><b class="yahei">手机应用</b><span>企业手机网站建站、客户端定制
                    </span></a></li>
                </ul>
            </div>
        </div>
        <p>
            <br />
        </p>
    </div>
    <style>
        .qqtalk
        {
            margin-left: 20px;
            padding-top: 9px;
        }
        .attion
        {
            background: url(images0617/attion.gif) no-repeat 0px 2px;
            padding-left: 35px;
            color: #494949;
        }
        .attion a
        {
            color: #2c2c2c;
        }
        .linktalk
        {
            list-style: none;
            width: 230px;
            margin: 0px auto;
            height: 50px;
            overflow: hidden;
        }
        .linktalk li
        {
            float: left;
            height: 50px;
            line-height: 50px;
            display: inline;
        }
    </style>
    <div class="layout-foot">
        CopyRight ©2014-2015 &nbsp;&nbsp;&nbsp;&nbsp;天之传媒
    </div>
    </form>
</body>
</html>

