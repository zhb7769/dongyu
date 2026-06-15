<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager_Backstage.ascx.cs"
    Inherits="UserControl_Pager_Backstage" %>
<script language="javascript" type="text/javascript">
    //只能输入数字
    function inputNum(obj) {
        if (!/^\d*(\d*)?$/.test(obj.value))
            obj.value = obj.value.substr(0, obj.value.length - 1);
    }
</script>
<style type="text/css">
    .pager {
        font-size: 18px;
        color: Black;
        padding: 0;
        text-align: center;
        vertical-align: middle;
        margin: 0 auto;
    }

        .pager .count {
            margin-left: 5px;
            margin-right: 5px;
        }

        .pager .tdw30 {
            width: 30px;
        }

        .pager td {
            height: 26px;
            line-height: 26px;
            padding: 8px 17px;
        }

        .pager .txtNum {
            width: 48px;
            height: 24px;
            line-height: 24px;
            border: 1px solid #e8e8e8;
            text-align: center;
        }

        .pager .none {
            display: none;
        }

        .pager .btn_c {
            display: inline-block;
            vertical-align: middle;
        }

            .pager .btn_c:hover {
                filter: alpha(opacity=70);
                -moz-opacity: 0.7;
                -webkit-opacity: 0.7;
                -khtml-opacity: 0.7;
                opacity: 0.7;
            }
            .pager .now_page {
                color: #c11920;
                font-weight: bold;
            }
</style>
<table cellpadding="0" cellspacing="0" class="pager">
    <tr>
        <%--  <td align="left">
            共
        </td>--%>
        <td>
            <asp:Label ID="lb_iCount" runat="server" Text="0" CssClass="count" Style="display: none;"></asp:Label>
        </td>
        <%--  <td>
            条
        </td>--%>
        <td>
            <asp:ImageButton ID="ib_winxpbutton1" runat="server" ImageUrl="imgs/page_first.png"
                ToolTip="First" OnClick="winxpbutton1_Click" CssClass="btn_c" />
        </td>
        <td>
            <asp:ImageButton ID="ib_winxpbutton2" runat="server" ImageUrl="imgs/page_previous.png"
                ToolTip="Previous" OnClick="winxpbutton2_Click" CssClass="btn_c" />
        </td>
        <td style="" align="right">
            <asp:Label ID="lb_index" runat="server" Text="1" CssClass="now_page"></asp:Label>
        </td>
        <td>/
        </td>
        <td align="left">
            <asp:Label ID="lb_pcount" runat="server" Text="1"></asp:Label>
        </td>
        <td>
            <asp:ImageButton ID="ib_winxpbutton3" runat="server" ImageUrl="imgs/page_next.png"
                ToolTip="Next" OnClick="winxpbutton3_Click" CssClass="btn_c" />
        </td>
        <td>
            <asp:ImageButton ID="ib_winxpbutton4" runat="server" ImageUrl="imgs/page_last.png"
                ToolTip="Last" OnClick="winxpbutton4_Click" CssClass="btn_c" />
        </td>
        <%--<td>
            跳转到第
        </td>--%>
        <td>
            <asp:TextBox ID="txt_Go" runat="server" onpropertychange="inputNum(this)" onpaste="return false"
                CssClass="txtNum" OnTextChanged="winxpbutton5_Click" AutoPostBack="True" Style="display: none;"></asp:TextBox>
        </td>
        <%--<td>
            页
        </td>--%>
        <td>
            <asp:Button ID="bt_go" runat="server" Text="go" OnClick="bt_go_Click" Style="display: none;" />
        </td>
        <td>
            <asp:Label ID="lb_PageSize" runat="server" Text="15" CssClass="none"></asp:Label>
        </td>
    </tr>
</table>
