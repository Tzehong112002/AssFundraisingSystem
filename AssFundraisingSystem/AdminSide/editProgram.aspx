<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="editProgram.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.editProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/editProgramStyle.css" rel="stylesheet" />
             <div class="container">

            <h1 class="title">Edit Event</h1>
            <div class="message messageerror"></div>
            <div class="input">
               <asp:Label ID="Label4" runat="server" Text="Event Name :"></asp:Label>
                <asp:TextBox ID="TextBox1" class="txtinput" placeholder="Event Name" runat="server" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>
         <div class="input">
              <asp:Label ID="Label1" runat="server" Text="Categories :"></asp:Label>
             <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" CssClass="dropdownlist">
                 <asp:ListItem>Animal</asp:ListItem>
                 <asp:ListItem>Human</asp:ListItem>
                 <asp:ListItem>flood</asp:ListItem>
                 <asp:ListItem></asp:ListItem>
                </asp:DropDownList>

         </div>
         <div class="input">
             <asp:Label ID="Label2" runat="server" Text="Start Date :"></asp:Label>
             <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
         </div>

         <div class="input">
             <asp:Label ID="Label3" runat="server" Text="End Date :"></asp:Label>
             <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
         </div>
        

            <div class="input">
                <asp:Label ID="Label5" runat="server" Text="Target :"></asp:Label>
                <asp:TextBox ID="TextBox2" class="txtinput" placeholder="Enter Target" runat="server" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <asp:Label ID="Label6" runat="server" Text="Description :"></asp:Label>
                <asp:TextBox ID="TextBox3" class="txtinput" placeholder="Enter  description" runat="server" TextMode="Password" Height="250px" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <span id="lblPicture">Profile Picture:</span>
               <input type="file" name="uplPicture" id="uplPicture" />
                <div class="inputerrormessage"></div>
            </div>
          

             <asp:Button ID="btnUpdate"  runat="server" Text="Update" class="button" BackColor="Green" OnClick="btnUpdate_Click" />

             <asp:Button ID="btnCancel"  runat="server" Text="Cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" />

   </div>

</asp:Content>
