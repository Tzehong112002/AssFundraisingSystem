﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="Ban.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.Ban" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/BUpdate.css" rel="stylesheet" />
    <link href="css/formBtn.css" rel="stylesheet" />
<div class="title"><h1>Update Account</h1> </div>

    <div class ="container">

        <p> Are you sure you wan to update the following account?</p>
     <table>
                <tr>
                    <td class="formRow">Id: </td>
                    <td class="formRow">
                        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                    </td>
                </tr>                   

                 <tr>
                    <td class="formRow">Name: </td>
                    <td class="formRow">
                        <asp:Label ID="lblName" runat="server" Text="" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formRow">Ban: </td>
                    <td class="formRow">
                        <asp:RadioButtonList ID="banStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Yes" Selected="True">Ban</asp:ListItem>
                                <asp:ListItem Value="No">Unban</asp:ListItem>
                            </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="formRow"></td>
                    <td class="formRow">
                        <asp:Button ID="btnBan" CssClass="btnBan" runat="server" Text="Ban" OnClick="btnBan_Click" />
        
                        <asp:Button ID="btnCancel" CssClass="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
                
    </div>
    
</asp:Content>
