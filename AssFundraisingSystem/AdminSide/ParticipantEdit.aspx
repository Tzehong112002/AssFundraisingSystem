<%@ Page Title="Edit Participant" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="ParticipantEdit.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.ParticipantEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/editProgramStyle.css" rel="stylesheet" />
             <div class="container">

            <h1 class="title">Edit Participant</h1>
            <div class="message messageerror"></div>

                 <div class="input">
                <span id="lblPicture">Profile Picture:</span>
                     <asp:FileUpload ID="uplPicture" runat="server" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uplPicture" ErrorMessage="Please enter an admin name"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
               <asp:Label ID="Label1" runat="server" Text="User :"></asp:Label>
                <asp:TextBox ID="TextBox1" class="txtinput" placeholder="User" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter an admin name"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
               <asp:Label ID="Label2" runat="server" Text="Donated Amout :"></asp:Label>
                <asp:TextBox ID="TextBox2" class="txtinput" placeholder="RM0.00" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please enter an admin name"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>

         <div class="input">
             <asp:Label ID="Label3" runat="server" Text="Time Joined :"></asp:Label>
             <asp:Calendar ID="Calendar1" runat="server" DateFormat="MM/dd/yyyy hh:mm:ss"></asp:Calendar>
            
         </div>

             <asp:Button ID="btnUpdate"  runat="server" Text="Update" class="button" BackColor="Green" OnClick="btnUpdate_Click" />
             <asp:Button ID="btnCancel"  runat="server" Text="Cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" CausesValidation="false"/>

   </div>



</asp:Content>
