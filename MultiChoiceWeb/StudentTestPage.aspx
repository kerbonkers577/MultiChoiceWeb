<%@ Page Title="" Language="C#" MasterPageFile="~/MultiChoiceMaster.Master" AutoEventWireup="true" CodeBehind="StudentTestPage.aspx.cs" Inherits="MultiChoiceWeb.StudentTestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTestName" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblStudentName" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblStudentNum" runat="server" Text=""></asp:Label><br />
    <br />
    <br />
    <asp:Label ID="lblQuestionTitle" runat="server" Text=""></asp:Label>
    <asp:RadioButtonList ID="rlStudentSelection" runat="server">
        <asp:ListItem>Answer 1</asp:ListItem>
        <asp:ListItem>Answer 2</asp:ListItem>
        <asp:ListItem>Answer 3</asp:ListItem>
        <asp:ListItem>Answer 4</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Label ID="lblRadioError" runat="server" Text="" ForeColor="#ff0000"></asp:Label>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

</asp:Content>
