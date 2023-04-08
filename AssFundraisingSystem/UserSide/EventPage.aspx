<%@ Page Title="Event Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EventPage.aspx.cs" Inherits="AssFundraisingSystem.UserSide.EventPage" %>
<asp:Content ID="EventPage" ContentPlaceHolderID="main" runat="server">

    <link rel="stylesheet" href="css/EventPageStyle.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">

    <div class="popular_event_area pt-120 event_details ">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="single_event">
                        <div class="thumb">
                            <asp:Image ID="EventImage" runat="server" style="align-content:center;width:100%;height:50%;"/>
                        </div>
                        <div class="event_content">
                            <div class="custom_progress_bar">
                                <div class="progress">
                                    <div runat="server" id="progressBar" class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuemin="0" aria-valuemax="100">
                                        <span runat="server" class="progres_count" id="lblPercentage"></span>
                                    </div>
                                  </div>
                            </div>
                            <div class="balance d-flex justify-content-between align-items-center">
                                <span><asp:Label ID="lblDonated" runat="server" Text=""></asp:Label></span>
                                <span><asp:Label ID="lblTarget" runat="server" Text=""></asp:Label></span>
                            </div>
                            <br />
                            <asp:Label ID="lblEventTitle" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="#0033CC" Font-Underline="True"></asp:Label>
                            <br />
                            <asp:Label ID="lblEventDetail" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="make_donation_area section_padding">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-6">
                    <div class="section_title text-center mb-55">
                        <h3><span>Make a Donation</span></h3>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="donate_now_btn text-center">
                        <br />
                        <asp:Button ID="donatebtn" runat="server" Text="Donate Now" CssClass="button" BackColor="lightBlue" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" Height="50px" Width="150px" OnClick="donatebtn_Click"/>
                    </div>
                </div>
                <br />
                <br />
                
    <%-- =====================================Participant================================================================ --%> 
               
                <hr />
                <div class="comments-area">
                    <div>
                        <div class="w3-container">
                  <h2>Participant List</h2>
                  <ul class="w3-ul w3-card-4">
                    <li class="w3-bar">
                      <img src="Img/profile.png" class="w3-bar-item w3-circle w3-hide-small" style="width:85px">
                      <div class="w3-bar-item">
                        <span class="w3-large">Mike</span><br>
                        <span>Donated RM100</span>
                      </div>
                    </li>

                    <li class="w3-bar">
                      <img src="Img/profile.png" class="w3-bar-item w3-circle w3-hide-small" style="width:85px">
                      <div class="w3-bar-item">
                        <span class="w3-large">Mike</span><br>
                        <span>Donated RM100</span>
                      </div>
                    </li>

                    <li class="w3-bar">
                      <img src="Img/profile.png" class="w3-bar-item w3-circle w3-hide-small" style="width:85px">
                      <div class="w3-bar-item">
                        <span class="w3-large">Mike</span><br>
                        <span>Donated RM100</span>
                      </div>
                    </li>
                  </ul>
                </div>
              </div>
                    <br />
                    <br />


    <%-- =====================================Comment================================================================ --%> 



                    
                    
                
              

               <div class="comments-area">
                  <h2>Comments</h2>
                  <div class="comment-list">

                    <asp:Repeater ID="commentRepeater" runat="server" OnItemCommand="commentRepeater_ItemCommand">
                        <ItemTemplate>
                            <div class="w3-container">
                              <ul class="w3-ul w3-card-4">
                                <li class="w3-bar">
                                  <asp:Image ID="profilePic" runat="server" ImageUrl='<%# Eval("ProfilePic") %>' style="width:85px" ImageAlign="Left"/>
                                  <div class="w3-bar-item">
                                    <div class="username" style="font-size:large; color:blue"><%# Eval("Username") %></div>
                                    <div class="comment-body"><%# Eval("CommentContent") %></div>
                                    <small><%# Eval("DateCommented", "{0:MMMM dd, yyyy}") %></small>
                                  </div>
                                </li>
                              </ul>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                              
                     </div>
                  </div>
                    <br />
                    <br />




            </div>
        </div>
    </div>
    

</asp:Content>
