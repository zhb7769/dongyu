<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AboutCourse.aspx.cs" Inherits="AboutCourse" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_about">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated"><asp:Literal ID="ltBanTitle" runat="server"></asp:Literal></div>
                <div class="all_bantit"><a href="Index.aspx">首页</a><i>></i><span>关于东宇</span><i>></i><span>发展历程</span></div>
            </div>
        </div>
        <div class="det_nav">
            <ul class="w100b f_flra">
                <li><a href="About.aspx">东宇简介</a></li>
                <li><a href="AboutBase.aspx">生产基地</a></li>
                <li><a href="AboutCourse.aspx" class="act">发展历程</a></li>
            </ul>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_tit"><asp:Literal ID="ltTitle" runat="server"></asp:Literal></div>
                    <div class="w_pb">
                        <div class="aboc_box">
                            <asp:Repeater ID="rptCourse" runat="server">
                                <ItemTemplate>
                                    <div class="aboc_item">
                                        <div class="aboc_card">
                                            <div class="aboc_circle"><%# Eval("CN_Title") %></div>
                                            <div class="aboc_text"><%# Eval("CN_Content") %></div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
