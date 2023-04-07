<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="becomeOrganization.aspx.cs" Inherits="AssFundraisingSystem.UserSide.becomeOrganization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="css/becomeOrganizationStyle.css" rel="stylesheet" />
             <div class="container">

            <h1 class="title"> Orgnization Application </h1>
            <div class="message messageerror"></div>
            <div class="input">
               <asp:Label ID="Label4" runat="server" Text="Company Name :"></asp:Label>
                <asp:TextBox ID="txtCompanyName" class="txtinput" placeholder="Enter company name" runat="server" ></asp:TextBox>
                <div class="inputerrormessage"></div>
            </div>    

            <div class="input">
                <span id="lblPicture">IC Picture (Front)</span>
                <asp:FileUpload ID="UploadFrontIC" runat="server" />
&nbsp;<div class="inputerrormessage"></div>
            </div>

            <div class="input">
                <span id="lblPicture">IC Picture (Back)</span>
                <asp:FileUpload ID="UploadBackIC" runat="server" />
&nbsp;<div class="inputerrormessage"></div>
            </div>
          

             <asp:Button ID="btnSubmit"  runat="server" Text="Submit" class="button" BackColor="Green" OnClick="btnSubmit_Click" />


   </div>

</asp:Content>
