<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KF.aspx.cs" Inherits="admin_kf_KF" %>

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
            <div class="Showpath">
                网站管理平台 > <span class="guide-txt">客服管理</span></div>
            <!--欢迎及上次登录 开始-->
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover1">客服管理</li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="add-main-w">
                    <div class="basic">
                        <asp:Repeater ID="rptServic" runat="server" 
                            onitemcommand="rptServic_ItemCommand">
                         <ItemTemplate>
                           <div class="fieldline">
                            <div class="c1"> <%#Eval("ServiceType")%> </div>
                            <div class="c2">
                                <asp:TextBox ID="txtNum" runat="server" CssClass="i-a" Text='<%#Eval("Number") %>'></asp:TextBox>
                                <asp:LinkButton ID="lbtUpdate" runat="server" CommandName="Modify" CommandArgument='<%#Eval("ID") %>'>修改</asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("ID") %>'>删除</asp:LinkButton></div>
                            <div class="clear">
                            </div>
                        </div>
                         </ItemTemplate>
                        </asp:Repeater>

                        <div class="fieldline">
                            <div class="c1">
                                &nbsp;</div>
                            <div class="c2" style="padding-right: 8px;">
                                <asp:DropDownList ID="ddlSelect" runat="server" CssClass="kf_sel">
                                 <asp:ListItem Text="-选择类别-" Value=""></asp:ListItem>
                                 <asp:ListItem Text="Q Q" Value="Q Q"></asp:ListItem>
                                 <asp:ListItem Text="SKYPE" Value="SKYPE"></asp:ListItem>
                                 <asp:ListItem Text="旺旺" Value="旺旺"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="c2">
                                <asp:TextBox ID="TxtNumber" runat="server" CssClass="i-a07"></asp:TextBox></div>
                            <div class="c2">
                                <asp:Button ID="btnOk" runat="server" CssClass="class-btn" Text="添 加" 
                                    onclick="btnOk_Click" /></div>
                            <div class="clear">
                            </div>
                        </div>
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
