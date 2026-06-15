<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsClass.aspx.cs" Inherits="admin_news_NewsClass" %>

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
                网站管理平台 > <span class="guide-txt">新闻管理</span></div>
            <!--欢迎及上次登录 开始-->
            <div class="add-main">
                <div class="guide">
                    <ul class="ul-nav02">
                        <li class="hover1">新闻分类</li>
                        <li><a href="NewsClassInfo.aspx">添加分类</a></li>
                        <div class="clear">
                        </div>
                    </ul>
                </div>
                <div class="cMain-w nb">
                    <div class="cMain-title b-t">
                        <ul class="ul-list">
                            <li class="sel"></li>
                            <li class="Class-Name">分类名称</li>
                            <li class="Class-num">文章数</li>
                            <li class="Time">排序</li>
                            <li class="cz">操作</li>
                            <div class="clear">
                            </div>
                        </ul>
                    </div>
                    <div class="cMain-con s2">
                        <!--课程分类列表 开始-->
                        <asp:Repeater ID="rpt_list" runat="server" OnItemCommand="rpt_list_ItemCommand" 
                            onitemdatabound="rpt_list_ItemDataBound">
                            <ItemTemplate>
                                <ul class="ul-list l">
                                    <li class="sel"></li>
                                    <li class="Class-Name"><%# Eval("CN_Name")%></li>
                                    <li class="Class-num">
                                        <asp:Label ID="lblNum" runat="server" Text='<%#Eval("ID") %>'></asp:Label></li>
                                    <li class="Time">
                                        <%# Eval("Sort")%>
                                    </li>
                                    <li class="cz"><a href='NewsClassInfo.aspx?C_id=<%#Eval("ID") %>'>编辑</a>
                                        <asp:LinkButton ID="lkbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("ID") %>'
                                            OnClientClick="return confirm('您确定要删除吗？')">删除</asp:LinkButton></li>
                                    <div class="clear">
                                    </div>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%-- <ul class="ul-list l"> 
                        <li class="sel"></li>
                        <li class="Class-Name">分类名称</li>
                        <li class="Class-num">56</li>
                        <li class="Time">3</li>                
                        <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul>
                    <ul class="ul-list  l"> 
                       <li class="sel"></li>
                        <li class="Class-Name">分类名称</li>
                        <li class="Class-num">56</li>
                        <li class="Time">3</li>                
                        <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul>
                    <div>
                        <ul class="ul-list l"> 
                           <li class="sel"></li>
                            <li class="Class-Name">分类名称</li>
                            <li class="Class-num">56</li>
                            <li class="Time">3</li>                
                            <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                            <div class="clear"></div>
                        </ul>
                        <ul class="ul-list l"> 
                               <li class="sel"></li>
                            <li class="Class-Name">分类名称</li>
                            <li class="Class-num">56</li>
                            <li class="Time">3</li>                
                            <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                            <div class="clear"></div>
                        </ul><ul class="ul-list l"> 
                        <li class="sel"></li>
                        <li class="Class-Name">分类名称</li>
                        <li class="Class-num">56</li>
                        <li class="Time">3</li>                
                        <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                        </ul>
                        <ul class="ul-list l"> 
						<li class="sel"></li>
                        <li class="Class-Name cl02">分类名称</li>
                        <li class="Class-num">56</li>
                        <li class="Time">3</li>                
                        <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                        </ul>
                        <ul class="ul-list l"> 
                            <li class="sel"></li>
                            <li class="Class-Name cl02">分类名称</li>
                            <li class="Class-num">56</li>
                            <li class="Time">3</li>                
                            <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                            <div class="clear"></div>
                        </ul>
                        <ul class="ul-list l"> 
                            <li class="sel"></li>
                            <li class="Class-Name cl02">分类名称</li>
                            <li class="Class-num">56</li>
                            <li class="Time">3</li>                
                            <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                            <div class="clear"></div>
                        </ul>
                        
                        
                         <div>
                            <ul class="ul-list l"> 
                                <li class="sel"></li>
                                <li class="Class-Name cl02">分类名称</li>
                                <li class="Class-num">56</li>
                                <li class="Time">3</li>                
                                <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                                <div class="clear"></div>
                            </ul>
                            
                            
                            
                            <div>
                            <ul class="ul-list l"> 
                                <li class="sel"></li>
                                <li class="Class-Name cl03">分类名称</li>
                                <li class="Class-num">56</li>
                                <li class="Time">3</li>                
                                <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                                <div class="clear"></div>
                            </ul>
                           
                            <ul class="ul-list l"> 
                                <li class="sel"></li>
                                <li class="Class-Name cl03">分类名称</li>
                                <li class="Class-num">56</li>
                                <li class="Time">3</li>                
                                <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                                <div class="clear"></div>
                            </ul>
                            <ul class="ul-list l"> 
                                <li class="sel"></li>
                                <li class="Class-Name cl03">分类名称</li>
                                <li class="Class-num">56</li>
                                <li class="Time">3</li>                
                                <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                                <div class="clear"></div>
                            </ul>
                        </div>
                            
                            
                           
                            <ul class="ul-list l"> 
                                <li class="sel"></li>
                                <li class="Class-Name cl03">分类名称</li>
                                <li class="Class-num">56</li>
                                <li class="Time">3</li>                
                                <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                                <div class="clear"></div>
                            </ul>
                            <ul class="ul-list l"> 
                                <li class="sel"></li>
                                <li class="Class-Name">分类名称</li>
                                <li class="Class-num">56</li>
                                <li class="Time">3</li>                
                                <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                                <div class="clear"></div>
                            </ul>
                        </div>
                        
                        
                       
                        <ul class="ul-list l"> 
                            <li class="sel"></li>
                            <li class="Class-Name">分类名称</li>
                            <li class="Class-num">56</li>
                            <li class="Time">3</li>                
                            <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                            <div class="clear"></div>
                        </ul>
                        <ul class="ul-list l"> 
                            <li class="sel"></li>
                            <li class="Class-Name">分类名称</li>
                            <li class="Class-num">56</li>
                            <li class="Time">3</li>                
                            <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                            <div class="clear"></div>
                        </ul>
                    </div>
                    <ul class="ul-list l"> 
						<li class="sel"></li>
                        <li class="Class-Name">分类名称</li>
                        <li class="Class-num">56</li>
                        <li class="Time">3</li>                
                        <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul>
                    <ul class="ul-list l"> 
						<li class="sel"></li>
                        <li class="Class-Name">分类名称</li>
                        <li class="Class-num">56</li>
                        <li class="Time">3</li>                
                        <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul> --%>
                        <!--课程分类列表 结束-->
                    </div>
                </div>
            </div>
            <!--操作+翻页 开始-->
            <%--<div class="bot">
        
        <select name="jumpMenu" id="jumpMenu" class="S-xl" >
        <option>-请选择操作-</option>
        <option>置顶</option>
        <option>删除</option>
  		</select> 
  <input type="button" class="ss-btn" value="查 询" /></div>--%>
            <!--操作+翻页 结束-->
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
