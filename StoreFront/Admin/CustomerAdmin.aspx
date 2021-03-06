﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerAdmin.aspx.cs" Inherits="StoreFront.Admin.CustomerAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h2>Customer Administration</h2>
    </div>

    <div class="row top-buffer">

        <asp:SqlDataSource ID="customerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"  
            InsertCommand="spAddUser @UserName, @EmailAddress, @IsAdmin"
            SelectCommand="spGetUsers" 
            UpdateCommand="spUpdateUser @UserID, @UserName, @EmailAddress, @IsAdmin, 'SysAdmin'"
            DeleteCommand="spDeleteUser @UserID"/>
    
        <%--<asp:ObjectDataSource ID="customerDataSource" runat="server" TypeName="StoreFrontDal.StoreFrontRepository"
            DataObjectTypeName="StoreFrontDal.User" 
            SelectMethod="GetUsers"
            UpdateMethod="UpdateUser"
            InsertMethod="InsertUser" />--%>
        

        <asp:GridView ID="customerGridView" DataSourceID="customerDataSource" runat="server"
            AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" CellPadding="5" AutoGenerateEditButton="true"
             DataKeyNames="UserID" AutoGenerateDeleteButton="true">
            <Columns>
                <asp:BoundField ReadOnly="true" HeaderText="UserID" SortExpression="UserID" DataField="UserID" />
                <asp:BoundField ReadOnly="false" HeaderText="UserName" SortExpression="UserName" DataField="UserName" />
                <asp:BoundField ReadOnly="false" HeaderText="EmailAddress" SortExpression="EmailAddress" DataField="EmailAddress" />
                <asp:CheckBoxField ReadOnly="false" HeaderText="Admin?" SortExpression="IsAdmin" DataField="IsAdmin" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="row top-buffer">
        <asp:DetailsView AutoGenerateRows="false" DataKeyNames="UserID" DataSourceID="customerDataSource"
            HeaderText="Customer Details" ID="CustomerDetailView" runat="server" DefaultMode="Insert" AutoGenerateInsertButton="true">
            <Fields>
                <asp:BoundField ReadOnly="false" HeaderText="UserName" SortExpression="UserName" DataField="UserName" />
                <asp:BoundField ReadOnly="false" HeaderText="EmailAddress" SortExpression="EmailAddress" DataField="EmailAddress" />
                <asp:CheckBoxField ReadOnly="false" HeaderText="Admin?" SortExpression="IsAdmin" DataField="IsAdmin"/>
            </Fields>
        </asp:DetailsView>
    </div>

    <div class="row top-buffer">
        <a href="../">Dash away home</a>
    </div>
</asp:Content>
