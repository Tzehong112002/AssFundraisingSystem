<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="adminAccount.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.adminAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="title">
        <link href="css/adminListStyle.css" rel="stylesheet" />
        <h1 style="margin:0px;">Admin List</h1> 

         <div style="text-align: right;margin:0px;">
            <asp:Button ID="btnAdd" runat="server" Text="Add Admin"   CssClass="buttonAdd " BackColor="Green" OnClick="btnAdd_Click" />
        </div

    </div>
    <table class="product-table">
      <thead>
      <tr>
        <th scope="col">Photo</th>
        <th scope="col">Name</th>
        <th scope="col">Username</th>
        <th scope="col">date</th>
        <th scope="col">Contact</th>
        <th scope="col">BUtton</th>



      </tr>
    </thead>
    <tbody>
        <tr>
          <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="img/event.jpg"></td>
           <td data-label="Model"><strong>Tan Tze Hong</strong></td>
           <td data-label="Model">Tzehong112002</td>
            <td data-label="Model">3/4/2023</td>
            <td data-label="Model">0167822171</td>
            <td data-label="Price" data-align="center">                
                <strong>

                    <asp:Button ID="btnDecline" runat="server" Text="Remove" CssClass="buttonDelete "  BackColor="Red"/>
                </strong>
            </td>

        </tr>
        
  </tbody>

 </table>

</asp:Content>
