<%@ Page Title="" Language="C#" MasterPageFile="~/MultiChoiceMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MultiChoiceWeb.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="PageButtons">
        <asp:Button ID="teacherBtn" runat="server" Text="Click if you're a Teacher" /><br />
        <asp:Button ID="studentBtn" runat="server" Text="Click if you're a Student" OnClick="studentBtn_Click" /><br />
    </div>
</asp:Content>
