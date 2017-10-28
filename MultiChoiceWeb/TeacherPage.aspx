<%@ Page Title="" Language="C#" MasterPageFile="~/MultiChoiceMaster.Master" AutoEventWireup="true" CodeBehind="TeacherPage.aspx.cs" Inherits="MultiChoiceWeb.TeacherPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><u>Teacher Options</u></h1>
    <br />
    <asp:Button ID="btnMakeTest" runat="server" Text="Make Test" OnClick="btnMakeTest_Click" />
    <br />
    <br />
    <asp:Button ID="btnViewAllMarks" runat="server" Text="View Marks" OnClick="btnViewAllMarks_Click" />
    <br />
    <br />
    <asp:button ID="btnLogOut" runat="server" text="Log Out" OnClick="btnLogOut_Click" />
</asp:Content>
