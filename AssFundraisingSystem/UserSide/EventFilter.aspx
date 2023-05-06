<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EventFilter.aspx.cs" Inherits="AssFundraisingSystem.UserSide.EventFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

        <link href="css/programStyle.css" rel="stylesheet" />

<table class="product-table">
      <thead>
      <tr>
        <th scope="col">Image</th>
        <th scope="col">Name</th>
        <th scope="col">Target</th>
        <th scope="col">End Date</th>
        <th scope="col">Button</th>


      </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="RepeaterEventList" runat="server" >
            <ItemTemplate>
        <tr>
            <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="<%#Eval("EventIMG") %>"></td>
            <td data-label="Model"><strong><%#Eval("EventName") %></strong></td>
            <td data-label="Model">RM <%#Eval("EventTarget") %></td>
            <td data-label="Model"><%#Eval("EventEndDate") %></td>
            
            <td data-label="Price" data-align="center">
                
                <strong>
                    <asp:HyperLink ID="btnView" CssClass="button "   runat="server" NavigateUrl='<%# Eval("EventID","EventPage.aspx?EventID={0}") %>'>View</asp:HyperLink>
                </strong>
            </td>
        </tr>
                </ItemTemplate>
        </asp:Repeater>

        <td data-label="Model" colspan="5">
                <asp:Label ID="Label1" runat="server" Text="Label" style="text-align: center">
                    -----------------End Of The List--------------------
                </asp:Label>
            </td>
       
  </tbody>

 </table>

</asp:Content>
