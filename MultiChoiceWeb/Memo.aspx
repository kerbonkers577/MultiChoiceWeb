<%@ Page Title="" Language="C#" MasterPageFile="~/MultiChoiceMaster.Master" AutoEventWireup="true" CodeBehind="Memo.aspx.cs" Inherits="MultiChoiceWeb.Memo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><u>Memo</u></h1>
    <div id="body">
        <asp:Label ID="lblTestName" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblStudentName" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblStudentNum" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:GridView ID="grdMemo" width="100%" AutoGenerateColumns="true" ViewStateMode="Enabled" runat="server"></asp:GridView>
        <br />
        <asp:Label ID="lblMark" runat="server" Text="Label"></asp:Label>
    </div>
    <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
</asp:Content>
