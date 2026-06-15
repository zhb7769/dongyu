<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="css/swiper-bundle.min.css" rel="stylesheet" />
    <script type="text/javascript" src="js/swiper-bundle.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_pro">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">产品中心</div>
                <div class="all_bantit"><a href="Index.aspx">首页</a><i>></i><span>产品中心</span></div>
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
                    <div class="det_tit">产品介绍</div>
                    <div class="pro_c f_flrb_nc">
                        <div class="det_c flew_1">
                            <!-- content -->
                            <asp:Literal ID="ltIntro" runat="server"></asp:Literal>
                            <!-- end -->
                        </div>
                        <div class="pro_ibg">
                            <div class="pro_ibg2">
                                <a id="linkSpec" runat="server" class="pro_ia f_flrb">
                                    <div class="flex_1 f_fl">
                                        <i class="pro_i1"></i>
                                        <div class="text flex_1">产品规格</div>
                                    </div>
                                    <i class="pro_ir"></i>
                                </a>
                                <a id="linkApp" runat="server" class="pro_ia f_flrb">
                                    <div class="flex_1 f_fl">
                                        <i class="pro_i2"></i>
                                        <div class="text flex_1">产品应用</div>
                                    </div>
                                    <i class="pro_ir"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="pro_img">
                        <div class="swiper mySwiper">
                            <div class="swiper-wrapper">
                                <asp:Repeater ID="rptImages" runat="server">
                                    <ItemTemplate>
                                        <div class="swiper-slide">
                                            <div class="img_auto">
                                                <img src='/uploadfiles/product/<%# Eval("pro_img") %>' alt='<%# Eval("CN_Name") %>' />
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="swiper-button-next"></div>
                            <div class="swiper-button-prev"></div>
                        </div>
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
        var swiper = new Swiper(".mySwiper", {
            slidesPerView: 3,
            spaceBetween: 20,
            loop: true,
            autoplay: {
                delay: 3000,
                disableOnInteraction: false,
                pauseOnMouseEnter: true
            },
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },
        });
    </script>
</asp:Content>
