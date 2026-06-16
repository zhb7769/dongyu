<%@ Page Title="" Language="C#" MasterPageFile="~/en/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="EnSearch" %>

<%@ Register Src="../UserControl/Pager_Backstage.ascx" TagName="Pager_Backstage" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_news">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">Search</div>
                <div class="all_bantit"><a href="Index.aspx">Home</a><i>></i><span>Search</span></div>
                <div class="search_s">
                    <div class="search_sc clearfix">
                        <asp:TextBox ID="txtKeyword" runat="server" CssClass="search_st"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" CssClass="search_sbtn" Text="Search" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="news_list">
                        <ul>
                            <asp:Repeater ID="rptResult" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="news_la">
                                            <div class="w100b f_fl_nc">
                                                <a href='NewsDetail.aspx?id=<%# Eval("ID") %>' class="news_limg">
                                                    <img src='<%# string.IsNullOrEmpty(Eval("Pic_Url").ToString()) ? "" : "/uploadfiles/article/" + Eval("Pic_Url") %>' alt="" />
                                                </a>
                                                <div class="news_lc">
                                                    <a href='NewsDetail.aspx?id=<%# Eval("ID") %>' class="news_lca">
                                                        <div class="news_lc_tit"><%# Eval("EN_Title") %></div>
                                                        <div class="news_lc_con"><%# Eval("EN_Summary") %></div>
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
