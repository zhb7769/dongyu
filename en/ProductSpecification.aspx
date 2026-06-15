<%@ Page Title="" Language="C#" MasterPageFile="~/en/MasterPage.master" AutoEventWireup="true" CodeFile="ProductSpecification.aspx.cs" Inherits="EnProductSpecification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_pro">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">Products</div>
                <div class="all_bantit"><a href="Index.aspx">Home</a><i>></i><span>Products</span><i>></i><span>Specification</span></div>
            </div>
        </div>
        <div class="det_nav">
            <ul class="w100b f_flra">
                <asp:Repeater ID="rptCategory" runat="server">
                    <ItemTemplate>
                        <li><a href='Product.aspx?id=<%# Eval("ID") %>' id='nav_<%# Eval("ID") %>'><%# Eval("EN_Name") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_tit">Specification</div>
                    <div class="det_c">
                        <!-- content -->
                        <asp:Literal ID="ltSpec" runat="server"></asp:Literal>
                        <!-- end -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../js/slider.js"></script>
    <script type="text/javascript">
        $(function () {
            var urlQuery = GetQueryString("id");
            if (urlQuery != null && urlQuery !== "") {
                $("#nav_" + urlQuery).addClass("act");
            }
        });
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]);
            return null;
        }
    </script>
</asp:Content>
