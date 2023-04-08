<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/weiyao.css" rel="stylesheet" />

    <div><h1>Categories</h1></div>
    <div class="box">
        <table class="fence">
    <HeaderTemplate>
         
            <tr>
                <th>Category ID</th>
                <th>Category Title</th>
                <th>Description</th>
                <th>Status</th>
                <th>Date Modified</th>
                <th>Image</th>
                <th>Actions</th>
            </tr>
        
    </HeaderTemplate>
    <asp:Repeater ID="cateRepeater" runat="server">
        <ItemTemplate>  
                    <tr>
                        <td><%#Eval("ID") %></td>
                        <td><%#Eval("CategoryTitle") %></td>               
                        <td><%#Eval("Description") %></td>
                        <td><%#Eval("Status") %></td>
                        <td><%#Eval("Date Modified") %></td>
                        <td><img src="../Images/<%#Eval("Image") %>" width="270" height="160" /></td>
                        <td>         
                            <a href="./Edit.aspx?id=<%#Eval("ID") %>" class="btnEdit">Edit</a>
                            <a href="./Delete.aspx?id=<%#Eval("ID") %>" class="btnDelete">Delete</a>              
                        </td>
                    </tr>
        </ItemTemplate>         
    </asp:Repeater>
        </table>
        <br />
        <br />
    <asp:Button class ="cCate" ID="cCate" runat="server" Text="Create Category" PostBackUrl="~/AdminSide/Create.aspx"/>
    <asp:Button class="refresh" ID="refresh" runat="server" Text="Refresh" PostBackUrl="~/AdminSide/Categories.aspx" />
    </div>
</asp:Content>

