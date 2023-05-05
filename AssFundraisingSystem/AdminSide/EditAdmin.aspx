<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="EditAdmin.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.EditAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/editAdminStyle.css" rel="stylesheet" />
     <div class="container">

            <h1 class="title">Edit Admin</h1>
            <div class="message messageerror"></div>

         <div class="input">
                <span id="lblPicture">Profile Picture:</span>
                <asp:FileUpload ID="FileUpload1" runat="server" />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please upload the profile picture"></asp:RequiredFieldValidator>
                <asp:Label ID="Passvalue" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<div class="inputerrormessage"></div>
            </div>

            <div class="input">
               <asp:Label ID="Label4" runat="server" Text="Admin Name :"></asp:Label>
                <asp:TextBox ID="TextBox1" class="txtinput" placeholder="Enter Admin Name" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter an admin name"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>

         

         <div class="input">
               <asp:Label ID="Label1" runat="server" Text="Contact Number :"></asp:Label>
                <asp:TextBox ID="TextBox5" class="txtinput" placeholder="Enter Contact Number" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox5" ErrorMessage="Please enter the contact number"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
           </div>

        

             <asp:Button ID="btnUpdateAdmin"  runat="server" Text="Update" class="button" BackColor="Green" OnClick="btnUpdateAdmin_Click" />

             <asp:Button ID="btnCancel"  runat="server" Text="cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" CausesValidation="false"/>

   </div>

</asp:Content>
