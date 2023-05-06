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

        <th scope="col">Button</th>


      </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="RepeaterEvent" runat="server" >
            

            <ItemTemplate>
                    <tr>
                        <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="<%#Eval("EventIMG") %>"></td>
                        <td data-label="Model"><strong><%#Eval("EventName") %></strong></td>
                        <td data-label="Model">RM<%#Eval("EventTarget") %></td>
                        
 
                        <td data-label="Price" data-align="center">

                           <strong>
                                <asp:HyperLink ID="btnEdit" CssClass="button "  runat="server" NavigateUrl='<%# Eval("EventID","editProgram.aspx?EventID={0}") %>'>Edit Event</asp:HyperLink>


                               <asp:LinkButton ID="lnkDelete"  CssClass="buttonDelete "  Text="Delete Event" runat="server" CommandArgument='<%#Eval("EventID") %>' OnClientClick="return confirm('Do you want to delete this Customer?');"
                    OnClick="DeleteCustomer" />
                                    
                                <br />
                                <br />
                                <asp:HyperLink ID="Button1"  CssClass="buttonAdd "  runat="server" NavigateUrl='<%# Eval("EventID","CommentManage.aspx?EventID={0}") %>'>Comment</asp:HyperLink>
                                <asp:HyperLink ID="Button3"  CssClass="buttonDonor "  runat="server" NavigateUrl='<%# Eval("EventID","ParticipantManage.aspx?EventID={0}") %>'>View Donor</asp:HyperLink>


   
                            </strong>
                        </td>

                    </tr>
                </ItemTemplate>

        </asp:Repeater>

        <td data-label="Model" colspan="4">
                <asp:Label ID="Label1" runat="server" Text="Label" style="text-align: center">
                    -----------------End Of The List--------------------
                </asp:Label>
            </td>
        
  </tbody>

 </table>

</asp:Content>
