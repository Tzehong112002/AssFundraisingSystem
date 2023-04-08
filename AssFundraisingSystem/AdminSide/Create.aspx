<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/CssForCreate.css" rel="stylesheet" />
     <div class="container">
		<div class="otak"><h1>Add New Category</h1></div>
		
			<label for="cateTitle">Category Title :</label>
			<!--<input type="text" id="cateTitle" name="cateTitle"  placeholder="Please enter category title" required=""/>-->
			<asp:TextBox ID="cateTitle" name="cateTitle" placeholder="Enter Category Title" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="cateTitle"
          ErrorMessage="Please Enter Category Title!"
          ForeColor="Red">
        </asp:RequiredFieldValidator>

			<!--Desc--->
			<label for="cateDesc">Category Description :</label>
			<asp:TextBox ID="cateDesc" name="cateDesc" placeholder="Enter Description" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="cateDesc"
          ErrorMessage="Please Enter Description!"
          ForeColor="Red">
        </asp:RequiredFieldValidator>

			<!---Img--->
			<label for="cateImg">Category Image :</label>
			<asp:FileUpload ID="cateImg" runat="server" />
			<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="cateImg"
          ErrorMessage="Please Upload Photo!"
          ForeColor="Red">
        </asp:RequiredFieldValidator>


			<!--<input type="submit" value="Add Category"/>-->
		 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
      <asp:Button ID="btnCancel" runat="server" Text="Cancel" type="reset" />
		
	</div>


   
</asp:Content>
