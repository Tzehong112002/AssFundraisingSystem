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
        <th scope="col">Email</th>
        <th scope="col">IC Image [Front]</th>
        <th scope="col">IC Image [Back ]</th>
        <th scope="col">Company Name</th>
        <th scope="col">Button</th>


      </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="RepeaterProgramApply" runat="server" >
            

            <ItemTemplate>
        <tr>
           <td data-label="Model"><strong><%#Eval("Name") %></strong></td>
           <td data-label="Model"><%#Eval("Email") %></td>
            <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="<%#Eval("submitICFront") %>"></td>


            <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="<%#Eval("submitICBack") %>"></td>
            <td data-label="Model"><%#Eval("submitCompanyName") %></td>
            <td data-label="Price" data-align="center">                
                <strong>

                     <asp:LinkButton ID="btnAppove"  CssClass="buttonAdd "  Text="Approve" runat="server" CommandArgument='<%#Eval("UserID") %>' OnClientClick="return confirm('Do you want to Approve this Account ?');" OnClick="UpdateRequest" />
                     <asp:LinkButton ID="btnDecline"  CssClass="buttonDelete "  Text="Decline" runat="server" CommandArgument='<%#Eval("UserID") %>' OnClientClick="return confirm('Do you want to Decline this Account  ?');" OnClick="DeleleRequest" />

                </strong>
            </td>

        </tr>
            </ItemTemplate>
        </asp:Repeater >
            

            
        
  </tbody>

 </table>


</asp:Content>
