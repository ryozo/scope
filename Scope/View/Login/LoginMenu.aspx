<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginMenu.aspx.cs" Inherits="Scope.View.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ログイン画面</title>
</head>
<body>
    <!-- #include file="../Common/Header.aspx" -->
    <form id="LoginForm" runat="server">
    <div>
        <table>
          <tr>
            <td>ユーザID</td>
            <td>
              <asp:TextBox ID="userId" runat="server"></asp:TextBox>
              &nbsp;
              <asp:RequiredFieldValidator ID="userIdRequiredValidator" runat="server" ErrorMessage="ユーザIDは必須入力です。" ForeColor="red" ControlToValidate="userId"></asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
            <td>パスワード</td>
            <td>
              <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
              &nbsp;
              <asp:RequiredFieldValidator ID="passwordRequiredValidator" runat="server" ErrorMessage="パスワードは必須入力です。" ForeColor="red" ControlToValidate="password"></asp:RequiredFieldValidator>
            </td>
          </tr>
        </table>
        <br />
        <asp:Button ID="Login" runat="server" Text="Login" onclick="Login_Click" />
    </div>
    </form>
</body>
</html>
