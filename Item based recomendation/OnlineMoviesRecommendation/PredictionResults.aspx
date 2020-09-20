<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PredictionResults.aspx.cs" Inherits="PredictionResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:GridView ID="grid" runat="server" DataKeyNames="MovieID" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="MovieName" HeaderText="Movie" />
            <asp:BoundField DataField="Prediction" HeaderText="Prediction" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text="Select" NavigateUrl='<%# "MovieResultDetails.aspx?MovieID="+Eval("MovieID")%>'
                        ID="HyperLink1"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <%--
                 <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text="Select" NavigateUrl='<%# "MovieDetails.aspx?ProductID="+Eval("ProductID")%>'
                        ID="HyperLink1"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
</asp:Content>

