<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="EditAdmin.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.EditAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/editAdminStyle.css" rel="stylesheet" />
     <div class="container">

            <h1 class="title">Edit Admin</h1>
            <div class="message messageerror"></div>

        <div class="input">
            <span id="lblPicture">Profile Picture:</span>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Label ID="Passvalue" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<div class="inputerrormessage"></div>
        </div>

        <div class="input">
            <asp:Label ID="Label4" runat="server" Text="Admin Name :"></asp:Label>
            <asp:TextBox ID="TextBox1" class="txtinput" placeholder="Enter Admin Name" runat="server" ></asp:TextBox>
            <div class="inputerrormessage"></div>
            <asp:RequiredFieldValidator ID="nameValidator" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter your name" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <div class="input">
            <asp:Label ID="Label1" runat="server" Text="Contact Number :"></asp:Label>
            <asp:TextBox ID="TextBox5" class="txtinput" placeholder="Enter Contact Number" runat="server" ></asp:TextBox>
            <div class="inputerrormessage"></div>
            <asp:RequiredFieldValidator ID="contactNumberValidator" runat="server" ControlToValidate="TextBox5" ErrorMessage="Please enter your contact number" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5"
                ErrorMessage="Contact number must be 10-11 digits" ValidationExpression="^\d{10,11}$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>


        

             <asp:Button ID="btnUpdateAdmin"  runat="server" Text="Update" class="button" BackColor="Green" OnClick="btnUpdateAdmin_Click" />

             <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="button" BackColor="Red" CausesValidation="false" OnClick="btnCancel_Click" />


   </div>

</asp:Content>
