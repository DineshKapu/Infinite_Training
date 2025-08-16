<%@ Page Language="C#" MasterPageFile="~/Web/Site.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="Electricity_Prj.Web.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Bill Entry</h2>
    <asp:Label runat="server" ID="lblMsg"  CssClass="message-label" />
    <br />
 
   
    <asp:Label runat="server" Text="Number of Bills To Be Added:" AssociatedControlID="txtTotalBills" />
    <asp:TextBox runat="server" ID="txtTotalBills" />
    <asp:Button runat="server" ID="btnSetTotal" Text="Set" OnClick="btnSetTotal_Click" />
    <br /><br />
 
    
    <asp:Panel runat="server" ID="pnlBillForm" Visible="false">
        <asp:Label runat="server" ID="lblRemaining" Font-Bold="true" />
        <br /><br />
 
        <asp:Label runat="server" Text="Enter Consumer Number:" AssociatedControlID="txtCno" />
        <asp:TextBox runat="server" ID="txtCno" /><br /><br />
 
        <asp:Label runat="server" Text="Enter Consumer Name:" AssociatedControlID="txtCname" />
        <asp:TextBox runat="server" ID="txtCname" /><br /><br />
 
        <asp:Label runat="server" Text="Enter Units Consumed:" AssociatedControlID="txtUnits" />
        <asp:TextBox runat="server" ID="txtUnits" /><br /><br />
 
        <asp:Button runat="server" ID="btnAdd" Text="Add Bill" OnClick="btnAdd_Click" />
    </asp:Panel>
 
    <hr />
 
    <h2>View Last N Bills</h2>
    <p>
    <asp:Label runat="server" ID="lblMsg0"  CssClass="message-label"/>
    </p>
    <asp:Label runat="server" Text="Enter N:" AssociatedControlID="txtN" />
    <asp:TextBox runat="server" ID="txtN" />
    <asp:Button runat="server" ID="btnView" Text="View Bills" OnClick="btnView_Click" />
    <br /><br />
    <asp:GridView runat="server" ID="gvBills" CellPadding="4" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br /><br />
    <asp:Label runat="server" ID="lblSummary" Font-Bold="true" CssClass="summary-label"></asp:Label>
   <div class="details-text"><asp:Literal runat="server" ID="litDetails" ></asp:Literal></div> 
</asp:Content>