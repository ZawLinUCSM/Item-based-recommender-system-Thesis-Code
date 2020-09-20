<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NeighborUserLists.aspx.cs" Inherits="NeighborUserLists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="grid" runat="server" DataKeyNames="UserID" Width="100%">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="Similar Users" ReadOnly="True" />
        </Columns>
    </asp:GridView>
    <p>
        <asp:Button ID="computePCC" Text="Calculate PCC" runat="server" OnClick="computePCC_Click" />
    </p>
</asp:Content>

