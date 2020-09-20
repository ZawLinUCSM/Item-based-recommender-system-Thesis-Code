<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>
        Welcome !<br />
            Our Online Movie Recommendation System
       </h1>
    <asp:HyperLink ID="HeaderLink" ImageUrl="~/Images/Systemlogo.png" NavigateUrl="~/"
        ToolTip="Online Car Recommendation Logo" Text="System Logo" runat="server"></asp:HyperLink>
    <br />
    <br />
    <br />
    <span class="CatalogTitle">If You Have Any Problem For Using This System And Any Other
        Problems </span>
        <p>You Can Contact <br/></p>
            <p>You Can Ask Any Question </p> 
           <p><br/>By Sending Email To</p> 
        <asp:HyperLink ID ="contactLink" runat ="server" Text="omRecommendation@gmail.com"></asp:HyperLink>
</asp:Content>
