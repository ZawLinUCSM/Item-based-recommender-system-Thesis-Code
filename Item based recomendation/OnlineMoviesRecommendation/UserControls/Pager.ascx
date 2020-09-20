<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager.ascx.cs" Inherits="UserControls_Pager" %>
Page
<asp:Label ID="currentPageLabel" runat="server"></asp:Label>of
<asp:Label ID="howManyPagesLabel" runat="server"></asp:Label>
|
<asp:HyperLink ID="previousLink" runat="server">Previous</asp:HyperLink>
<asp:Repeater ID="pagesRepeater" runat="server">
    <ItemTemplate>
        <asp:HyperLink ID="hyperLink" runat="server" Text='<%#Eval("Page") %>' NavigateUrl='<%Eval("Url") %>'>
        </asp:HyperLink>
    </ItemTemplate>
</asp:Repeater>
<asp:HyperLink ID="nextLink" runat="server">Next</asp:HyperLink>
