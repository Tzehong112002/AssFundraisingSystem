<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="becomeOrganization.aspx.cs" Inherits="AssFundraisingSystem.UserSide.becomeOrganization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="css/becomeOrganizationStyle.css" rel="stylesheet" />
             <div class="container">

            <h1 class="title"> Orgnization Application </h1>
            <div class="message messageerror"></div>
            <div class="input">
                <asp:Label ID="Label4" runat="server" Text="Company Name:"></asp:Label>
                <asp:TextBox ID="txtCompanyName" class="txtinput" placeholder="Enter company name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ControlToValidate="txtCompanyName" ErrorMessage="Company Name is required." Display="Dynamic"></asp:RequiredFieldValidator>
                <div class="inputerrormessage"></div>
            </div>
  

              <div class="input">
                <span id="lblFrontPicture">IC Picture (Front)</span>
                <asp:FileUpload ID="UploadFrontIC" runat="server" />
                <asp:RegularExpressionValidator ID="revUploadFrontIC" runat="server" ControlToValidate="UploadFrontIC"
                    ValidationExpression="^.*\.(jpg|jpeg|png)$"
                    ErrorMessage="Please upload a valid image file with extension JPG, JPEG, or PNG." Display="Dynamic"></asp:RegularExpressionValidator>
              
                <div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <span id="lblBackPicture">IC Picture (Back)</span>
                <asp:FileUpload ID="UploadBackIC" runat="server" />
                <asp:RegularExpressionValidator ID="revUploadBackIC" runat="server" ControlToValidate="UploadBackIC"
                    ValidationExpression="^.*\.(jpg|jpeg|png)$"
                    ErrorMessage="Please upload a valid image file with extension JPG, JPEG, or PNG." Display="Dynamic"></asp:RegularExpressionValidator>
              
                <div class="inputerrormessage"></div>
            </div>

          

             <asp:Button ID="btnSubmit"  runat="server" Text="Submit" class="button" BackColor="Green" OnClick="btnSubmit_Click" />


   </div>

</asp:Content>
