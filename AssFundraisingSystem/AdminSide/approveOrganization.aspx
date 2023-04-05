<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="approveOrganization.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.approveOrganization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/apporveOrganizationStyle.css" rel="stylesheet" />

        <div class="title">

        <h1 style="margin:0px;">Application List</h1> 



    </div>
    <table class="product-table">
      <thead>
      <tr>
        <th scope="col">Name</th>
        <th scope="col">Comany Name</th>
        <th scope="col">IC Image [Front]</th>
        <th scope="col">IC Image [Back ]</th>
        <th scope="col">Contact Number</th>
        <th scope="col">Button</th>


      </tr>
    </thead>
    <tbody>
        <tr>
           <td data-label="Model"><strong>Tan Tze Hong</strong></td>
           <td data-label="Model">TZEHONG COMPANY SDN</td>
            <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="img/event.jpg"></td>


            <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="img/event.jpg"></td>
            <td data-label="Model">016-7822171</td>
            <td data-label="Price" data-align="center">                
                <strong>

                    <asp:Button ID="btnAppove" runat="server" Text="Appove" CssClass="buttonAdd " BackColor="Green"  />
                    <asp:Button ID="btnDecline" runat="server" Text="Decline" CssClass="buttonDelete "  BackColor="Red"/>
                </strong>
            </td>

        </tr>
        
  </tbody>

 </table>


</asp:Content>
