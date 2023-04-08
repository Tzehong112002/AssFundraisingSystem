<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AssFundraisingSystem.UserSide.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

 
    <link href="css/ProfieStyle.css" rel="stylesheet" />

        
   <div id="content">
            <br />
            <br />
            <div id="information">
                <h1>Profile</h1>
                <div id="img" class="inline">

                <asp:Image ID="imgOrganization" runat="server"  Height="225px" Width="400px" src="Img/profile.png" />
                    </div>
                <div id="info" class="inline">
                    <table>

                        <tr>
                            <td>Username:</td>
                            <td id="lblUsername">
                                <asp:Label ID="lblUsername" runat="server">TZEHONG112002</asp:Label></td>
                        </tr>
                        <tr>
                            <td>Name:</td>
                            <td>
                                <asp:Label ID="lblName" runat="server">TAN TZE HONG</asp:Label></td>
                        </tr>
                        <tr>
                            <td>Email:</td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server">tzehong112002@gmail.com</asp:Label></td>
                        </tr>
                        <tr>
                           <td>Contact:</td>
                            <td id="lblContact">
                                <asp:Label ID="lblContact" runat="server">0167822171</asp:Label></td>
                       
                        </tr>
                        <tr>
                           <td>Roles:</td>
                            <td>
                                <asp:Label ID="lblRoles" runat="server">11/01/2002</asp:Label></td>
                       
                        </tr>
                        

                                


                    </table>
                    <div class="btn">
                        <asp:Button ID="btnChangePass" runat="server" Text="Change Password" CssClass="button" BackColor="lightBlue" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" Height="50px" Width="150px" OnClick="btnChangePass_Click" />
                <asp:Button ID="btnEdit" runat="server" Text="Edit Profile" CssClass="button" BackColor="lightBlue" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" Height="50px" Width="150px" OnClick="btnEdit_Click" />

                    </div>
                    
  
                </div>
                   
                </div>

            <br />
            <br /> 
            <br />
            </div>
   

</asp:Content>
