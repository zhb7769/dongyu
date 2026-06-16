<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="css/swiper-bundle.min.css" rel="stylesheet" />
    <script type="text/javascript" src="js/swiper-bundle.min.js"></script>
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
                    <div class="ind_tit wow bounceInLeft">关于东宇</div>
                    <div class="ind_tits wow bounceInLeft">
                        <asp:Literal ID="ltAboutSummary" runat="server"></asp:Literal></div>
                    <div class="con">
                        <asp:Literal ID="ltAboutContent" runat="server"></asp:Literal>
                    </div>
                    <a href="About.aspx" class="ind_more">查看更多</a>
                </div>
                <div class="abo_con f_flra_nc fw_w b_box b_box">
                    <div class="abo_c b_box">
                        <div class="ico ico1"></div>
                        <div class="num">3</div>
                        <div class="tit">不锈钢生产基地</div>
                    </div>
                    <div class="abo_c b_box">
                        <div class="ico ico2"></div>
                        <div class="num">180000 吨</div>
                        <div class="tit">不锈钢带年产值</div>
                    </div>
                    <div class="abo_c b_box">
                        <div class="ico ico3"></div>
                        <div class="num">2000 万米</div>
                        <div class="tit">软管/钢管年产值</div>
                    </div>
                    <div class="abo_c b_box">
                        <div class="ico ico4"></div>
                        <div class="num">30000 平方米</div>
                        <div class="tit">厂房总占地</div>
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
            <div class="ind_tit wow bounceInLeft">产品中心</div>
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
                                <div class="title"><%# Eval("CN_Name") %></div>
                                <div class="desc"><%# Eval("CN_Intro") %></div>
                                <a href='Product.aspx?cid=<%# Eval("ID") %>' class="ind_more">查看更多</a>
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
            <div class="ind_tit wow bounceInLeft">生产基地</div>
            <div class="news_list ind_abob_list">
                <ul class="w100b f_flrb_nc">
                    <asp:Repeater ID="rptBase" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="news_la">
                                    <div class="w100b">
                                        <div class="news_limg equ_limg">
                                            <img src='<%# string.IsNullOrEmpty(Eval("Pic_Url").ToString()) ? "" : "/uploadfiles/article/" + Eval("Pic_Url") %>' alt="" />
                                        </div>
                                        <div class="news_lc">
                                            <div class="news_lca">
                                                <div class="abob_tit f_fl_nc">
                                                    <div class="abob_logo img_auto">
                                                        <img src="images/logo2.png" alt="" />
                                                    </div>
                                                    <div class="title">
                                                        <div class="tit"><%# Eval("CN_Title") %></div>
                                                        <div class="con"><%# Eval("CN_Summary") %></div>
                                                    </div>
                                                </div>
                                                <div class="equ_lc_con">
                                                    <%# Eval("CN_Content") %>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <div class="ind_fbg">
        <div class="tit">联系我们</div>
        <div class="con">1v1按需求定制个性化方案，全程360度服务</div>
        <a href="Contact.aspx" class="ind_fbga">点击与我们联系 ></a>
    </div>
    <script type="text/javascript" src="js/slider.js"></script>
    <script type="text/javascript">
        //banner切换
        // 视频按各自实际时长轮换：当前视频播放结束(ended)后自动切换到下一张
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
                    // 全部暂停+回到起点
                    allV.forEach(item => {
                        item.pause();
                        item.currentTime = 0;
                    })
                    // 当前视频从头播放，播放结束自动切到下一张
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
        // 播放当前 slide 的视频，播放结束(ended)自动切到下一张
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
