<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewsDetail.aspx.cs" Inherits="NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_contact">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">资讯中心</div>
                <div class="all_bantit"><a href="Index.aspx">首页</a><i>></i><a href="NewsList.aspx">资讯中心</a><i>></i><span>资讯详情</span></div>
            </div>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa news_det">
                    <div class="det_tit"><asp:Literal ID="ltTitle" runat="server"></asp:Literal></div>
                    <div class="det_time"><span>发布时间：<asp:Literal ID="ltTime" runat="server"></asp:Literal></span></div>
                    <div class="det_c">
                        <asp:Literal ID="ltContent" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
