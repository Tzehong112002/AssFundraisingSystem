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
        <asp:Repeater ID="RepeaterProgramApply" runat="server" >
            

            <ItemTemplate>
        <tr>
            <td data-label="Model"><strong><%#Eval("EventName") %></strong></td>
            <td data-label="Model"><%#Eval("EventStartDate") %></td>
            <td data-label="Model"><%#Eval("EventEndDate") %></td>
            <td data-label="Model">RM<%#Eval("EventTarget") %></td>
            <td data-label="Model"><%#Eval("Name") %></td>
            
            <td data-label="Price" data-align="center">
                
                <strong>

                    <asp:LinkButton ID="btnApprove"  CssClass="buttonAdd "  Text="Approve" runat="server" CommandArgument='<%#Eval("EventID") %>' OnClientClick="return confirm('Do you want to Update this event ?');" OnClick="UpdateEvent" />


                </strong>
            </td>

        </tr>

        </ItemTemplate>
        </asp:Repeater  >

        <td data-label="Model" colspan="6">
                <asp:Label ID="Label1" runat="server" Text="Label" style="text-align: center">
                    -----------------End Of The List--------------------
                </asp:Label>
            </td>
            

            
        
  </tbody>

 </table>

</asp:Content>
