<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserCategory.aspx.cs" Inherits="AssFundraisingSystem.UserSide.UserCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

    <link href="css/userWY.css" rel="stylesheet" />
    <div class="container">
      <h1>Choose your category</h1>
      <div class="button-container">

<asp:Repeater ID="cateRepeater" runat="server">
    <ItemTemplate>
        <a href="EventFilter.aspx?CategoryTitle=<%# Eval("CategoryTitle") %>">
            <div class="category-title"><%# Eval("CategoryTitle") %></div>
            <img src="../Images/<%# Eval("Image") %>" alt="<%# Eval("CategoryTitle") %>" />
        </a>
    </ItemTemplate>
</asp:Repeater>



      </div>
    </div>


   
</asp:Content>


  