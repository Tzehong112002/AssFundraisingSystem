<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="ParticipantRecord.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.ParticipantRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< Updated upstream
    <link href="css/Participant.css" rel="stylesheet" />
=======
    <link href="css/Participants.css" rel="stylesheet" />
>>>>>>> Stashed changes
     <div class="title"><h1>Participants List</h1> </div>
    <div class="box">
        <table class="fence">
            <tr>
                <th>User ID</th>
                <th>Name</th>
                <th>Email</th>
                <th>Action</th>
                
            </tr>
            <tr>
                <td>U001</td>
                <td>Danile</td>
                <td>danile1@gmail.com</td>
                
                <td>
                    <asp:LinkButton ID="btnBan" runat="server">BAN</asp:LinkButton>
                    <asp:LinkButton ID="delete" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>
             <tr>
                <td>U002</td>
                <td>Milan Ng</td>
                <td>milan21@gmail.com</td>
                
                   <td>
                    <asp:LinkButton ID="bnBan" runat="server">BAN</asp:LinkButton>
                    <asp:LinkButton ID="deete" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>
             <tr>
                <td>U003</td>
                <td>Muhamand Ali</td>
                <td>ali33@gmail.com</td>
                
                   <td>
                    <asp:LinkButton ID="btBan" runat="server">BAN</asp:LinkButton>
                    <asp:LinkButton ID="elete" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>

             <tr>
                <td>U004</td>
                <td>Nasari</td>
                <td>ns221@gmail.com</td>
                
                   <td>
                    <asp:LinkButton ID="bBan" runat="server">BAN</asp:LinkButton>
                    <asp:LinkButton ID="dele" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>

            <tr>
                <td>U005</td>
                <td>Micheal Wong</td>
                <td>mw1232@gmail.com</td>
               
                   <td>
                    <asp:LinkButton ID="btnB" runat="server">BAN</asp:LinkButton>
                    <asp:LinkButton ID="delet" runat="server">DELETE</asp:LinkButton>              
                </td>
            </tr>
        </table>
        <asp:Button class ="cCate" ID="cCate" runat="server" Text="Back" />
    </div>
</asp:Content>
