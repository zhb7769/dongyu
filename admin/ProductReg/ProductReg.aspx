<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductReg.aspx.cs" Inherits="admin_ProductReg_ProductReg" %>

<%@ Register Src="../userControl/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="../userControl/Memu.ascx" TagName="Memu" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
    <uc1:Top ID="Top1" runat="server" />
    <div id="content">
        <uc2:Memu ID="Memu1" runat="server" />
        <div class="Main">
            <div class="Showpath">
                网站管理平台 > <span class="guide-txt">产品注册管理</span></div>
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover1">产品注册列表</li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="cMain-w nb">
                    <div class="cMain-title b-t">
                        <ul class="ul-list">
                            <li class="sel">
                                <input name="" type="checkbox" value="" class="check" />
                            </li>
                            <li class="Message-Name">国家</li>
                            <li class="Message-con">采购渠道</li>
                            <li class="Time">购买日期</li>
                            <li class="cz">操作</li>
                            <div class="clear">
                            </div>
                        </ul>
                    </div>
                    <div class="cMain-con s2">
                        <!--课程分类列表 开始-->
                        <asp:Repeater ID="rptMsg" runat="server" onitemcommand="rptMsg_ItemCommand" 
                            onitemdatabound="rptMsg_ItemDataBound">
                            <ItemTemplate>
                                <ul class="ul-list l">
                                    <li class="sel">
                                        <asp:CheckBox ID="ckbSelect" runat="server" CssClass="check" />
                                        <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("ID") %>' />
                                    </li>
                                    <li class="Message-Name">
                                        <%#Eval("V1")%>
                                    </li>
                                    <li class="Message-con">
                                        <%#Eval("pName")%></li>
                                    <li class="Time">
                                        <%#Eval("PurchaseDate", "{0:yyyy-MM-dd}")%>
                                    </li>
                                    <li class="cz"><a href='ProductRegInfo.aspx?m_Id=<%#Eval("ID")%>'>查看</a>
                                        <asp:LinkButton ID="lkbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('您确定要删除吗？')">删除</asp:LinkButton></li>
                                    <div class="clear">
                                    </div>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <!--操作+翻页 开始-->
            <div class="bot">
                <div class="page">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页"
                        NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" PageSize="15" OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
                <asp:DropDownList ID="ddlSelect" runat="server" CssClass="S-xl">
                    <asp:ListItem Text="-请选择操作-" Value="0"></asp:ListItem>
                    <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnDelAll" runat="server" CssClass="ss-btn" Text="批量操作" OnClick="btnDelAll_Click" />
            </div>
            <!--操作+翻页 结束-->
        </div>
        <div class="clear">
        </div>
    </div>
    <!--container end -->
    </form>
<script type="text/javascript">
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
