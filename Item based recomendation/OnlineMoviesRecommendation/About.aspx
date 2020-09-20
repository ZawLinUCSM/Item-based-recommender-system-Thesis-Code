<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" Runat="Server">
 <h1>
        Welcome!<br />
        Our Online Movie Recommendation System</h1>
    <asp:HyperLink ID="HeaderLink" ImageUrl="~/Images/Systemlogo.png" NavigateUrl="~/"
        ToolTip="Online Movie Recommendation Logo" Text="System Logo" runat="server"></asp:HyperLink>
    <br />
    <br />
    <br />  
        <h4>Copyright 2017 August, UCSM(Mandalay)<asp:HyperLink ID ="contactLink" runat ="server" Text="omRecommendation@gmail.com"></asp:HyperLink></h4>
        
</asp:Content>

