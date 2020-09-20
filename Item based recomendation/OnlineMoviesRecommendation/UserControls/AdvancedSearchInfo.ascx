<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdvancedSearchInfo.ascx.cs"
    Inherits="UserControls_AdvancedSearchInfo" %>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAdvanced" runat="server" Text="Search"></asp:Label>
<br />
<br />
<asp:Label ID="lblBrand" runat="server" Text="Brand :"></asp:Label>
<asp:DropDownList ID="brandList" runat="server" Width="150px">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="lblModel" runat="server" Text="Model:"></asp:Label>
<asp:DropDownList ID="modelList" runat="server" Width="150px">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="lblYear" runat="server" Text="  Year :"></asp:Label>
<asp:DropDownList ID="year1List" runat="server" Width="150px">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
<asp:DropDownList ID="price1List" runat="server" Width="70px">
</asp:DropDownList>
&nbsp;
<asp:DropDownList ID="price2List" runat="server" Width="70px">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="lblType" runat="server" Text="Type :"></asp:Label>
<asp:DropDownList ID="typeList" runat="server" Width="150px">
</asp:DropDownList>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="searchAdvanced"
    runat="server" Text="Search" Width="100px" onclick="searchAdvanced_Click"/>