<%@ Page Title="" Language="C#" MasterPageFile="~/en/MasterPage.master" AutoEventWireup="true" CodeFile="AboutBase.aspx.cs" Inherits="EnAboutBase" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_about">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated"><asp:Literal ID="ltBanTitle" runat="server"></asp:Literal></div>
                <div class="all_bantit"><a href="Index.aspx">Home</a><i>></i><span>About Dongyu</span><i>></i><span>Production Base</span></div>
            </div>
        </div>
        <div class="det_nav">
            <ul class="w100b f_flra">
                <li><a href="About.aspx">Company Profile</a></li>
                <li><a href="AboutBase.aspx" class="act">Production Base</a></li>
                <li><a href="AboutCourse.aspx">Development History</a></li>
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
                                                                    <img src="../images/logo2.png" alt="" /></div>
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
