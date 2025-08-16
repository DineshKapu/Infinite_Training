<%@ Page Language="C#" MasterPageFile="~/Web/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Electricity_Prj.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Login</h2>
    <asp:Label runat="server" ID="lblMsg"  CssClass="message-label" />
    <div>
        <asp:Label runat="server" Text="Username" />
        <asp:TextBox runat="server" ID="txtUser" />
    </div>
    <div>
        <asp:Label runat="server" Text="Password" />
        <asp:TextBox runat="server" ID="txtPass" TextMode="Password" />
    </div>
    <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
</asp:Content>
