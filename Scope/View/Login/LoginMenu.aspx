<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Scope.master" CodeBehind="LoginMenu.aspx.cs" Inherits="Scope.View.WebForm1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <!-- #include file="../Common/Header.aspx" -->
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent" >
    <div>
        <span class="failureNotification">
            <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
        </span>
        <table>
          <tr>
            <td>USER ID</td>
            <td>
              <asp:TextBox ID="userId" runat="server"></asp:TextBox>
              &nbsp;
              <asp:RequiredFieldValidator ID="userIdRequiredValidator" runat="server" ErrorMessage="ユーザIDは必須入力です。" ForeColor="red" ControlToValidate="userId"></asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
            <td>PASSWORD</td>
            <td>
              <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
              &nbsp;
              <asp:RequiredFieldValidator ID="passwordRequiredValidator" runat="server" ErrorMessage="パスワードは必須入力です。" ForeColor="red" ControlToValidate="password"></asp:RequiredFieldValidator>
            </td>
          </tr> 
        </table>
        <br />
        <asp:Button ID="Login" runat="server" Text="Login" onclick="Login_Click" 
            Height="21px" />
    </div>
</asp:Content>