<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginBannerInfo.aspx.cs" Inherits="admin_loginBanner_LoginBannerInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../userControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="../userControl/Memu.ascx" TagName="Memu" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/layout.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/jquery.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />

    <div id="content">
      
        <uc2:Memu ID="Memu1" runat="server" />
      
        <div class="Main">
            <div class="Showpath">
                网站管理平台 > <span class="guide-txt">登录页广告图片</span></div>
          
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li><a href="LoginBanners.aspx">列表</a></li>
                        <li class="hover">添加</li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="add-main-w" style="display: block">
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <div class="basic">
                        <div class="fieldline">
                            <div class="c1">
                                标题</div>
                            <div class="c2">
                                <asp:TextBox ID="txtB_Title" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                样式</div>
                            <div class="c2">
                                <asp:TextBox ID="txtB_Style" runat="server" CssClass="i-a"></asp:TextBox> </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                链接地址</div>
                            <div class="c2">
                                <asp:TextBox ID="txtB_Add" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                链接图片</div>
                            <div class="c2">
                                <asp:TextBox ID="txtB_Pic" runat="server" CssClass="i-a"></asp:TextBox>
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="i-a" /></div>
                            &nbsp;&nbsp;<asp:Button ID="btnFileUpload" runat="server" Text="点击上传"  CssClass="class-btn" onclick="btnFileUpload_Click" /><div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                &nbsp;</div>
                            <div class="c2">
                                <asp:Image ID="imgView" runat="server" ImageUrl="~/admin/images/noneimg.gif" /></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                分类排序</div>
                            <div class="c2">
                                <asp:TextBox ID="txtB_Sort" CssClass="i-a03" runat="server" onkeypress="return isNumber(event);" ></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <div class="btn-class">
                        <asp:Button ID="btnOk" runat="server" CssClass="class-btn" Text="确定" 
                            onclick="btnOk_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <!--container end -->
    </form>
<script language="javascript" type="text/javascript">

 isNumber = function (e) {  
    if ($.browser.msie) {  
        if ( ((event.keyCode > 47) && (event.keyCode < 58)) ||  (event.keyCode == 8)  || (event.keyCode == 46)) {  
            return true;  
        } else {  
            return false;  
        }  
    } else {  
        if ( ((e.which > 47) && (e.which < 58)) ||  (e.which == 8)  || (e.which == 46 )) {  
            return true;  
        } else {  
            return false;  
        }  
    }  
}

</script>
<script language="javascript" type="text/javascript">


$(".nav-item li h1").click(function(){
	
	$(this).siblings().slideDown("fast")
	$(this).parent().siblings().find(".nav-item02").slideUp("fast")
	
	})


guide=$(".guide-txt").text()


for(var i=0;i<9;i++)
{
    if($('.nav-item li h1 a:eq('+i+')').text()==guide)
    {	
      $('.nav-item li h1 a:eq('+i+')').parent().siblings().show()
    }
}

</script>
</body>
</html>
