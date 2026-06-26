<%@ Page Title="" Language="C#" MasterPageFile="~/en/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="EnIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../css/swiper-bundle.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/swiper-bundle.min.js"></script>
    <style type="text/css">
        .nav_fix {
            background: url(/images/i_bg.png) repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- banner -->
    <div class="ind_banner_swiper">
        <div class="swiper mySwiper">
            <div class="swiper-wrapper">
                <div class="swiper-slide">
                    <video muted playsinline preload="auto" class="ind_banner_swiper_con">
                        <source src="/images/1.mp4" type="video/mp4">
                    </video>
                </div>
                <div class="swiper-slide">
                    <video muted playsinline preload="auto" class="ind_banner_swiper_con">
                        <source src="/images/2.mp4" type="video/mp4">
                    </video>
                </div>
                <div class="swiper-slide">
                    <video muted playsinline preload="auto" class="ind_banner_swiper_con">
                        <source src="/images/3.mp4" type="video/mp4">
                    </video>
                </div>
                <div class="swiper-slide">
                    <video muted playsinline preload="auto" class="ind_banner_swiper_con">
                        <source src="/images/4.mp4" type="video/mp4">
                    </video>
                </div>
                <div class="swiper-slide">
                    <video muted playsinline preload="auto" class="ind_banner_swiper_con">
                        <source src="/images/5.mp4" type="video/mp4">
                    </video>
                </div>
            </div>
            <div class="swiper-pagination"></div>
            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
        </div>
    </div>
    <!-- banner END -->
    <div class="ind_about">
        <div class="main_bgc f_flrb">
            <div class="ind_aboutbg">
                <div class="ind_about_c">
                    <div class="ind_tit wow bounceInLeft">About Dongyu</div>
                    <div class="ind_tits wow bounceInLeft">
                        <asp:Literal ID="ltAboutSummary" runat="server"></asp:Literal></div>
                    <div class="con">
                        <asp:Literal ID="ltAboutContent" runat="server"></asp:Literal>
                    </div>
                    <a href="About.aspx" class="ind_more">Read More</a>
                </div>
                <div class="abo_con f_flra_nc fw_w b_box b_box">
                    <div class="abo_c b_box">
                        <div class="ico ico1"></div>
                        <div class="num">3</div>
                        <div class="tit">Production Bases</div>
                    </div>
                    <div class="abo_c b_box">
                        <div class="ico ico2"></div>
                        <div class="num">180000 Tons</div>
                        <div class="tit">Annual Steel Strip Output</div>
                    </div>
                    <div class="abo_c b_box">
                        <div class="ico ico3"></div>
                        <div class="num">20 Million Meters</div>
                        <div class="tit">Annual Hose/Pipe Output</div>
                    </div>
                    <div class="abo_c b_box">
                        <div class="ico ico4"></div>
                        <div class="num">30,000 sqm</div>
                        <div class="tit">Total Factory Area</div>
                    </div>
                </div>
            </div>
            <div class="ind_about_cimg">
                <asp:Image ID="imgAbout" runat="server" />
            </div>
        </div>
    </div>
    <div class="ind_pro">
        <div class="main_bgc">
            <div class="ind_tit wow bounceInLeft">Products</div>
        </div>
        <div class="swiper mySwiper2">
            <div class="swiper-wrapper">
                <asp:Repeater ID="rptProductClass" runat="server">
                    <ItemTemplate>
                        <div class="swiper-slide">
                            <div class="img_auto">
                                <img src='<%# string.IsNullOrEmpty(Eval("C_Pic").ToString()) ? "" : "/uploadfiles/productClass/" + Eval("C_Pic") %>' alt="" />
                            </div>
                            <div class="ind_pro_c">
                                <div class="title"><%# Eval("EN_Name") %></div>
                                <div class="desc"><%# Eval("EN_Intro") %></div>
                                <a href='Product.aspx?id=<%# Eval("ID") %>' class="ind_more">Read More</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="swiper-pagination"></div>
            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
        </div>
    </div>
    <div class="ind_abob">
        <div class="main_bgc">
            <div class="ind_tit wow bounceInLeft">Production Base</div>
            <div class="news_list ind_abob_list">
                <ul class="w100b f_flrb_nc">
                    <asp:Repeater ID="rptBase" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href="AboutBase.aspx" class="news_la">
                                    <div class="w100b">
                                        <div class="news_limg equ_limg">
                                            <img src='<%# string.IsNullOrEmpty(Eval("Pic_Url").ToString()) ? "" : "/uploadfiles/article/" + Eval("Pic_Url") %>' alt="" />
                                        </div>
                                        <div class="news_lc">
                                            <div class="news_lca">
                                                <div class="abob_tit f_fl_nc">
                                                    <div class="abob_logo img_auto">
                                                        <img src='<%# GetLogo(Eval("CN_Title").ToString()) %>' alt="" />
                                                    </div>
                                                    <div class="title">
                                                        <div class="tit"><%# Eval("EN_Title") %></div>
                                                        <div class="con"><%# Eval("EN_Summary") %></div>
                                                    </div>
                                                </div>
                                                <div class="equ_lc_con">
                                                    <%# Eval("EN_Content") %>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <div class="ind_fbg">
        <div class="tit">Contact Us</div>
        <div class="con">1v1 customized solutions, 360-degree full service</div>
        <a href="Contact.aspx" class="ind_fbga">Click to contact us ></a>
    </div>
    <script type="text/javascript" src="../js/slider.js"></script>
    <script type="text/javascript">
        //banner切换
        // Rotate videos by their own duration: auto-advance to the next slide when the current video ends
        var swiper = new Swiper('.mySwiper', {
            loop: true,
            speed: 1000,
            centeredSlides: true,
            on: {
                init() {
                    playCurrentVideo(this);
                },
                slideChange() {
                    let allV = document.querySelectorAll('.swiper-slide video');
                    allV.forEach(item => {
                        item.pause();
                        item.currentTime = 0;
                    })
                    // Play the current video from the start; auto-advance when it ends
                    playCurrentVideo(this);
                }
            },
            pagination: {
                el: ".swiper-pagination",
                clickable: true,
            },
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev"
            }
        })
        // Play the current slide's video; advance to the next slide when it ends (ended event)
        function playCurrentVideo(sw) {
            let currV = sw.slides[sw.activeIndex].querySelector('video');
            if (currV) {
                currV.play();
                currV.onended = function () {
                    sw.slideNext();
                };
            }
        }
        var swiper2 = new Swiper(".mySwiper2", {
            slidesPerView: "auto",
            centeredSlides: true,
            spaceBetween: 20,
            grabCursor: true,
            loop: true,
            autoplay: {
                delay: 5000,
                disableOnInteraction: false,
            },
            pagination: {
                el: ".swiper-pagination",
                clickable: true,
            },
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev"
            }
        });
    </script>
</asp:Content>
