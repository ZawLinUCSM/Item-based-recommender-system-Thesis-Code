<%@ Page Title="Admin Add New Product Page" Language="C#" MasterPageFile="~/OCRAdmin.master" AutoEventWireup="true"
    CodeFile="AdminAddMovie.aspx.cs" Inherits="AdminAddMovie" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle ">System Admin
        <br />
        Add new Movie</span></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <p>
        <asp:Label ID="statusLabel" runat="server" CssClass="AdminError"></asp:Label></p>
    <p>
        <span class="WideLabel">Category :</span>
        <dx:ASPxComboBox ID="categoryList" runat="server" Height="20px" Width="262px">
        </dx:ASPxComboBox>
    </p>
    <p>
        <span class="WideLabel">Movie Name :</span>
        <dx:ASPxTextBox ID="txtName" runat="server" Height="19px" Width="262px">
        </dx:ASPxTextBox>
    </p>
    <p>
        <span class="WideLabel">Genere :</span>
        <dx:ASPxTextBox ID="txtGenere" runat="server" Height="16px" Width="262px">
        </dx:ASPxTextBox>
    </p>
    <p>
        <span class="WideLabel">Cast/ Director:</span>
        <dx:ASPxTextBox ID="txtDirector" runat="server" Height="19px" Width="262px">
        </dx:ASPxTextBox>
    </p>
    <p>
        <span class="WideLabel">Country :<dx:ASPxComboBox ID="cboCountry" runat="server" Height="25px" Width="262px">
            <Items>
                <dx:ListEditItem Text="Hong Koung" Value="10" />
                <dx:ListEditItem Text="Germany" Value="9" />
                <dx:ListEditItem Text="India" Value="8" />
                <dx:ListEditItem Text="South Korea" Value="7" />
                <dx:ListEditItem Text="Chinese" Value="6" />
                <dx:ListEditItem Text="Japan" Value="5" />
                <dx:ListEditItem Text="Russia" Value="4" />
                <dx:ListEditItem Text="Italy" Value="3" />
                <dx:ListEditItem Text="France" Value="2" />
                <dx:ListEditItem Text="United Kingdom" Value="1" />
                <dx:ListEditItem Text="United States" Value="0" />
            </Items>
        </dx:ASPxComboBox>
        </span>
        &nbsp;
    </p>
    <p>
        <span class="WideLabel">Language :<dx:ASPxComboBox ID="cboLanguage" runat="server" Height="25px" Width="262px">
            <Items>
                <dx:ListEditItem Text="English (United States)" Value="0" />
                <dx:ListEditItem Text="English (United Kingdom)" Value="1" />
                <dx:ListEditItem Text="Russia" Value="2" />
                <dx:ListEditItem Text="Traditional Chinese" Value="3" />
                <dx:ListEditItem Text="Burmese" Value="4" />
                <dx:ListEditItem Text="Korea" Value="5" />
                <dx:ListEditItem Text="German" Value="6" />
                <dx:ListEditItem Text="Italian" Value="7" />
            </Items>
        </dx:ASPxComboBox>
        </span>
    </p>
    <p>
        <span class="WideLabel">Duration :</span>
        <dx:ASPxTimeEdit ID="teDuration" runat="server" Height="28px" Width="262px" DateTime="12/29/2016 21:56:51" DisplayFormatString="hh:mm" EditFormat="Custom">
        </dx:ASPxTimeEdit>
    </p>
    <p>
        <span class="WideLabel">Release Date :</span>
        <dx:ASPxDateEdit ID="dtReleaseDate" runat="server" Height="28px" Width="259px">
        </dx:ASPxDateEdit>
        <p>
            <span class="WideLabel">Description :</span>
            <dx:ASPxTextBox ID="newDescription" runat="server" Width="262px" Height="30px" TextMode="MultiLine"></dx:ASPxTextBox>
        </p>
        <p>
            Thumbnail File name
        <asp:Label ID="Image1Label" runat="server"></asp:Label>
            <asp:FileUpload ID="image1FileUpload" runat="server" />&nbsp;&nbsp;
        <asp:Button ID="upload1Button" runat="server" Text="Upload" OnClick="upload1Button_Click" />
            <br />
            <asp:Image ID="image1" runat="server" />
        </p>
        <p>
            Image  File name
        <asp:Label ID="Image2Label" runat="server"></asp:Label>
            <asp:FileUpload ID="image2FileUpload" runat="server" />&nbsp;&nbsp;
        <asp:Button ID="upload2Button" runat="server" Text="Upload" OnClick="upload2Button_Click" />
            <br />
            <asp:Image ID="image2" runat="server" />
        </p>
        <p>
            <asp:Button ID="createProduct" runat="server" Text="Create Movie" OnClick="createProduct_Click" />
        </p>
</asp:Content>
