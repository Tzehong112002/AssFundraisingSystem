<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="editProgram.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.editProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/editProgramStyle.css" rel="stylesheet" />
             <div class="container">

            <h1 class="title">Edit Event</h1>
            <div class="message messageerror"></div>
            <div class="input">
               <asp:Label ID="Label4" runat="server" Text="Event Name :"></asp:Label>
                <asp:TextBox ID="txtEventName" class="txtinput" placeholder="Event Name" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEventName" ErrorMessage="Please enter an event name"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>
         <div class="input">
              <asp:Label ID="Label1" runat="server" Text="Categories :"></asp:Label>
             <asp:DropDownList ID="ddlCategories" runat="server" Width="100%" CssClass="dropdownlist"></asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCategories" ErrorMessage="Please select a category"></asp:RequiredFieldValidator>
         </div>


         <div class="input">
             <asp:Label ID="Label2" runat="server" Text="Start Date :"></asp:Label>
             <asp:Calendar ID="cStartDate" runat="server" OnDayRender="cStartDate_DayRender"></asp:Calendar>
         </div>

         <div class="input">
             <asp:Label ID="Label3" runat="server" Text="End Date :"></asp:Label>
             <asp:Calendar ID="cEndDate" runat="server" OnDayRender="cEndDate_DayRender"></asp:Calendar>
         </div>
        

            <div class="input">
                <asp:Label ID="Label5" runat="server" Text="Target :"></asp:Label>
                <asp:TextBox ID="txtTarget" class="txtinput" placeholder="Enter Target" runat="server" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTarget" ErrorMessage="Please enter a target"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTarget" ValidationExpression="^\d+$" ErrorMessage="Please enter a valid number"></asp:RegularExpressionValidator>
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <asp:Label ID="Label6" runat="server" Text="Description :"></asp:Label>
                <asp:TextBox ID="txtDesc" class="txtinput" placeholder="Enter  description" runat="server"  Height="250px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesc" ErrorMessage="Please enter a description"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <span id="lblPicture">Profile Picture:</span>
                <asp:FileUpload ID="ImgUpload" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ImgUpload" ErrorMessage="Please upload the profile picture"></asp:RequiredFieldValidator>

&nbsp;<div class="inputerrormessage"></div>
            </div>
          

             <asp:Button ID="btnUpdate"  runat="server" Text="Update" class="button" BackColor="Green" OnClick="btnUpdate_Click" />

             <asp:Button ID="btnCancel"  runat="server" Text="Cancel" class="button" BackColor="Red" OnClick="btnCancel_Click" CausesValidation="false"/>

   </div>

</asp:Content>
