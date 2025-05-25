<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Site.Pages.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
     <h1>
         <asp:Literal ID="title" runat="server" />

     </h1>
    <p>
        <asp:Literal ID="content" runat="server" />
    </p>
    <p>
        <asp:Literal ID="tags" runat="server" />
    </p>
</asp:Content>
