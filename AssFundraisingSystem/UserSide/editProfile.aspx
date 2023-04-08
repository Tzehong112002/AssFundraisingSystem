<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="editProfile.aspx.cs" Inherits="AssFundraisingSystem.UserSide.editProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="css/editProfileStyle.css" rel="stylesheet" />
    <div class="h1">  
    <h1>Edit Profile</h1>
    </div> 
        <table id="editProfileTable">
            <tr>
                <td class="editProfileLbl" style="padding-left: 50px;">Profile Picture</td>
                <td>
                    <asp:FileUpload ID="fuProfilePic" runat="server"  text=""/>
                    
                    <asp:Literal ID="litFUErrorMessage" runat="server"></asp:Literal>
                    <br />
                    

                </td>
            </tr>
            <tr>
                <td class="editProfileLbl" style="padding-left: 50px;">Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input" placeholder="Name"></asp:TextBox>
                    <br />

                </td>
            </tr>
            <tr>
                <td class="auto-style1" id="gender" style="padding-left: 50px;">Gender</td>
                <td class="auto-style1">
                    
                    <asp:RadioButtonList ID="rblGender" runat="server" CssClass="list" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="M">👦  Male</asp:ListItem>
                        <asp:ListItem Value="F">👧  Female</asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblGender" Display="Dynamic" ErrorMessage="Please select your [Gender]" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td class="editProfileLbl" style="padding-left: 50px;">Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input"  placeholder="Email"></asp:TextBox>
                    <br />

                </td>
            </tr>
            <tr>
                <td class="editProfileLbl" style="padding-left: 50px;">Contact Number</td>
                <td>
                    <asp:TextBox ID="txtContactNumber" runat="server" CssClass="input"  placeholder="Phone No"></asp:TextBox>
                    <br />

                </td>
            </tr>
            
            <tr>
                <td class="editProfileLbl" style="padding-left: 50px;">Date of birth</td>
                <td>
                    <asp:Calendar ID="calendarBirth" runat="server" SelectMonthText="&amp;gt;"></asp:Calendar>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td>
                    <div class="flex-parent jc-center">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update"  CssClass="button " BackColor="Green" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button " BackColor="Red" OnClick="btnCancel_Click" />
                    
                    </div>
                    
                </td>
            </tr>
            
            

        </table>


</asp:Content>
