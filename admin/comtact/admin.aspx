<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin_comtact_admin" %>

<%@ Register Src="../userControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="../userControl/Memu.ascx" TagName="Memu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/layout.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/jquery.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <!--header begin-->
     <uc1:Top ID="Top1" runat="server" />
    <!--header end-->
    <!--container begin -->
    <div id="content">
        <!--leftbar begin-->
        <uc2:Memu ID="Memu1" runat="server" />
        <!--leftbar end-->
        <div class="Main">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            <div class="Showpath">
                网站管理平台 > <span class="guide-txt">账号管理</span></div>
            <!--欢迎及上次登录 开始-->
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover1"><a href="admin.aspx">账号管理</a></li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="add-main-w" style="display: block">
                    <div class="basic">
                        <div class="fieldline">
                            <div class="c1">
                                账号</div>
                            <div class="c2">
                                admin</div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                原密码</div>
                            <div class="c2">
                                <input class="i-a" type="password" id="yPass" runat="server" /></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                新密码</div>
                            <div class="c2">
                                <input class="i-a" type="password" id="xPass" runat="server" />
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                确认密码</div>
                            <div class="c2">
                                <input class="i-a" type="password" id="oPass" runat="server" />
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <div class="btn-class">
                        <asp:Button ID="btnOk" runat="server" Text="确定" CssClass="class-btn" 
                            onclick="btnOk_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <!--container end -->

    <script>


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

    </form>
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
