<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Scope.master" CodeBehind="Menu.aspx.cs" Inherits="Scope.View.Menu" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent" >
    <div>
        <fieldset>
            <legend>簡易メニュー</legend>
            <asp:HyperLink ID="InRegistLink" runat="server" Font-Size="Large" Font-Underline="true" EnableViewState="false">新規登録</asp:HyperLink><br />
            <asp:HyperLink ID="SearchLink" runat="server" Font-Size="Large" Font-Underline="true">検索・更新・削除</asp:HyperLink>
        </fieldset>
    </div>
</asp:Content>