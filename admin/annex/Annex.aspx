<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Annex.aspx.cs" Inherits="admin_annex_Annex" %>
<%@ Register src="../userControl/Top.ascx" tagname="Top" tagprefix="uc1" %>
<%@ Register src="../userControl/Memu.ascx" tagname="Memu" tagprefix="uc2" %>
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
    	<div class="Showpath">网站管理平台  > <span class="guide-txt">下载管理</span></div>
         <div class="add-main">
          <div class="guide">
            	<ul class="ul-nav02">
                	<li class="hover1">下载列表</li>
                    <li  ><a href="AnnexInfo.aspx">添加</a></li>
                    <div class="clear"></div>                                  
                </ul>
            </div>            
            <div class="cMain-w" >
                <div class="cMain-title">
                    <ul class="ul-list">
                        <li class="sel">
                            <input type="checkbox" onclick="GetAllCheckBok(this)" class="check" />
                        </li>
                        <li class="title" style="width: 330px;">名称</li>
                        <li class="order"><span class="underline">排序</span></li>
                        <li class="subclass"><span class="underline">分类</span></li>
                        <li class="date-time"><span class="underline">更新时间</span></li>
                        <li class="cz">操作</li>
                        <div class="clear"></div>
                    </ul>
                </div>
                <div class="productlist" >
                    <asp:Repeater ID="rptAnnex" runat="server" 
                        onitemcommand="rptAnnex_ItemCommand" OnItemDataBound="rptAnnex_ItemDataBound" >
                      <ItemTemplate>
                        <ul class="ul-list"> 
                            <li class="sel">
                                <asp:CheckBox ID="cbDel" runat="server" CssClass="check" />
                                <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("ID") %>' /></li>
                            <li class="title02">
                                <a href='AnnexInfo.aspx?L_id=<%#Eval("ID") %>'>
                                <%#Eval("CN_Title") %></a></li>
                            <li class="order">
                                <asp:TextBox ID="txtSort" runat="server" CssClass="px0415" Text='<%#Eval("Sort") %>' onkeypress="return isNumber(event);"></asp:TextBox>
                                <asp:LinkButton ID="lkbtnSort" runat="server" CommandName="Sort" CommandArgument='<%#Eval("ID") %>'>更新</asp:LinkButton>
                            </li>
                            <li class="subclass">
                                <asp:Label ID="lblProductClass" runat="server" Text='<%#Eval("ClassId") %>'></asp:Label>
                            </li>
                            <li class="date-time">
                                <%#Eval("CreateTime", "{0:yyyy-MM-dd}")%>
                            </li>
                            <li class="cz"><a href='AnnexInfo.aspx?L_id=<%#Eval("ID") %>'>编辑</a>
                                <asp:LinkButton ID="lkbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("ID") %>'
                                    OnClientClick="return confirm('您确定要删除吗？')">删除</asp:LinkButton></li>
                            <div class="clear"></div>
                       </ul>
                      </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            </div>

        <div class="bot">
          <div class="page">
          <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页"
                NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" PageSize="15" OnPageChanged="AspNetPager1_PageChanging">
          </webdiyer:AspNetPager>
          </div>
            <asp:DropDownList ID="ddlSelect" runat="server" CssClass="S-xl">
             <asp:ListItem Value="0" Text="-请选择操作-"></asp:ListItem>
             <asp:ListItem Value="1" Text="-删除-"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnDo" runat="server" Text="确  定" CssClass="ss-btn" 
                onclick="btnDo_Click" /> 
        
</div>


    </div>
    <div class="clear"></div>
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
