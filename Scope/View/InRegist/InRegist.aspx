<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Scope.master" CodeBehind="InRegist.aspx.cs" Inherits="Scope.View.InRegist.InRegist" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <!-- #include file="../Common/Header.aspx" -->
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
        .style2
        {
            width: 97px;
        }
        .style3
        {
            width: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent" >
    <div>
        <asp:ValidationSummary runat="server" id="messages" />
        <h1>書籍 - 基本情報</h1>
        <table class="inputTable">
          <tr>
            <td class="index">種別</td>
            <td colspan="4" class="style1">
              <asp:RadioButton ID="BookTypeBiz" GroupName="BookType" runat="server" Checked="true" Text="ビジネス書"/>
              <asp:RadioButton ID="BookTypeMagazine" GroupName="BookType" runat="server" Checked="false" Text="雑誌"/>
              <asp:RadioButton ID="BookTypeComic" GroupName="BookType" runat="server" Checked="false" Text="漫画"/>
              <asp:RadioButton ID="BookTypeLib" GroupName="BookType" runat="server" Checked="false" Text="文庫本"/>
            </td>
          </tr>
          <tr>
            <td class="index" style="width: 97px">タイトル</td>
            <td><asp:TextBox ID="title" runat="server" MaxLength="50" Width="333px" class="required"></asp:TextBox></td>
            <td class="index">ISBN</td>
            <td><asp:TextBox ID="isbn" runat="server" MaxLength="13" class="required"></asp:TextBox></td>
            <td class="index">購入日</td>
          </tr>
          <tr>
            <td class="index" style="width: 97px">出版社</td>
            <td><asp:TextBox ID="publisher" runat="server" MaxLength="50" 
                    Width="335px"></asp:TextBox></td>
            <td class="index" style="width: 85px">金額</td>
            <td><asp:TextBox ID="price" runat="server" MaxLength="6"></asp:TextBox></td>
            <td rowspan="3">
                <asp:Calendar ID="buyDate" runat="server"></asp:Calendar>
              </td>
          </tr>
          <tr>
            <td class="index" style="width: 97px">ステータス</td>
            <td colspan="3">
              <asp:RadioButton ID="StatusUnread" GroupName="status" runat="server" Checked="true" Text="未読了"/>
              <asp:RadioButton ID="StatusRead" GroupName="status" runat="server" Checked="false" Text="読了"/>
              <asp:RadioButton ID="StatusNoBuy" GroupName="status" runat="server" Checked="false" Text="未購入"/>
            </td>
          </tr>
          <tr>
            <td class="index" style="width: 97px">評価</td>
            <td colspan="3">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="evaluation" 
                    DataValueField="evaluation">
                    <asp:ListItem Selected="True">選択してください</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT [evaluation] FROM [BookEval]"></asp:SqlDataSource>
                <br />
                <textarea id="EvalTextArea" cols="50" name="S1" rows="5"></textarea><br />
            </td>
          </tr>
        </table>
        <h1>明細情報</h1>
        <table>
          <tr>
            <td>基本情報</td>
            <td>
            </td>
          </tr>
        </table>
        <br />
    </div>
</asp:Content>