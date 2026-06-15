<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_about">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated"><asp:Literal ID="ltBanTitle" runat="server"></asp:Literal></div>
                <div class="all_bantit"><a href="Index.aspx">首页</a><i>></i><span>关于东宇</span><i>></i><span>东宇简介</span></div>
            </div>
        </div>
        <div class="det_nav">
            <ul class="w100b f_flra">
                <li><a href="About.aspx" class="act">东宇简介</a></li>
                <li><a href="AboutBase.aspx">生产基地</a></li>
                <li><a href="AboutCourse.aspx">发展历程</a></li>
            </ul>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_tit"><asp:Literal ID="ltTitle" runat="server"></asp:Literal></div>
                    <div class="det_c">
                        <asp:Literal ID="ltContent" runat="server"></asp:Literal>
                    </div>
                    <div class="w_pb">
                        <div class="abo_con f_flra fw_w b_box b_box">
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
