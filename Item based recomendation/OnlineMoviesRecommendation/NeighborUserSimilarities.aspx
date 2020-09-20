<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NeighborUserSimilarities.aspx.cs" Inherits="NeighborUserSimilarities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="grid" runat="server">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="Users" />
            <asp:BoundField DataField="Movies" HeaderText="Movie" />
            <asp:BoundField DataField="Rating" HeaderText="Rating" />
        </Columns>
    </asp:GridView>
     <p>
        <asp:Button ID="computePrediction" Text="Calculate Prediction" runat="server" OnClick="computePrediction_Click"  />
    </p>

</asp:Content>

