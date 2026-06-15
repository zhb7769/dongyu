<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comtact.aspx.cs" Inherits="admin_comtact_Comtact" %>

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
                网站管理平台 > <span class="guide-txt">联系方式</span></div>
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover1">联系方式</li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="add-main-w" style="display: block">
                    <div class="basic">
                        <div class="fieldline">
                            <div class="c1">
                                公司名称</div>
                            <div class="c2">
                                <asp:TextBox ID="txtCN_Company" runat="server" CssClass="i-a"></asp:TextBox>
                                </div>
                            <div class="c1">
                                英文名称</div>
                            <div class="c2">
                                <asp:TextBox ID="txtEN_Company" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                公司地址</div>
                            <div class="c2">
                                <asp:TextBox ID="txtCN_Address" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="c1">
                                英文地址</div>
                            <div class="c2">
                                <asp:TextBox ID="txtEN_Address" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                联系人</div>
                            <div class="c2">
                                <asp:TextBox ID="txtCN_Person" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="c1">
                                英文联系人</div>
                            <div class="c2">
                                <asp:TextBox ID="txtEN_Person" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                公司电话</div>
                            <div class="c2">
                                <asp:TextBox ID="txtCN_CompanyTel" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="c1">
                                英文电话</div>
                            <div class="c2">
                                <asp:TextBox ID="txtEN_CompanyTel" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                手机</div>
                            <div class="c2">
                                <asp:TextBox ID="txtCN_Phone" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="c1">
                                英文手机</div>
                            <div class="c2">
                                <asp:TextBox ID="txtEN_Phone" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                传真</div>
                            <div class="c2">
                                <asp:TextBox ID="txtFax" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                邮编</div>
                            <div class="c2">
                                <asp:TextBox ID="txtPostCode" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                邮箱</div>
                            <div class="c2">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                网址</div>
                            <div class="c2">
                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                QQ</div>
                            <div class="c2">
                                <asp:TextBox ID="txtQQ" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                SKYPE</div>
                            <div class="c2">
                                <asp:TextBox ID="txtSKYPE" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <div class="btn-class" style="padding-top: 20px;">
                        <asp:Button ID="Button1" runat="server" CssClass="class-btn" Text="确定" 
                            onclick="Button1_Click" />
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
