<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager_WebPage.ascx.cs"
    Inherits="UserControl_Pager_WebPage" %>
<style type="text/css">
    .pager
    {
        font-size: 14px;
        margin: 0px auto;
        padding: 0px;
        text-align: center;
        vertical-align: middle;
        color: #a0a0a0;
    }
    .pager a
    {
        border: 1px solid #ebecf0;
        display: inline-block;
        color: #3c3c3c;
        padding:7px 12px;
        text-decoration: none;
        background: white;
        margin-right:3px;
    }
    .pager a:hover
    {
        border: 1px solid #ff8560;
        color: #ff8560;
        background: #fdf4f1;
        display: inline-block;
        padding:7px 12px;
        text-decoration: none;
        position:relative;
    }
    .pager .none
    {
        display: none;
    }
    .pager .noneI
    {
        display: none;
    }
    .pager .showI
    {
        display: inline-block;
    }
    .pager .Num
    {
        border: 1px solid #ebecf0;
        color: #3c3c3c;
        width: 26px;
        height: 26px;
    }
    .pager .act
    {
        border: 1px solid #ff6a3f;
        color: White;
        background: #ff6a3f;
        display: inline-block;
        padding:7px 12px;
        text-decoration: none;
        position:relative;
    }
    .pager .pager_f
    {
        color: #868686;
    }
</style>
<table cellpadding="0" cellspacing="0" class="pager">
    <tr>
        <td>
            <asp:LinkButton ID="ib_winxpbutton1" runat="server" Text="|<" OnClick="winxpbutton1_Click"  style="padding:5px 10px;"/>
            <asp:LinkButton ID="LinkButton1" runat="server" Text="1" CssClass="act" OnClick="winxpbutton_Click" />
            <asp:LinkButton ID="LinkButton2" runat="server" Text="2" OnClick="winxpbutton_Click" />
            <asp:LinkButton ID="LinkButton3" runat="server" Text="3" OnClick="winxpbutton_Click" />
            <asp:LinkButton ID="LinkButton4" runat="server" Text="4" OnClick="winxpbutton_Click" />
            <asp:LinkButton ID="LinkButton5" runat="server" Text="5" OnClick="winxpbutton_Click" />
            <asp:LinkButton ID="LinkButton6" runat="server" Text="6" OnClick="winxpbutton_Click" />
            <asp:LinkButton ID="ib_winxpbutton2" runat="server" Text=">|" OnClick="winxpbutton2_Click" style="padding:5px 10px;" />
            <asp:Label ID="lb_PageSize" runat="server" Text="15" CssClass="none"></asp:Label>
        </td>
        <td align="left" style="display: none;">
            &nbsp;&nbsp;<%--共--%>
            <asp:Label ID="lb_iCount" runat="server" Text="0" Style="display: none;" CssClass="noneI"></asp:Label>
            <%--条记录，第--%>
            <asp:Label ID="lb_index" runat="server" Text="1"></asp:Label>/<asp:Label ID="lb_pcount"
                runat="server" Text="1"></asp:Label>
            页&nbsp;&nbsp;
        </td>
    </tr>
</table>
