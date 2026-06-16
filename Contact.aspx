<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_contact">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">联系我们</div>
                <div class="all_bantit"><a href="Index.aspx">首页</a><i>></i><span>联系我们</span></div>
            </div>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_c">
                        <asp:Literal ID="ltCNContent" runat="server" Mode="PassThrough"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
