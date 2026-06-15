<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Online.aspx.cs" Inherits="admin_link_Online" %>
<%@ Register src="../userControl/Top.ascx" tagname="Top" tagprefix="uc1" %>
<%@ Register src="../userControl/Memu.ascx" tagname="Memu" tagprefix="uc2" %>
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
    <!--header begin-->
<uc1:Top ID="Top1" runat="server" />
<!--header end-->


<!--container begin -->
<div id="content">
	<!--leftbar begin-->
	<uc2:Memu ID="Memu1" runat="server" />
    <!--leftbar end-->
    <div class="Main">
    	<div class="Showpath">网站管理平台  > <span class="guide-txt">在线查询</span></div>
        <!--欢迎及上次登录 开始-->

         <div class="add-main">
          <div class="guide">
            	<ul class="ul-nav02">
                	<li class="hover1">货物追踪</li>
                    <li  ><a href="OnlineInfo.aspx">添加货物追踪</a></li>
                    <div class="clear"></div>                                  
                </ul>
            </div>            

            <div class="cMain-w nb" >
                <div class="cMain-title b-t">
                    <ul class="ul-list"> 
                        <li class="sel">
                            <input type="checkbox" onclick="GetAllCheckBok(this)" class="check" /></li>
                        <li class="Message-Name">链接名字</li>
						
                                   
                        <li class="cz">操作</li>
                        <li class="cz">排序</li>
                        <div class="clear"></div>
                    </ul>
                </div>
                <div class="cMain-con s2" >
                <!--课程分类列表 开始-->
                    <asp:Repeater ID="rptLink" runat="server" onitemcommand="rptLink_ItemCommand">
                      <ItemTemplate>
                        <ul class="ul-list l"> 
                        <li class="sel">
                            <asp:CheckBox ID="cbDel" runat="server" class="check" /></li>
                        <li class="Message-Name"><%#Eval("LinkName") %> </li>
                        <li class="cz"> <a href="LinkInfo.aspx?L_id=<%#Eval("ID") %>">编辑</a>
                            <asp:LinkButton ID="LinkButton1" CommandName="Del"  runat="server" CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('您确定要删除吗？')">删除</asp:LinkButton>
                            </li>
                        <li class="cz">
                            <asp:TextBox ID="txtSort" runat="server" CssClass="px0415" Text='<%#Eval("Sort")%>' onkeypress="return isNumber(event);" ></asp:TextBox>
                            <asp:LinkButton ID="lbtSort" CommandArgument='<%#Eval("ID")%>' CommandName="Sort" runat="server">更新</asp:LinkButton></li>
                        <div class="clear"></div>
                       </ul>
                          <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("ID") %>' />
                      </ItemTemplate>
                    </asp:Repeater>
                    
                <!--课程分类列表 结束-->  
                </div>
            </div>
            </div>

        <!--操作+翻页 开始-->
        <div class="bot">
          <div class="page">
          <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"
            FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" PageSize="10">
          </webdiyer:AspNetPager>
          </div>
        <%--<div class="page">共 <span class="underline">265</span> 条数据，当前第 1 页，每页  15  条，<a href="">首页</a> <a href="">上一页</a> <span class="hover"><a href="">1</a></span> <span class="num"><a href="">2</a></span> <span class="num"><a href="">3</a></span> <span class="num"><a href="">4</a></span> <span class="num"><a href="">5</a></span> <a href="">下一页</a>  <a href="">尾页</a></div>--%>
            <asp:DropDownList ID="ddlSelect" runat="server" CssClass="S-xl">
             <asp:ListItem Value="0" Text="-请选择操作-"></asp:ListItem>
             <asp:ListItem Value="1" Text="-删除-"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnDo" runat="server" Text="确  定" CssClass="ss-btn" 
                onclick="btnDo_Click" /> 
        
</div>
        <!--操作+翻页 结束-->


    </div>
    <div class="clear"></div>
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

