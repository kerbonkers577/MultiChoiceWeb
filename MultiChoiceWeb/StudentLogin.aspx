<%@ Page Title="" Language="C#" MasterPageFile="~/MultiChoiceMaster.Master" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="MultiChoiceWeb.StudentLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Head">
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
    <h1><b><u><asp:Label ID="Label4" runat="server" Text="Sudent Login"></asp:Label></u></b></h1>
    <br />
    </div>
    <div id="Body">
        <asp:Label ID="Label1" runat="server" Text="Student Name : "></asp:Label>
        <asp:TextBox ID="txtStudentNum" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStudentNum" ErrorMessage="Please enter a student number" ForeColor="#ff0000"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" autoComplete="off"></asp:TextBox><br />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a password" ForeColor="#ff0000"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br />
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="#ff0000"></asp:Label>
    </div>
</asp:Content>
