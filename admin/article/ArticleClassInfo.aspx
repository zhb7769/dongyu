<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleClassInfo.aspx.cs"
    Inherits="admin_Article_ArticleClassInfo" %>

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
                网站管理平台 > <span class="guide-txt">文章管理</span></div>
            <!--欢迎及上次登录 开始-->
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li><a href="ArticleClassList.aspx">文章分类</a></li>
                        <li class="hover">添加分类</li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="add-main-w" style="display: block">
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <div class="basic">
                        <div class="fieldline">
                            <div class="c1">
                                上级分类</div>
                            <div class="c2" style="margin-right: 8px;">
                                <asp:DropDownList ID="ddlArticleClass" runat="server">
                                  <asp:ListItem Text="　顶级分类　" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                名称(中)</div>
                            <div class="c2">
                                <asp:TextBox ID="txtCN_Name" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                名称(英)</div>
                            <div class="c2">
                                <asp:TextBox ID="txtEN_Name" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                分类排序</div>
                            <div class="c2">
                                <asp:TextBox ID="txtSort" runat="server" CssClass="i-a03" onkeypress="return isNumber(event);" Text="0"></asp:TextBox></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="fieldline">
                            <div class="c1">
                                类别图片
                            </div>
                            <div class="c2">
                                <asp:TextBox ID="txtC_Pic" runat="server" CssClass="i-a"></asp:TextBox></div>
                            <div class="c2">
                                <asp:FileUpload ID="fuC_Pic" runat="server" CssClass="i-a" />&nbsp;<asp:Button ID="btnC_Pic"
                                    runat="server" Text="上 传" OnClick="btnC_Pic_Click" CssClass="class-btn" /></div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="article-img">
                                <asp:Image ID="imgC_Pic" runat="server" ImageUrl="~/admin/images/noneimg.gif" Width="140"
                                    Height="140" /></div>
                        <div class="clear"></div>
                         <br />
                        <div class="fieldline">
                            <div class="c1">
                                推荐显示</div>
                            <div class="c3">
                                <asp:CheckBox ID="ckbIsShow" runat="server" class="i-a-tj" />
                                <div class="clear">
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <div class="btn-class">
                        <asp:Button ID="btnOk" runat="server" Text="确 定" CssClass="class-btn" 
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
