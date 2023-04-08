<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="ParticipantRecord.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.ParticipantRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/Participants.css" rel="stylesheet" />
     <div class="title"><h1>Participants List</h1> </div>
    <div class="box">
        <asp:GridView ID="gvParticipants" runat="server">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFormatString="Ban.aspx?id={0}" Text="Update" DataNavigateUrlFields="UserID" />
                <asp:HyperLinkField DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="Delete.aspx?id={0}" Text="Delete" />
            </Columns>
        </asp:GridView>
           
        <asp:Button class ="cCate" ID="cCate" runat="server" Text="Back" />
    </div>
</asp:Content>
