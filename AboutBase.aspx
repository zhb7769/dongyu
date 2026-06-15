<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AboutBase.aspx.cs" Inherits="AboutBase" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_about">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated"><asp:Literal ID="ltBanTitle" runat="server"></asp:Literal></div>
                <div class="all_bantit"><a href="Index.aspx">首页</a><i>></i><span>关于东宇</span><i>></i><span>生产基地</span></div>
            </div>
        </div>
        <div class="det_nav">
            <ul class="w100b f_flra">
                <li><a href="About.aspx">东宇简介</a></li>
                <li><a href="AboutBase.aspx" class="act">生产基地</a></li>
                <li><a href="AboutCourse.aspx">发展历程</a></li>
            </ul>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_tit"><asp:Literal ID="ltTitle" runat="server"></asp:Literal></div>
                    <div class="w_pb">
                        <div class="news_list abob_list">
                            <ul>
                                <asp:Repeater ID="rptBase" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="news_la">
                                                <div class="w100b f_fl_nc">
                                                    <div class="news_limg equ_limg">
                                                        <img src='<%# Eval("Pic_Url") %>' alt="" />
                                                    </div>
                                                    <div class="news_lc">
                                                        <div class="news_lca">
                                                            <div class="abob_tit f_fl_nc">
                                                                <div class="abob_logo img_auto">
                                                                    <img src="images/logo2.png" alt="" /></div>
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
            </div>
        </div>
    </div>
</asp:Content>
