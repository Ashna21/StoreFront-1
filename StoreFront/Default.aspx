<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StoreFront._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row top-buffer">
        <div class="col-md-12 layout-placeholder">
            <h2 style="text-align:center">Welcome to the StoreFront!</h2>
        </div>
    </div>

    <div class="row top-buffer">
        <div class="col-md-12 layout-placeholder">
            <h2 style="text-align:center">Hold onto your butts.</h2>
        </div>
    </div>

    <div class="row top-buffer">
        <div class="col-md-6 layout-placeholder">
            <a href="Admin/CustomerAdmin.aspx" >Customer Admin</a>
            <br />
            <a href="search" >Search Products</a>
        </div>
        <div class="col-md-6 layout-placeholder">
            <p> </p>
        </div>
    </div>

</asp:Content>
