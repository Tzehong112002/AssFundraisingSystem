<%@ Page Title="Manage Participant" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="ParticipantManage.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.ParticipantManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/EventLListStyle.css" rel="stylesheet"/>

        <div class="title">
        <h1 style="margin:0px;">Participant Manage</h1> 

    </div>
    <table class="product-table">
      <thead>
      <tr>
        <th scope="col">User ID</th>
          <th scope="col">User Profile Pic</th>
        <th scope="col" colspan="2">User</th>
        <th scope="col" colspan="2">Donated Amount</th>
        <th scope="col" colspan="2">Time Joined</th>
        <th scope="col" colspan="2">Button</th>
      </tr>
    </thead>

    <tbody>
        <tr>
            <td data-label="UserID" style="height: 32px">1</td>
            <td data-label="UserProPic" style="height: 32px"><img  alt="picture" src="../UserSide/Img/profile.png"></td>
            <td data-label="Username" colspan="2" style="height: 32px">Alex</td>
            <td data-label="DonateAmount" colspan="2" style="height: 32px">RM100.00</td>
            <td data-label="DonateTime" colspan="2" style="height: 32px">3/3/2023 3:14 P.M.</td>
            <td data-label="btnParticipantManage" style="height: 32px" colspan="2">
                    <asp:Button ID="btnEditParticipant" runat="server" Text="Edit" CssClass="button" BackColor="Green" width="80px" OnClick="btnEditParticipant_Click"/>
                    <asp:Button ID="btnDelParticipant" runat="server" CssClass="buttonDelete " Text="Delete" BackColor="Red" width="80px"/>
            </td>
        </tr> 
  </tbody>
 </table>



</asp:Content>
