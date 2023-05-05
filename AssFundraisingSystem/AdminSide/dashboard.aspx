<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/adminMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="AssFundraisingSystem.AdminSide.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/dashboardStyle.css" rel="stylesheet" />
    <link href="css/approveEventStyle.css" rel="stylesheet" />

    <div id="divToPrint">
    <div class="title">

        <h1 style="margin:0px;">Dashboard</h1> 
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="buttonAdd " OnClientClick="javascript:printDiv('divToPrint');" />
    </div>

    <div class="home-content">
      <div class="overview-boxes">
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total Event</div>
              <asp:Label ID="totalEvent" runat="server" Text="Label" class="number"></asp:Label>

            <div class="indicator">
              <i class='bx bx-up-arrow-alt'></i>
              <span class="text">Up from yesterday</span>
            </div>
          </div>
          <i class='bx bx-cart-alt cart'></i>
        </div>
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total User Account</div>
              <asp:Label ID="totalUser" runat="server" Text="Label" class="number"></asp:Label>
            <div class="indicator">
              <i class='bx bx-up-arrow-alt'></i>
              <span class="text">Up from yesterday</span>
            </div>
          </div>
          <i class='bx bxs-cart-add cart two' ></i>
        </div>
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total Donation </div>
            <asp:Label ID="totalDonationLabel" runat="server"  class="number"></asp:Label>
            <div class="indicator">
              <i class='bx bx-up-arrow-alt'></i>
              <span class="text">Up from Just Now</span>
            </div>
          </div>
          <i class='bx bx-cart cart three' ></i>
        </div>
        <div class="box">
          <div class="right-side">
            <div class="box-topic">Total Visitor</div>
            <asp:Label ID="ttlVisitor" runat="server" Text="50" class="number"></asp:Label>
            <div class="indicator">
              <i class='bx bx-down-arrow-alt down'></i>
              <span class="text">Up From Just Now</span>
            </div>
          </div>
          <i class='bx bxs-cart-download cart four' ></i>
        </div>
      </div>

      <div class="sales-boxes">
        <div class="top-sales box">
          <div class="title">Recent Donation List</div>
          <ul class="top-sales-details">
              <li>
                
                  <span><b>Name</b></span>
                  <span><b>Event Name</b></span>
                  <span><b>Amount</b></span>

              </li>

         <asp:Repeater ID="RepeaterDashboard" runat="server" >
                <ItemTemplate>

            <li>
            
              
              <span class="product">><%#Eval("Name") %></span>
              <span class="product"><%#Eval("EventName") %></span>
           
            <span class="price">RM<%#Eval("Amount") %></span>
          </li>


              </ItemTemplate>
        </asp:Repeater>


          </ul>
        </div>


        <div class="top-sales box">
          <div class="title">Event Not Yet Approve</div>
          <ul class="top-sales-details">
              <li>
                
                  <span><b>Image</b></span>
                  <span><b>Event Name</b></span>
                  <span><b>Status</b></span>

              </li>
              <asp:Repeater ID="RepeaterDashboard2" runat="server" >
                <ItemTemplate>
            <li>
   
              <img src='<%#Eval("EventIMG") %>' alt="Event Image" class="event-image" />
            <span class="product"><%#Eval("EventName") %></span>
            <span class="product"><%#Eval("EventStatus") %></span>
            
       

          </li>

              </ItemTemplate>
        </asp:Repeater>


          </ul>
        </div>
      </div>
    </div>
</div>
    <script type="text/javascript">
        function printDiv(divName) {
            window.print();
        }
    </script>ipt>
</asp:Content>



