<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="ParticipantRecord.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.ParticipantRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/Participants.css" rel="stylesheet" />
    <link href="css/formBtn.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/dataTable1.css">
    <link rel="stylesheet" href="css/dataTable2.css">
    
    <div class="writingPage">
    <div class="title"><h1>Participants List</h1> </div>
    <asp:GridView ID="gvParticipants" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" style="width:100%">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="PhoneNo" HeaderText="Phone Number" />
            <asp:HyperLinkField DataNavigateUrlFormatString="Ban.aspx?id={0}" Text="Update" DataNavigateUrlFields="UserID" HeaderText="Action" >
            <ControlStyle CssClass="btnUpdate1" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
    </div>  
    <asp:Button class ="cCate" ID="cCate" runat="server" Text="Back" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript">
    $(function () {
        $("[id*=gvParticipants]").DataTable(
            {
                bLengthChange: true,
                bFilter: true,
                bSort: true,
                bPaginate: true
            });
    });
    </script>
</asp:Content>
