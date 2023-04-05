<%@ Page Title="Program" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="program.aspx.cs" Inherits="AssFundraisingSystem.UserSide.program" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="css/programStyle.css" rel="stylesheet" />

<table class="product-table">
      <thead>
      <tr>
        <th scope="col">Image</th>
        <th scope="col">Name</th>
        <th scope="col">Target</th>
        <th scope="col">Progress</th>
        <th scope="col">Button</th>


      </tr>
    </thead>
    <tbody>
        <tr>
            <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="img/event.jpg"></td>
            <td data-label="Model"><strong>Help me improve my quality of life through a hip replacement</strong></td>
            <td data-label="Model">RM1000</td>
            <td>
                <div class="container" >               
                    <div class="progress progress-striped">
                      <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                        <span>40% Complete </span>
                    </div>
                </div>
            </td>
            <td data-label="Price" data-align="center">
                
                <strong>

                    <asp:Button ID="btnView" runat="server" Text="View" CssClass="button " BackColor="Green" OnClick="btnView_Click" />
                </strong>
            </td>
        </tr>
        <tr>
            <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="img/event.jpg"></td>
            <td data-label="Model"><strong>Help me improve my quality of life through a hip replacement</strong></td>
            <td data-label="Model">RM1000</td>
            <td>
                <div class="container" >               
                    <div class="progress progress-striped">
                      <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                        <span>40% Complete </span>
                    </div>
                </div>
            </td>
            <td data-label="Price" data-align="center">
                
                <strong>

                    <asp:Button ID="Button1" runat="server" Text="View" CssClass="button " BackColor="Green" />
                </strong>
            </td>
        </tr>
  </tbody>

 </table>




</asp:Content>
