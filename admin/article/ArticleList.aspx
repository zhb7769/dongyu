<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleList.aspx.cs" Inherits="admin_Article_ArticleList" %>

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
                网站管理平台 > <span class="guide-txt">文章管理</span></div>
            <!--欢迎及上次登录 开始-->
            <div class="Showpath-Txt">
                <div class="Showpath-ss">
                </div>
                文章搜索</div>
            <!--搜索 开始-->
            <div class="ss-bor">
                <ul>
                    <li class="Txt-right">关键词：</li>
                    <li>
                        <asp:TextBox ID="txtKeyWords" runat="server" CssClass="I-key"></asp:TextBox></li>
                    <li class="Txt-right">分类：</li>
                    <li>
                        <asp:DropDownList ID="ddlArticleClass" runat="server" CssClass="S-xl">
                          <asp:ListItem Text="　顶级分类　" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                     </li>
                    <li>
                        <asp:Button ID="btnSearch" runat="server" CssClass="ss-btn" Text="搜 索" 
                            onclick="btnSearch_Click" /></li>
                    <div class="clear">
                    </div>
                </ul>
            </div>
            <!--搜索 结束-->
            <div class="cMain-w">
                <div class="cMain-title">
                    <ul class="ul-list">
                        <li class="sel"><input type="checkbox" onclick="GetAllCheckBok(this)" class="check" /></li>
                        <li class="title"><span class="underline">标题</span></li>
                        <li class="date-time"><span class="underline">分类</span></li>
                        <li class="date-time"><span class="underline">更新时间</span></li>
                        <li class="cz">操作</li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <!--文章列表 开始-->
                <asp:Repeater ID="rptArticleList" runat="server" onitemcommand="rptArticleList_ItemCommand" onitemdatabound="rptArticleList_ItemDataBound">
                  <ItemTemplate>
                     <ul class="ul-list">
                        <li class="sel"><asp:CheckBox ID="ckbSelect" runat="server" CssClass="check" />
                           <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("ID") %>' /></li>
                        <li class="title"><a href='ArticleInfo.aspx?C_id=<%#Eval("ID") %>'><%#Eval("CN_Title")%></a></li>
                        <li class="date-time"><asp:Label ID="lblArticleClass" runat="server" Text='<%#Eval("ArticleClassId") %>'></asp:Label></li>
                        <li class="date-time"> <%#Eval("CreateTime", "{0:yyyy-MM-dd}")%> </li>
                        <li class="cz"><a href='ArticleInfo.aspx?C_id=<%#Eval("ID") %>'>编辑</a> 
                            <asp:LinkButton ID="lkbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("ID") %>' 
                              OnClientClick="return confirm('您确定要删除吗？')" >删除</asp:LinkButton></li>
                        <div class="clear"></div>
                     </ul>
                  </ItemTemplate>
                </asp:Repeater>
                
                <!--文章列表 结束-->
            </div>
            <!--操作+翻页 开始-->
            <div class="bot">
                <div class="page">
                  <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                     FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" 
                        AlwaysShow="True" PageSize="15" onpagechanged="AspNetPager1_PageChanged">
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
                
                &nbsp;<asp:Button ID="btnDelAll" runat="server" CssClass="ss-btn" Text="批量操作" 
                    onclick="btnDelAll_Click" /></div>
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
