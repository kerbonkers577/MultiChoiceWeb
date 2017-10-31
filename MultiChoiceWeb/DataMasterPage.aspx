<%@ Page Title="" Language="C#" MasterPageFile="~/MultiChoiceMaster.Master" AutoEventWireup="true" CodeBehind="DataMasterPage.aspx.cs" Inherits="MultiChoiceWeb.DataMasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grdTest" AutoGenerateColumns="true" ViewStateMode="Enabled" runat="server"></asp:GridView>
    <br />
    <asp:GridView ID="grdTeacher" AutoGenerateColumns="true" ViewStateMode="Enabled" runat="server"></asp:GridView>
    <br />
    <asp:GridView ID="grdQuestion" AutoGenerateColumns="true" ViewStateMode="Enabled" runat="server"></asp:GridView>
    <br />
    <asp:GridView ID="grdStudent" AutoGenerateColumns="true" ViewStateMode="Enabled" runat="server"></asp:GridView>
    <br />
    <asp:GridView ID="grdStudentAnswer" AutoGenerateColumns="true" ViewStateMode="Enabled" runat="server"></asp:GridView>
    <br />
    <asp:GridView ID="grdStudentMark" AutoGenerateColumns="true" ViewStateMode="Enabled" runat="server"></asp:GridView>
    <br />
    <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
</asp:Content>
