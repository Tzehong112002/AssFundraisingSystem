<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="EditAdmin.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.EditAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/editAdminStyle.css" rel="stylesheet" />
     <div class="container">

            <h1 class="title">Edit Admin</h1>
            <div class="message messageerror"></div>

         <div class="input">
                <span id="lblPicture">Profile Picture:</span>
               <input type="file" name="uplPicture" id="uplPicture" />
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
               <asp:Label ID="Label4" runat="server" Text="Admin Name :"></asp:Label>
                <asp:TextBox ID="TextBox1" class="txtinput" placeholder="Enter Admin Name" runat="server" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>

         <div class="input">
               <asp:Label ID="Label7" runat="server" Text="UserName :"></asp:Label>
                <asp:TextBox ID="TextBox4" class="txtinput" placeholder="Enter Username" runat="server" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>

         <div class="input">
               <asp:Label ID="Label1" runat="server" Text="Contact Number :"></asp:Label>
                <asp:TextBox ID="TextBox5" class="txtinput" placeholder="Enter Contact Number" runat="server" ></asp:TextBox>
                <div class="inputerrormessage"></div>
           </div>

        

             <asp:Button ID="btnUpdate"  runat="server" Text="Update" class="button" BackColor="Green" />

             <asp:Button ID="btnCancel"  runat="server" Text="cancel" class="button" BackColor="Red" />

   </div>

</asp:Content>
