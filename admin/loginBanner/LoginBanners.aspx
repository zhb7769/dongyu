<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginBanners.aspx.cs" Inherits="admin_loginBanner_LoginBanners" %>

<%@ Register Src="../userControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="../userControl/Memu.ascx" TagName="Memu" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
                网站管理平台 &gt; <span class="guide-txt">登录页广告图片</span></div>
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover1">列表</li>
                        <li><a href="LoginBannerInfo.aspx">添加</a></li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="cMain-w nb">
                    <div class="cMain-title b-t">
                        <ul class="ul-list">
                            <li class="sel">
                                <input type="checkbox" onclick="GetAllCheckBok(this)" class="check" /></li>
                            <li class="Message-Name">标题</li>
                            <li class="cz">操作</li>
                            <li class="cz">排序</li>
                            <div class="clear">
                            </div>
                        </ul>
                    </div>
                    <div class="cMain-con s2">
                        <asp:Repeater ID="rptLoginBanner" runat="server" 
                            onitemcommand="rptLoginBanner_ItemCommand">
                            <ItemTemplate>
                                <ul class="ul-list l">
                                    <li class="sel">
                                        <asp:CheckBox ID="cbDel" runat="server" class="check" /></li>
                                    <li class="Message-Name">
                                        <%#Eval("B_Title") %>
                                    </li>
                                    <li class="cz"><a href="LoginBannerInfo.aspx?L_id=<%#Eval("B_ID") %>">编辑</a>
                                        <asp:LinkButton ID="LinkButton1" CommandName="Del" runat="server" CommandArgument='<%#Eval("B_ID")%>'
                                            OnClientClick="return confirm('您确定要删除吗？')">删除</asp:LinkButton>
                                    </li>
                                    <li class="cz">
                                        <asp:TextBox ID="txtSort" runat="server" CssClass="px0415" Text='<%#Eval("B_Sort")%>'
                                            onkeypress="return isNumber(event);"></asp:TextBox>
                                        <asp:LinkButton ID="lbtSort" CommandArgument='<%#Eval("B_ID")%>' CommandName="Sort"
                                            runat="server">更新</asp:LinkButton></li>
                                    <div class="clear">
                                    </div>
                                </ul>
                                <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("B_ID") %>' />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="bot">
                <div class="page">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"
                        FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True"
                        PageSize="10">
                    </webdiyer:AspNetPager>
                </div>
                <asp:DropDownList ID="ddlSelect" runat="server" CssClass="S-xl">
                    <asp:ListItem Value="0" Text="-请选择操作-"></asp:ListItem>
                    <asp:ListItem Value="1" Text="-删除-"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnDo" runat="server" Text="确  定" CssClass="ss-btn" OnClick="btnDo_Click" />
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    </form>

    <script language="javascript" type="text/javascript">
 function GetAllCheckBok(checkAll)
  {
    var items = document.getElementsByTagName("input");
    for(i=0;i<items.length;i++)
    {
      if(items[i].type == "checkbox")
      {
        items[i].checked = checkAll.checked;
      }
    } 
  }
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
