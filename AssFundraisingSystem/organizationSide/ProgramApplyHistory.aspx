<%@ Page Title="" Language="C#" MasterPageFile="~/organizationSide/organizationMaster.Master" AutoEventWireup="true" CodeBehind="ProgramApplyHistory.aspx.cs" Inherits="AssFundraisingSystem.organizationSide.ProgramApplyHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <link href="css/ProgramApplyHistoryStyle.css" rel="stylesheet" />
        <div class="title">

        <h1 style="margin:0px;">Program Application History</h1> 



    </div>
    <table class="product-table">
      <thead>
      <tr>
        <th scope="col">Event Name</th>
        <th scope="col">Categories</th>
        <th scope="col">Start Dtae</th>
        <th scope="col">End Date</th>
        <th scope="col">Target</th>
        <th scope="col">Status</th>


      </tr>
    </thead>
    <tbody>
        <tr>
           <td data-label="Model"><strong>Resue Animal</strong></td>
           <td data-label="Model">Animal</td>
           <td data-label="Model">3/4/2023</td>
           <td data-label="Model">4/4/2023</td>
            <td data-label="Model">016-7822171</td>
            <td data-label="Model">Approve</td>


        </tr>
        
  </tbody>

 </table>


</asp:Content>
