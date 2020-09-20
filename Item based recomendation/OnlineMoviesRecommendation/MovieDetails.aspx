<%@ Page Title="Online Movie Recommendation: Movie Details Page" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="MovieDetails.aspx.cs" Inherits="MovieDetails" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Image ID="productImage" runat="server" />
    <br />
    <b>Movie Name :</b>&nbsp;&nbsp;
    <asp:Label class="labelContent" ID="lblname" runat="server" Text="Label"></asp:Label>
    <br />
    <b>Genere  :</b>&nbsp;&nbsp;
    <asp:Label ID="lblgenere" CssClass="labelContent " runat="server" Text="Label"></asp:Label>
    <br />
    <b>Cast / Director :</b>&nbsp;&nbsp;
    <asp:Label ID="lblcast" runat="server" CssClass="labelContent " Text="Label"></asp:Label>
    <br />
    <b>Language :</b>&nbsp;&nbsp;
    <asp:Label ID="lbllanguage" runat="server" CssClass="labelContent " Text="Label"></asp:Label>
    <br />
    <b>Country :</b>&nbsp;&nbsp;
    <asp:Label ID="lblcountry" runat="server" CssClass="labelContent " Text="Label"></asp:Label>
    <br />
    <b>Duration :</b>&nbsp;&nbsp;
    <asp:Label ID="lblduration" runat="server" CssClass="labelContent " Text="Label"></asp:Label>
    <br />
    <b>Release Date :</b>&nbsp;&nbsp;
    <asp:Label ID="lblreleasedate" runat="server" CssClass="labelContent " Text="Label"></asp:Label>
    <br />
    <b>Category :</b>&nbsp;&nbsp;
    <asp:Label ID="lblcategory" runat="server" CssClass="labelContent " Text="Label"></asp:Label>
    <br />
    <b>Description :</b>&nbsp;&nbsp;
    <asp:Label ID="lbldescription" runat="server" CssClass="labelContent " Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblrating" runat="server" Text="Rating :"></asp:Label>
    <dx:ASPxComboBox ID="cboRating" runat="server" Height="25px" Width="262px">
        <Items>
            <dx:ListEditItem Text="1 Star" Value="0" />
            <dx:ListEditItem Text="2 Star" Value="1" />
            <dx:ListEditItem Text="3 Star" Value="2" />
            <dx:ListEditItem Text="4 Star" Value="3" />
            <dx:ListEditItem Text="5 Star" Value="4" />
        </Items>
    </dx:ASPxComboBox>
    </span>
    <br />
    <br />
    <asp:Button ID="btnContinue" Text="Continue" runat="server" OnClick="btnContinue_Click" />
    <br />
    <br />
</asp:Content>
