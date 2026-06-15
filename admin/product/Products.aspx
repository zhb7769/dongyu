<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="admin_product_Products" %>

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
                网站管理平台 > <span class="guide-txt">产品管理</span></div>
            <!--欢迎及上次登录 开始-->
            <div class="Showpath-Txt">
                <div class="Showpath-ss">
                </div>
                产品搜索</div>
            <!--搜索 开始-->
            <div class="ss-bor">
                <ul>
                    <li class="Txt-right">关键词：</li>
                    <li>
                        <asp:TextBox ID="txtKeyWords" runat="server" CssClass="I-key"></asp:TextBox></li>
                    <li class="Txt-right">分类：</li>
                    <li>
                        <asp:DropDownList ID="ddlProductClass" runat="server">
                            <asp:ListItem Text="　　顶级分类　" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>
                        <asp:Button ID="btnSearch" runat="server" CssClass="ss-btn" Text="搜 索" OnClick="btnSearch_Click" /></li>
                    <li class="add"><a href="ProductInfo.aspx">添加产品</a></li>
                    <div class="clear">
                    </div>
                </ul>
            </div>
            <!--搜索 结束-->
            <div class="cMain-w">
                <div class="cMain-title">
                    <ul class="ul-list">
                        <li class="sel">
                            <input type="checkbox" onclick="GetAllCheckBok(this)" class="check" /></li>
                        <li class="title" style="width: 330px;"><span class="underline">产品名称</span></li>
                        <li class="order"><span class="underline">排序</span></li>
                        <li class="subclass"><span class="underline">产品分类</span></li>
                        <li class="date-time"><span class="underline">更新时间</span></li>
                        <li class="order"><span class="underline">推荐</span></li>
                        <li class="cz">操作</li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="productlist">
                    <!--文章列表 开始-->
                    <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand"
                        OnItemDataBound="rptProducts_ItemDataBound">
                        <ItemTemplate>
                            <ul class="ul-list">
                                <li class="sel">
                                    <asp:CheckBox ID="ckbSelect" runat="server" CssClass="check" />
                                    <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("P_Id") %>' /></li>
                                <li class="title02"><a href='ProductInfo.aspx?P_Id=<%#Eval("P_Id") %>'>
                                    <%#Eval("CN_Name") %></a></li>
                                <li class="order">
                                    <asp:TextBox ID="txtSort" runat="server" CssClass="px0415" Text='<%#Eval("Sort") %>' onkeypress="return isNumber(event);"></asp:TextBox>
                                    <asp:LinkButton ID="lkbtnSort" runat="server" CommandName="Sort" CommandArgument='<%#Eval("P_Id") %>'>更</asp:LinkButton>
                                </li>
                                <li class="subclass">
                                    <asp:Label ID="lblProductClass" runat="server" Text='<%#Eval("ClassId") %>'></asp:Label>
                                    <%--<select class="class0415">
                                <option>产品类别一</option>
                                <option selected="selected">LED 商业照明面板灯</option>
                                <option>路灯头</option>
                                <option>塑料天花筒灯</option>
                                <option>防眩光旋转天花射灯</option>
                            </select>--%></li>
                                <li class="date-time">
                                    <%#Eval("CreateTime", "{0:yyyy-MM-dd}")%>
                                </li>
                                <li class="order">
                                    <asp:Image ID="imgIsTop" runat="server" ToolTip='<%#Eval("IsPage") %>' /></li>
                                <li class="cz"><a href='ProductInfo.aspx?P_Id=<%#Eval("P_Id") %>'>编辑</a>
                                    <asp:LinkButton ID="lkbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("P_Id") %>'
                                        OnClientClick="return confirm('您确定要删除吗？')">删除</asp:LinkButton></li>
                                <div class="clear"></div>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!--文章列表 结束-->
                </div>
            </div>
            <%-- <div class="sale0412"><input type="button" class="ss-btn " value="保 存" /></div>--%>
            <!--操作+翻页 开始-->
            <div class="bot">
                <div class="page">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页"
                        NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" PageSize="15" OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>
                    <%--共 <span class="underline">265</span> 条数据，当前第 1 页，每页 15 条，<a href="">首页</a> <a href="">
                        上一页</a> <span class="hover"><a href="">1</a></span> <span class="num"><a href="">2</a></span>
                    <span class="num"><a href="">3</a></span> <span class="num"><a href="">4</a></span>
                    <span class="num"><a href="">5</a></span> <a href="">下一页</a> <a href="">尾页</a>--%>
                </div>
                <asp:DropDownList ID="ddlSelect" runat="server" CssClass="S-xl">
                    <asp:ListItem Text="-请选择操作-" Value="0"></asp:ListItem>
                    <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                </asp:DropDownList>
                <%-- <select name="jumpMenu" id="jumpMenu" class="S-xl">
                    <option>-请选择操作-</option>
                    <option>推荐</option>
                    <option>删除</option>
                </select>--%>
                &nbsp;<asp:Button ID="btnDelAll" runat="server" CssClass="ss-btn" Text="批量操作" OnClick="btnDelAll_Click" /></div>
        <!--操作+翻页 结束-->
    </div>
    <div class="clear">
    </div>
    </div>
    <!--container end -->
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
</script >
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
