<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Scope.master" CodeBehind="SearchCondition.aspx.cs" Inherits="Scope.View.Search.SearchCondition" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
        .style3
        {
            width: 186px;
        }
        .style4
        {
            width: 136px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent" >
    <div>
        <h1>書籍 - 検索条件</h1>
        <table class="inputTable">
          <tr>
            <td class="index">種別</td>
            <td colspan="3" class="style1">
              <asp:DropDownList ID="BookType" runat="server" AppendDataBoundItems="True" 
            AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="bookType" 
            DataValueField="bookType">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT DISTINCT [bookType] FROM [Book]"></asp:SqlDataSource>
            </td>
          </tr>
          <tr>
            <td class="index" style="width: 156px">タイトル（前方一致）</td>
            <td><asp:TextBox ID="title" runat="server"  MaxLength="50" Width="333px" AutoPostBack="true"></asp:TextBox></td>
            <td class="index">ISBN（前方一致）</td>
            <td class="style3"><asp:TextBox ID="isbn" runat="server" MaxLength="13" AutoPostBack="true" Width="202px"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="index" style="width: 156px">出版社（前方一致）</td>
            <td><asp:TextBox ID="publisher" runat="server" MaxLength="50" 
                    Width="335px" AutoPostBack="true"></asp:TextBox></td>
            <td class="index" style="width: 136px">金額</td>
            <td class="style3">
                <asp:TextBox ID="price" runat="server" MaxLength="6" 
                    TextMode="Number" AutoPostBack="true" Width="201px"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="index" style="width: 156px">評価（部分一致）</td>
            <td colspan="3">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT [evaluation], [ID] FROM [BookEval]"></asp:SqlDataSource>
                <br />
                <asp:TextBox ID="eval" runat="server" TextMode="MultiLine" Height="98px" 
                    style="margin-top: 0px" Width="579px" AutoPostBack="true"></asp:TextBox>
            </td>
          </tr>
        </table>
        
        <br />

        <h1>検索結果</h1>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            DataSourceID="SqlDataSource3" Width="755px" DataKeyNames="id">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" 
                    SortExpression="id" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="bookType" HeaderText="bookType" 
                    SortExpression="bookType" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="isbn" HeaderText="isbn" 
                    SortExpression="isbn" />
                <asp:BoundField DataField="publisher" HeaderText="publisher" 
                    SortExpression="publisher" />
                <asp:BoundField DataField="price" HeaderText="price" 
                    SortExpression="price" />
                <asp:BoundField DataField="buydate" HeaderText="buydate" 
                    SortExpression="buydate" />
                <asp:BoundField DataField="status" HeaderText="status" 
                    SortExpression="status" />
                <asp:BoundField DataField="bookEval_id" HeaderText="bookEval_id" 
                    SortExpression="bookEval_id" />
                <asp:BoundField DataField="eval" HeaderText="eval" SortExpression="eval" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>


        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            
            SelectCommand="SELECT * FROM [Book] 
WHERE 
  ([bookType] = ISNULL(@bookType, [bookType]))
  AND ([title] LIKE ISNULL(@title, [title]) + '%')
  AND ([isbn] LIKE ISNULL(@isbn, [isbn]) + '%')
  AND ([publisher] LIKE ISNULL(@publisher, [publisher]) + '%')
  AND ([eval] LIKE '%' + ISNULL(@eval, [eval]) + '%')
" 
            OldValuesParameterFormatString="original_{0}" 
            DeleteCommand="DELETE FROM [Book] WHERE [id] = @original_id" 
            InsertCommand="INSERT INTO [Book] ([bookType], [title], [isbn], [publisher], [price], [buydate], [status], [bookEval_id], [eval]) VALUES (@bookType, @title, @isbn, @publisher, @price, @buydate, @status, @bookEval_id, @eval)" 
            
            UpdateCommand="UPDATE [Book] SET [bookType] = @bookType, [title] = @title, [isbn] = @isbn, [publisher] = @publisher, [price] = @price, [buydate] = @buydate, [status] = @status, [bookEval_id] = @bookEval_id, [eval] = @eval WHERE [id] = @original_id">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int64" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="bookType" Type="Int32" />
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="isbn" Type="String" />
                <asp:Parameter Name="publisher" Type="String" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter Name="buydate" DbType="Date" />
                <asp:Parameter Name="status" Type="Int32" />
                <asp:Parameter Name="bookEval_id" Type="Int64" />
                <asp:Parameter Name="eval" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="BookType" Name="bookType" 
                    PropertyName="SelectedValue" Type="Int64" />
                <asp:ControlParameter ControlID="title" ConvertEmptyStringToNull="False" 
                    Name="title" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="isbn" ConvertEmptyStringToNull="False" 
                    Name="isbn" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="publisher" ConvertEmptyStringToNull="False" 
                    Name="publisher" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="eval" ConvertEmptyStringToNull="False" 
                    Name="eval" PropertyName="Text" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="bookType" Type="Int32" />
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="isbn" Type="String" />
                <asp:Parameter Name="publisher" Type="String" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter DbType="Date" Name="buydate" />
                <asp:Parameter Name="status" Type="Int32" />
                <asp:Parameter Name="bookEval_id" Type="Int64" />
                <asp:Parameter Name="eval" Type="String" />
                <asp:Parameter Name="original_id" Type="Int64" />
            </UpdateParameters>
        </asp:SqlDataSource>


    </div>
</asp:Content>