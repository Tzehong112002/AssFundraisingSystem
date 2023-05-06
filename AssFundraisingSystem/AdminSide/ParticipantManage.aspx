<%@ Page Title="Manage Participant" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="ParticipantManage.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.ParticipantManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/EventLListStyle.css" rel="stylesheet"/>

        <div class="title">
        <h1 style="margin:0px;">Participant Manage</h1> 

    </div>
    <table class="product-table">
      <thead>
      <tr>
        
        <th scope="col">User Profile Pic</th> 
          <th scope="col">User ID</th>
        <th scope="col" colspan="2">Name</th> 
        <th scope="col" colspan="2">Donated Amount</th> 
        <th scope="col" colspan="2">Button</th>
      </tr>
    </thead>

    <tbody>

        <asp:Repeater ID="RepeaterEvent" runat="server" >
         <ItemTemplate>

        <tr>
            
            <td data-label="UserProPic" style="height: 32px"><img  alt="picture" src="<%#Eval("ProfilePic") %>"></td>

            <td data-label="UserID" style="height: 32px"><%#Eval("Username") %></td>
            <td data-label="Username" colspan="2" style="height: 32px"><%#Eval("Name") %></td>
            <td data-label="DonateAmount" colspan="2" style="height: 32px"><%#Eval("Amount") %></td>
            <td data-label="btnParticipantManage" style="height: 32px" colspan="2">
            <asp:Button ID="btnDelParticipant" runat="server" CssClass="buttonDelete " Text="Delete" BackColor="Red" width="80px" OnClick="btnDeleteParticipant_Click" CommandArgument='<%#Eval("PaymentID") %>' OnClientClick="return confirm('Do you want to delete this donor?');" />
       
            </td>
        </tr> 

        </ItemTemplate>
                

        </asp:Repeater>
  </tbody>
 </table>



</asp:Content>
