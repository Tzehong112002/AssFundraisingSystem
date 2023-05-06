<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="historyPayment.aspx.cs" Inherits="AssFundraisingSystem.UserSide.historyPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="css/programStyle.css" rel="stylesheet" />

    <div class="title">



    </div>

    <table class="product-table">
      <thead>
      <tr>
        <th scope="col">User Name</th>
        <th scope="col">Event Name</th>
        <th scope="col">Email</th>
        <th scope="col">Amount</th>
        <th scope="col">Button</th>



      </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="RepeaterEvent" runat="server" >
            

            
                    <ItemTemplate>
        <tr>
            
            <td data-label="Account"><strong><%#Eval("Name") %></strong></td>
            <td data-label="Model"><%#Eval("EventName") %></td>
            <td data-label="Model"><%#Eval("Email") %></td>
            <td data-label="Donation Amount"><%#Eval("Amount") %></td>
            <td data-label="Price" data-align="center">
                
                <strong>
                    <asp:HyperLink ID="btnView" CssClass="button "   runat="server" NavigateUrl='<%# Eval("EventID","CommentPage.aspx?EventID={0}") %>'>Write a review</asp:HyperLink>
                </strong>
            </td>
        </tr>
                </ItemTemplate>
                

        </asp:Repeater>

        <td data-label="Model" colspan="5">
                <asp:Label ID="Label1" runat="server" Text="Label" style="text-align: center">
                    -----------------End Of The List--------------------
                </asp:Label>
            </td>
        
  </tbody>

 </table>


</asp:Content>
