<%@ Page Title="" Language="C#" MasterPageFile="~/MultiChoiceMaster.Master" AutoEventWireup="true" CodeBehind="AllStudentsMarks.aspx.cs" Inherits="MultiChoiceWeb.AllStudentsMarks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><u>Students' Marks</u></h1>
    <asp:GridView ID="grdMarks" AutoGenerateColumns="true" width="100%" runat="server"></asp:GridView>
    <br />
    <asp:Button ID="btnLogOut" runat="server" Text="LogOut" OnClick="btnLogOut_Click" />
</asp:Content>
