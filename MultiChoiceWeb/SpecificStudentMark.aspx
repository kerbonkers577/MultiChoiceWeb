<%@ Page Title="" Language="C#" MasterPageFile="~/MultiChoiceMaster.Master" AutoEventWireup="true" CodeBehind="SpecificStudentMark.aspx.cs" Inherits="MultiChoiceWeb.SpecificStudentMark" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grdMarks" runat="server" AutoGenerateColumns="true" Width="100%" ViewStateMode="Enabled" ></asp:GridView>
    <br />
    <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
</asp:Content>
