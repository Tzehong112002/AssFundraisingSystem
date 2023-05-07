<%@ Page Title="" Language="C#" MasterPageFile="~/organizationSide/organizationMaster.Master" AutoEventWireup="true" CodeBehind="applyProgram.aspx.cs" Inherits="AssFundraisingSystem.organizationSide.applyProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link href="css/applyProgramStyle.css" rel="stylesheet" />

     <div class="container">

            <h1 class="title">Apply Event</h1>
            <div class="message messageerror"></div>
            <div class="input">
               <asp:TextBox ID="txtEventName" class="txtinput" placeholder="Event Name" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEventName" ErrorMessage="Please enter an event name"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>
         <div class="input">
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
               <asp:TextBox ID="txtTarget" class="txtinput" placeholder="Enter Target" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTarget" ErrorMessage="Please enter a target"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTarget" ValidationExpression="^\d+$" ErrorMessage="Please enter a valid number"></asp:RegularExpressionValidator>
               <div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <asp:TextBox ID="txtDesc" class="txtinput" placeholder="Enter  description" runat="server"  Height="250px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesc" ErrorMessage="Please enter a description"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <span id="lblPicture">Event Picture:</span>
                <asp:FileUpload ID="ImgUpload" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ImgUpload" ErrorMessage="Please upload the event picture"></asp:RequiredFieldValidator>

&nbsp;<div class="inputerrormessage"></div>
            </div>
          

             <asp:Button ID="btnApply"  runat="server" Text="Apply Event" class="button" BackColor="Green" OnClick="btnApply_Click" />


   </div>


</asp:Content>
