<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="ProgramList.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.ProgramList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/EventLListStyle.css" rel="stylesheet" />

        <div class="title">

        <h1 style="margin:0px;">Program List</h1> 

        <div style="text-align: right;margin:0px;">
            <asp:Button ID="btnAdd" runat="server" Text="Add Event"   CssClass="buttonAdd " BackColor="Green" OnClick="btnAdd_Click" />
        </div>

    </div>
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
                </div>
            </td>
            <td data-label="Price" data-align="center">
                
                <strong>

                    <asp:Button ID="btnEdit" runat="server" Text="Edit Event" CssClass="button " BackColor="Green" OnClick="btnEdit_Click"  />
                    <asp:Button ID="Button2" runat="server" CssClass="buttonDelete " Text="Delete Event" BackColor="Red" OnClick="Button2_Click"/>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Comment" CssClass="buttonAdd " BackColor="Green" OnClick="Button1_Click"  />
                    <asp:Button ID="Button3" runat="server" Text="View Donor" CssClass="buttonDonor "  BackColor="Red" OnClick="Button3_Click"/>
                </strong>
            </td>

        </tr>
        
  </tbody>

 </table>

</asp:Content>
