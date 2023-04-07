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
        <th scope="col">Contact</th>
        <th scope="col">Button</th>



      </tr>
    </thead>
    <tbody>

        <asp:Repeater ID="RepeaterAdmin" runat="server" >
            

            <ItemTemplate>
        <tr>
          <td data-label="Image"><img class="lazyload" loading="lazy" alt="picture" title="event" src="<%#Eval("ProfilePic") %>"></td>
           <td data-label="Model"><strong><%#Eval("Name") %></strong></td>
           <td data-label="Model"><%#Eval("Username") %></td>
            <td data-label="Model"><%#Eval("PhoneNo") %></td>
            <td data-label="Price" data-align="center">                
                <strong>

                    <asp:LinkButton ID="btnDecline"  CssClass="buttonDelete "  Text="Remove" runat="server" CommandArgument='<%#Eval("UserID") %>' OnClientClick="return confirm('Do you want to delete this Admin?');" OnClick="DeleteUser" />

                    <asp:HyperLink ID="btnEditProfile" CssClass="buttonAdd "  runat="server" NavigateUrl='<%# Eval("UserID","EditAdmin.aspx?UserID={0}") %>'>Edit Information</asp:HyperLink>

                    <br />
                    <br />
                    
                    <asp:HyperLink ID="btnEditPassword" CssClass="buttonAdd "  runat="server" NavigateUrl='<%# Eval("UserID","adminChangePassword.aspx?UserID={0}") %>'>Edit Password</asp:HyperLink>

                </strong>
            </td>

        </tr>

        </ItemTemplate>

        </asp:Repeater>
            

            
        
  </tbody>

 </table>

</asp:Content>
