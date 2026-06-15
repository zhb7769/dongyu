<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleClassList.aspx.cs" Inherits="admin_Article_ArticleClassList" %>
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

<uc1:Top ID="Top1" runat="server" />



<!--container begin -->
<div id="content">
	<!--leftbar begin-->
	<uc2:Memu ID="Memu1" runat="server" />
    <!--leftbar end-->
    <div class="Main">
    	<div class="Showpath">网站管理平台  > <span class="guide-txt">文章管理</span></div>
        <!--欢迎及上次登录 开始-->

         <div class="add-main">
          <div class="guide">
            	<ul class="ul-nav02">
                	<li class="hover1" >文章分类</li>
                    <li><a href="ArticleClassInfo.aspx">添加分类</a></li>
                    <div class="clear"></div>                                  
                </ul>
            </div>            

            <div class="cMain-w nb" >
                <div class="cMain-title b-t">
                    <ul class="ul-list"> 
                        <li class="sel"></li>
                        <li class="Class-Name">分类名称</li>


                        <li class="Time">排序</li>                
                        <li class="cz">操作</li>
                        <div class="clear"></div>
                    </ul>
                </div>
                <div class="cMain-con s2" >
                <!--课程分类列表 开始-->
                <asp:Repeater ID="rpt_list" runat="server" onitemcommand="rpt_list_ItemCommand">
                    <ItemTemplate>
                         <ul class="ul-list l"> 
                            <li class="sel"></li>
                            <li class="Class-Name"><div  style='width:100%; padding-left:<%# Convert.ToInt32(Eval("Depth"))*10%>px;'><%# Eval("CN_Name")%></div></li>
                            <li class="Time"> <%# Eval("Sort")%> </li>                
                            <li class="cz"> <a href='ArticleClassInfo.aspx?C_id=<%#Eval("ID") %>'>编辑</a>
                            <asp:LinkButton ID="lkbtnDel" runat="server" CommandName="Del" CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('您确定要删除吗？')" >删除</asp:LinkButton></li>
                            <div class="clear"></div>
                         </ul>
                    </ItemTemplate>
                </asp:Repeater>
                
                  <%--  <ul class="ul-list l"> 
                        <li class="sel"></li>
                        <li class="Class-Name">分类名称</li>
                        
                        <li class="Time">3</li>                
                        <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul>
                    <ul class="ul-list  l"> 
                       <li class="sel"></li>
                        <li class="Class-Name">分类名称</li>
                        
                        <li class="Time">3</li>                
                        <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul>

                    <ul class="ul-list l"> 
						<li class="sel"></li>
                        <li class="Class-Name">分类名称</li>
                        
                        <li class="Time">3</li>                
                        <li class="cz"> <a href="add_newsclass.html">编辑</a> <a href="">删除</a></li>
                        <div class="clear"></div>
                    </ul>
                    <ul class="ul-list l"> 
						<li class="sel"></li>
                        <li class="Class-Name">分类名称</li>
                        
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
        <div class="page">共 <span class="underline">265</span> 条数据，当前第 1 页，每页  15  条，<a href="">首页</a> <a href="">上一页</a> <span class="hover"><a href="">1</a></span> <span class="num"><a href="">2</a></span> <span class="num"><a href="">3</a></span> <span class="num"><a href="">4</a></span> <span class="num"><a href="">5</a></span> <a href="">下一页</a>  <a href="">尾页</a></div>
        
</div>--%>
        <!--操作+翻页 结束-->


    </div>
    <div class="clear"></div>
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
