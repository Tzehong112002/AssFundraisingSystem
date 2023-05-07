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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="fuProfilePic" ErrorMessage="Please upload the profile picture"></asp:RequiredFieldValidator>
                    <asp:Literal ID="litFUErrorMessage" runat="server"></asp:Literal>
                    <br />
                    

                </td>
            </tr>
            <tr>
                <td class="editProfileLbl" style="padding-left: 50px;">Name</td>
                 <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input" placeholder="Name"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="nameValidator" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter your name" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                        ErrorMessage="Invalid email format" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                </td>

            </tr>
           
                <tr>
                    <td class="editProfileLbl" style="padding-left: 50px;">Contact Number</td>
                    <td>
                        <asp:TextBox ID="txtContactNumber" runat="server" CssClass="input" placeholder="Phone No"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtContactNumber" ErrorMessage="Please enter a valid phone number" 
                            ValidationExpression="^\d{10,11}$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtContactNumber" ErrorMessage="Please enter your contact number" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
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
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button " BackColor="Red" OnClick="btnCancel_Click" CausesValidation="False" />

                    
                    </div>
                    
                </td>
            </tr>
            
            

        </table>


</asp:Content>
