<%@ Page Title="" Language="C#" MasterPageFile="~/en/MasterPage.master" AutoEventWireup="true" CodeFile="ProductApplication.aspx.cs" Inherits="EnProductApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_pro">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">Products</div>
                <div class="all_bantit"><a href="Index.aspx">Home</a><i>></i><span>Products</span><i>></i><span>Application</span></div>
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
                    <div class="det_tit">Application</div>
                    <div class="det_c">
                        <!-- content -->
                        <asp:Literal ID="ltApplication" runat="server"></asp:Literal>
                        <!-- end -->
                    </div>
                    <div class="proa_nav f_fl fw_w" id="divSubNav" runat="server">
                        <asp:Repeater ID="rptSubCategory" runat="server" OnItemDataBound="rptSubCategory_ItemDataBound">
                            <ItemTemplate>
                                <div class="proa_nav_a<%# Container.ItemIndex == 0 ? " active" : "" %>" data-index="<%# Container.ItemIndex %>"><%# Eval("EN_Name") %></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="proa_cbg">
                        <asp:Repeater ID="rptSubContent" runat="server" OnItemDataBound="rptSubContent_ItemDataBound">
                            <ItemTemplate>
                                <div class="proa_con f_fl fw_w<%# Container.ItemIndex == 0 ? " active" : "" %>" data-index="<%# Container.ItemIndex %>">
                                    <asp:Repeater ID="rptProducts" runat="server">
                                        <ItemTemplate>
                                            <div class="proa_c">
                                                <div class="img_auto"><img src='/uploadfiles/product/<%# Eval("pro_img") %>' alt='<%# Eval("EN_Name") %>' /></div>
                                                <div class="tit"><%# Eval("EN_Name") %></div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
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
            $(".proa_nav_a").click(function () {
                var idx = $(this).index();
                $(".proa_nav_a").removeClass('active').eq(idx).addClass('active');
                $(".proa_cbg .proa_con").removeClass('active').eq(idx).addClass('active');
            });
        });
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]);
            return null;
        }
    </script>
</asp:Content>
