<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="NewsList" %>

<%@ Register Src="UserControl/Pager_Backstage.ascx" TagName="Pager_Backstage" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_news">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated"><asp:Literal ID="ltBanTitle" runat="server"></asp:Literal></div>
                <div class="all_bantit"><a href="Index.aspx">首页</a><i>></i><span><asp:Literal ID="ltNavTitle" runat="server"></asp:Literal></span></div>
            </div>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="news_list">
                        <ul>
                            <asp:Repeater ID="rptNews" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="news_la">
                                            <div class="w100b f_fl_nc">
                                                <a href='NewsDetail.aspx?id=<%# Eval("ID") %>' class="news_limg">
                                                    <img src='<%# string.IsNullOrEmpty(Eval("Pic_Url").ToString()) ? "" : "/uploadfiles/news/" + Eval("Pic_Url") %>' alt="" />
                                                </a>
                                                <div class="news_lc">
                                                    <a href='NewsDetail.aspx?id=<%# Eval("ID") %>' class="news_lca">
                                                        <div class="news_lc_tit"><%# Eval("CN_Title") %></div>
                                                        <div class="news_lc_con"><%# Eval("CN_Summary") %></div>
                                                    </a>
                                                    <div class="news_lc_time"><span><%# Convert.ToDateTime(Eval("CreateTime")).ToString("yyyy-MM-dd") %></span></div>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="main_page">
                        <uc1:Pager_Backstage ID="Pager_Backstage1" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
