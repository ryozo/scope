<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Scope.master" CodeBehind="InRegist.aspx.cs" Inherits="Scope.View.InRegist.InRegist" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <!-- #include file="../Common/Header.aspx" -->
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent" >
    <div>
        <asp:ValidationSummary runat="server" ForeColor="Red" />
        <asp:RequiredFieldValidator ID="TitleRequiredFieldValidator" runat="server" Display="None" ErrorMessage="タイトルは必須入力です。" ForeColor="red" ControlToValidate="title"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="isbnRequiredFieldValidator" runat="server" Display="None" ErrorMessage="ISBNは必須入力です。" ForeColor="red" ControlToValidate="isbn"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="priceRegularValidator" runat="server" Display="None" ErrorMessage="金額は数値で入力してください。" ValidationExpression="^[0-9]*$" ForeColor="Red" ControlToValidate="price"></asp:RegularExpressionValidator>
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
            <td><asp:TextBox ID="price" runat="server" MaxLength="6" TextMode="Number"></asp:TextBox></td>
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
                <asp:DropDownList ID="BookEval" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="evaluation" 
                    DataValueField="id" AppendDataBoundItems="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT [evaluation], [ID] FROM [BookEval]"></asp:SqlDataSource>
                <br />
                <asp:TextBox ID="eval" runat="server" TextMode="MultiLine" Height="98px" 
                    style="margin-top: 0px" Width="579px"></asp:TextBox>
            </td>
          </tr>
        </table>
        <!--
        <h1>書籍 - この本へのコメント</h1>
        <table class="inputTable">
          <tr>
            <td class="index">No.</td>
            <td class="index">種別</td>
            <td class="index">コメント</td>
          </tr>
          <tr>
            <td></td>
            <td>
                <asp:DropDownList ID="commentType" runat="server" DataSourceID="SqlDataSource2" 
                    DataTextField="type" DataValueField="type">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT [type] FROM [CommentType]"></asp:SqlDataSource>
            </td>
            <td></td>
          </tr>
        </table>
        -->

        <div class="buttonArea">
          <asp:Button ID="Regist" runat="server" Text="登録" onclick="Regist_Click" />
        </div>
    </div>
</asp:Content>