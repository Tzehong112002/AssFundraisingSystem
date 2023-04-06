<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="addProgram.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.addProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/addProgramStyle.css" rel="stylesheet" />
         <div class="container">

            <h1 class="title">Add Event</h1>
            <div class="message messageerror"></div>
            <div class="input">
               <asp:Label ID="Label4" runat="server" Text="Event Name :"></asp:Label>
                <asp:TextBox ID="txtEventName" class="txtinput" placeholder="Event Name" runat="server" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>
         <div class="input">
              <asp:Label ID="Label1" runat="server" Text="Categories :"></asp:Label>
             <asp:DropDownList ID="ddlCategories" runat="server" Width="100%" CssClass="dropdownlist">
                 <asp:ListItem>Animal</asp:ListItem>
                 <asp:ListItem>Human</asp:ListItem>
                 <asp:ListItem>flood</asp:ListItem>
                 <asp:ListItem></asp:ListItem>
                </asp:DropDownList>

         </div>
         <div class="input">
             <asp:Label ID="Label2" runat="server" Text="Start Date :"></asp:Label>
             <asp:Calendar ID="cStartDate" runat="server"></asp:Calendar>
         </div>

         <div class="input">
             <asp:Label ID="Label3" runat="server" Text="End Date :"></asp:Label>
             <asp:Calendar ID="cEndDate" runat="server"></asp:Calendar>
         </div>
        

            <div class="input">
                <asp:Label ID="Label5" runat="server" Text="Target :"></asp:Label>
                <asp:TextBox ID="txtTarget" class="txtinput" placeholder="Enter Target" runat="server" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <asp:Label ID="Label6" runat="server" Text="Description :"></asp:Label>
                <asp:TextBox ID="txtDesc" class="txtinput" placeholder="Enter  description" runat="server"  Height="250px" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <span id="lblPicture">Profile Picture:</span>
                <asp:FileUpload ID="ImgUpload" runat="server" />
&nbsp;<div class="inputerrormessage"></div>
            </div>
          

             <asp:Button ID="btnUpdate"  runat="server" Text="Add Event" class="button" BackColor="Green" OnClick="btnUpdate_Click" />

             <asp:Button ID="btnCancel"  runat="server" Text="cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" />

   </div>

</asp:Content>
