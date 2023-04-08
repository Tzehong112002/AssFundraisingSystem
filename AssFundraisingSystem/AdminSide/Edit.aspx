<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/CssForCreate.css" rel="stylesheet" />

     <div class="container">
		<div class="otak"><h1>Edit The Category Information</h1></div>
		
		 <div class="lblTitle">
            <table>
                <tr>
                    <td><label for="cateTitle">Category Title:</label></td>
                    <td>
                        <asp:TextBox ID="cid" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="cTitle" name="cTitle" placeholder="Enter Category Title" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="cTitle"
                          ErrorMessage="Please Enter Category Title!"
                          ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>

                </tr>

              

                <tr>
                    <td><label for="cateDescription">Category Description:</label></td>
                    <td><asp:TextBox ID="cateDescription" name="cateDescription" placeholder="Please enter description" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="cateDescription"
                            ErrorMessage="Please Enter Description!"
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                     <td><label for="cateDescription">Category Image:</label></td>
                    <td>
                        <div class="row" id="image-container">
                                    <div class="image_container d-flex justify-content-center position-relative" id="imageCon" runat="server">
                                      
                                    </div>
                             </div>
                    </td>
                </tr>
            </table>


        </div>

        
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
      <asp:Button ID="btnBack" runat="server" Text="Cancel" type="button" OnClick="btnBack_Click" />
       
            
    </div>
	


   
</asp:Content>
