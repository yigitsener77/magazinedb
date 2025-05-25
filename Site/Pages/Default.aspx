<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site.Pages.Default" %>

<asp:Content ID="Content0" ContentPlaceHolderID="titleContent" runat="server">Makale Listesi</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="row">
        <!--Kategori Menüsü -->
        <div class="col-md-3">
            <h5>Kategoriler</h5>
            <div class="list-group">
                <asp:Repeater ID="rptCategories" runat="server">
                    <ItemTemplate>
                        <a href="#" class="list-group-item list-group-item-action border-0"><%#Eval("Name") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <!--Makale Listesi -->
        <div class="col-md-9">
            <h4>Makaleler:</h4>
            <div class="row row-cols-1 row-cols-md-3 g-3">
                <asp:Repeater ID="rptArticles" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card h-100">
                                <img src="<%# Eval("CoverImagePath") %>" class="card-img-top" alt="<%# Eval("Title") %>">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Title") %></h5>
                                    <p class="card-text"><%# Eval("ShortContent") %></p>
                                    <a class="btn btn-outline-dark btn-sm" href="/Pages/Detail.aspx?id=<%# Eval("Id") %>">Daha fazla...</a>
                                </div>
                                <div class="card-footer">
                                    <small class="text-body-secondary"><%# Eval("PublishDate") %></small>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
