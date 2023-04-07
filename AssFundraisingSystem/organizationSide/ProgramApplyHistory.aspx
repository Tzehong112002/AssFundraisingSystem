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
        <asp:Repeater ID="RepeaterHistory" runat="server" >
            

            <ItemTemplate>
        <tr>
           <td data-label="Model"><strong><%#Eval("Name") %></strong></td>
           <td data-label="Model"><%#Eval("Categories") %></td>
           <td data-label="Model"><%#Eval("EventStartDate") %></td>
           <td data-label="Model"><%#Eval("EventEndDate") %></td>
            <td data-label="Model"><%#Eval("EventTarget") %></td>
            <td data-label="Model"><%#Eval("EventStatus") %></td>


        </tr>
        
            

            </ItemTemplate>
        </asp:Repeater >
        
  </tbody>

 </table>


</asp:Content>
