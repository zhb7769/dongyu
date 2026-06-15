<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top.ascx.cs" Inherits="admin_userControl_Top" %>
<div id="header">
	<div class="wra hei68">
        <div class="logo"><img src="../images/admin-logo.gif" /></div>
        <div class="homeclick">
			<a href="../../index.aspx" target="_blank"><img src="../images/view.gif" alt="查看首页" /></a>
        </div>
        <div class="clear"></div>
    </div>
    <div class="wra">
            <!--欢迎-->
        <div class="sign">
        <div class="Status">
        	<ul>
            	<li> 欢迎您！Admin</li>
                <li><a href="../comtact/admin.aspx">账号管理</a></li>
                <li class="Information">您有 <a href="../message/Message.aspx">
                    <asp:Literal ID="litM_Num" runat="server" Text="0"></asp:Literal></a> 条新留言</li>
                <div class="clear"></div>
            </ul>
        </div>
        <div class="Operation" >
        	<ul>
            	<%--<li class="Cancel"><a href="">注销</a></li>--%>
                <li class="Sign-out">
                    <asp:LinkButton ID="lkbtnExit" runat="server" onclick="lkbtnExit_Click">退出</asp:LinkButton></li>
                <div class="clear"></div>
            </ul>
        </div>
        <div class="clear"></div>
        
        
        </div>
        <!--欢迎-->
    
    </div>
</div>