<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductSpecification.aspx.cs" Inherits="ProductSpecification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_pro">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">产品中心</div>
                <div class="all_bantit"><a href="Index.aspx">首页</a><i>></i><span>产品中心</span><i>></i><span>产品规格</span></div>
            </div>
        </div>
        <div class="det_nav">
            <ul class="w100b f_flra">
                <asp:Repeater ID="rptCategory" runat="server">
                    <ItemTemplate>
                        <li><a href='Product.aspx?id=<%# Eval("ID") %>' id='nav_<%# Eval("ID") %>'><%# Eval("CN_Name") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_tit">产品规格</div>
                    <div class="det_c">
                        <!-- content -->
                        <asp:Literal ID="ltSpec" runat="server"></asp:Literal>
                        <!-- end -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="js/slider.js"></script>
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
