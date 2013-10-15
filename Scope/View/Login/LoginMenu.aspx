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
        <asp:ValidationSummary runat="server" id="messages" />
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

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="UserID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" 
                SortExpression="UserID" />
            <asp:BoundField DataField="Password" HeaderText="Password" 
                SortExpression="Password" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>
    </form>
</body>
</html>
