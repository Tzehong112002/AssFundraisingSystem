<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="approveEvent.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.approveEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/approveEventStyle.css" rel="stylesheet" />
    <div class="title">

        <h1 style="margin:0px;">Approve Event</h1> 


    </div>
    <table class="product-table">
      <thead>
      <tr>
        <th scope="col">Event Name</th>
        <th scope="col">Start Date</th>
        <th scope="col">End Date</th>
        <th scope="col">Target</th>
        <th scope="col">Apply people</th>
        <th scope="col">Button</th>


      </tr>
    </thead>
    <tbody>
        <tr>
            <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="img/event.jpg"></td>
            <td data-label="Model"><strong>rescue animal</strong></td>
            <td data-label="Model">3/4/2023</td>
            <td data-label="Model">4/4/2023</td>
            <td data-label="Model">RM1000</td>
            <td data-label="Model">Tan Tze Hong</td>
            
            <td data-label="Price" data-align="center">
                
                <strong>

                    <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="buttonAdd " BackColor="Green"  />

                </strong>
            </td>

        </tr>
        
  </tbody>

 </table>

</asp:Content>
