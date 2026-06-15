<%@ Page Title="" Language="C#" MasterPageFile="~/en/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="EnContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="det_pb">
        <div class="all_ban top_contact">
            <div class="main_bgc">
                <div class="tit wow bounceInLeft animated">Contact Us</div>
                <div class="all_bantit"><a href="Index.aspx">Home</a><i>></i><span>Contact Us</span></div>
            </div>
        </div>
        <div class="det_con">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_tit">Domestic Business Division</div>
                    <div class="det_c">
                        <asp:Literal ID="ltCNContent" runat="server" Mode="PassThrough"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
        <div class="det_con bg_gray">
            <div class="main_bgc">
                <div class="det_cpa">
                    <div class="det_tit">Overseas Business Division</div>
                    <div class="det_c">
                        <asp:Literal ID="ltENContent" runat="server" Mode="PassThrough"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
