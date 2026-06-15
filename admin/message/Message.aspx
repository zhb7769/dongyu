<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="admin_message_Message" %>

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
                网站管理平台 > <span class="guide-txt">留言管理</span></div>
            <!--欢迎及上次登录 开始-->
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover1">留言列表</li>
                        <%--<li><a href="Property.aspx">留言属性</a></li>--%>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="cMain-w nb">
                    <div class="cMain-title b-t">
                        <ul class="ul-list">
                            <li class="sel">
                                <input name="" type="checkbox" value="" class="check" /></li>
                            <li class="Message-Name">留言人</li>
                            <li class="Message-con">内容</li>
                            <li class="Time">留言时间</li>
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
                                        <%#Eval("MName")%>
                                        <asp:Image ID="imgIsRead" runat="server" ToolTip='<%#Eval("IsRead") %>' /></li>
                                    <li class="Message-con">
                                        <%#Eval("MContent")%></li>
                                    <li class="Time">
                                        <%#Eval("CreateTime", "{0:yyyy-MM-dd}")%>
                                    </li>
                                    <li class="cz"><a href='MessageInfo.aspx?m_Id=<%#Eval("ID")%>'>编辑</a>
                                        <asp:LinkButton ID="lkbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('您确定要删除吗？')">删除</asp:LinkButton></li>
                                    <div class="clear">
                                    </div>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--  <ul class="ul-list l"> 
                        <li class="sel"><input name="" type="checkbox" value="" class="check"/></li>
                        <li class="Message-Name">分类名称<img src="../images/newico.gif" /></li>
                        <li class="Message-con">内容</li>                        
                        <li class="Time">2013/04/16</li>                
                        <li class="cz"> <a href="Modify_message.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul>
                    <ul class="ul-list l"> 
                       <li class="sel"><input name="" type="checkbox" value="" class="check"/></li>
                        <li class="Message-Name">分类名称</li>
                        <li class="Message-con">内容</li> 
                        <li class="Time">2013/04/16</li>                
                        <li class="cz"> <a href="Modify_message.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul>

                    <ul class="ul-list l"> 
						<li class="sel"><input name="" type="checkbox" value="" class="check"/></li>
                        <li class="Message-Name">分类名称</li>
                        <li class="Message-con">内容</li> 
                        <li class="Time">2013/04/16</li>               
                        <li class="cz"> <a href="Modify_message.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul>
                    <ul class="ul-list l"> 
						<li class="sel"><input name="" type="checkbox" value="" class="check"/></li>
                        <li class="Message-Name">分类名称</li>
                        <li class="Message-con">内容</li> 
                        <li class="Time">2013/04/16</li>                 
                        <li class="cz"> <a href="Modify_message.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul> --%>
                        <!--课程分类列表 结束-->
                    </div>
                </div>
            </div>
            <!--操作+翻页 开始-->
            <div class="bot">
                <div class="page">
                    <%--共 <span class="underline">265</span> 条数据，当前第 1 页，每页 15 条，<a href="">首页</a> <a href="">
                        上一页</a> <span class="hover"><a href="">1</a></span> <span class="num"><a href="">2</a></span>
                    <span class="num"><a href="">3</a></span> <span class="num"><a href="">4</a></span>
                    <span class="num"><a href="">5</a></span> <a href="">下一页</a> <a href="">尾页</a>--%>
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
