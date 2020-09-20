<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MovieResultDetails.aspx.cs" Inherits="NewPredictionResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
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
    <%--<asp:Label ID="lblrating" runat="server" Text="Rating :"></asp:Label>
    <dx:ASPxComboBox ID="cboRating" runat="server" Height="25px" Width="262px">
        <Items>
            <dx:ListEditItem Text="1 Star" Value="0" />
            <dx:ListEditItem Text="2 Star" Value="1" />
            <dx:ListEditItem Text="3 Star" Value="2" />
            <dx:ListEditItem Text="4 Star" Value="3" />
            <dx:ListEditItem Text="5 Star" Value="4" />
        </Items>
    </dx:ASPxComboBox>--%>
    <br />
    <p>
        <asp:Button ID="backToHome" Text="Back To Home" runat="server" OnClick="backToHome_Click" />
    </p>
    </span>
</asp:Content>

