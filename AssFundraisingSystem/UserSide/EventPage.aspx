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
                            <img src="Img/event.jpg" style="align-content:center;width:100%;height:50%;"/>
                        </div>
                        <div class="event_content">
                            <div class="custom_progress_bar">
                                <div class="progress">
                                    <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 40%;" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100">
                                        <span class="progres_count">
                                            40%
                                        </span>
                                    </div>
                                  </div>
                            </div>
                            <div class="balance d-flex justify-content-between align-items-center">
                                <span>Raised: RM400.00 </span>
                                <span>Goal: RM1000.00 </span>
                            </div>
                            <br />
                            <h4>Help me improve my quality of life through a hip replacement</h4>
                            <p>(Filler,not related) : The increasing rate of orthopedic procedures, hip arthroplasty in particular, requires improvement of surgical techniques, as well as of the respective rehabilitation protocols. The aim of the study was to assess differences in the quality of life and incidence of limping eight years after total hip arthroplasty performed with a minimally invasive or classic approach. This cross-sectional study included 68 patients, i.e. 32 operated with classic approach and 36 with minimally invasive approach during 2011. The following parameters were observed: anthropometric measurements, history of comorbidity, subjective assessment of limping, and SF-36 questionnaire (Short Form Survey Instrument). SF-36 testing, which consists of 8 domains, showed that 5 domains of the quality of life were statistically significantly better in the minimally invasive group (level of significance p<0.05). These domains were role of limitation due to physical health (p=0.01), energy (p=0.02), social functioning (p=0.02), pain (p=0.02) and general health (p=0.00). The minimally invasive group had a statistically significantly lower incidence of limping (p=0.032). Quality of life after hip replacement could be a decisive factor when choosing the type of orthopedic procedure. The higher number of limping patients in the classic approach group may have contributed to differences in the quality of life. In conclusion, the minimally invasive approach enables higher long-term quality of life and functional recovery.</p>
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
                        <br />
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-6">
                        <div class="row align-items-center">
                            <div class="col-md-4">
                                <div class="single_amount">
                                    <div class="input_field">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                              <span class="input-group-text" id="basic-addon1">RM</span>
                                            </div>
                                            <input type="text" class="form-control" placeholder="50" aria-label="Username" aria-describedby="basic-addon1">
                                          </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="single_amount">
                                   <div class="fixed_donat d-flex align-items-center justify-content-between">
                                       <div class="select_prise">
                                           <h4>Select Amount:</h4>
                                       </div>
                                        <div class="single_doonate"> 
                                            <input type="radio" id="blns_1" name="radio-group" checked>
                                            <label for="blns_1">10</label>
                                        </div>
                                        <div class="single_doonate"> 
                                            <input type="radio" id="blns_2" name="radio-group" checked>
                                            <label for="blns_2">30</label>
                                        </div>
                                        <div class="single_doonate"> 
                                            <input type="radio" id="Other" name="radio-group" checked>
                                            <label for="Other">Other</label>
                                        </div>
                                   </div>
                                </div>
                            </div>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="donate_now_btn text-center">
                        <br />
                        <asp:Button ID="donatebtn" runat="server" Text="Donate Now" CssClass="button" BackColor="lightBlue" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" Height="50px" Width="150px"/>
                    </div>
                </div>






                
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


                    <div>
                        <div class="comments-area">
                  <h4>3 Comments</h4>
                  <div class="comment-list">
                     <div class="single-comment justify-content-between d-flex">
                        <div class="user justify-content-between d-flex">
                           <div class="thumb">
                              <img src="Img/profile.png" style="height:50px;width:50px"/>
                           </div>
                           <div class="desc">
                              <p class="comment">
                                 Multiply sea night grass fourth day sea lesser rule open subdue female fill which them
                                 Blessed, give fill lesser bearing multiply sea night grass fourth day sea lesser
                              </p>
                              <div class="d-flex justify-content-between">
                                 <div class="d-flex align-items-center">
                                    <h5>
                                       <a href="#">Emilly Blunt</a>
                                    </h5>
                                    <p class="date">March 4, 2023 at 3:12 pm </p>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="comment-list">
                     <div class="single-comment justify-content-between d-flex">
                        <div class="user justify-content-between d-flex">
                           <div class="thumb">
                              <img src="Img/profile.png" style="height:50px;width:50px"/>
                           </div>
                           <div class="desc">
                              <p class="comment">
                                 Multiply sea night grass fourth day sea lesser rule open subdue female fill which them
                                 Blessed, give fill lesser bearing multiply sea night grass fourth day sea lesser
                              </p>
                              <div class="d-flex justify-content-between">
                                 <div class="d-flex align-items-center">
                                    <h5>
                                       <a href="#">Emilly Blunt</a>
                                    </h5>
                                    <p class="date">March 4, 2023 at 3:12 pm </p>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="comment-list">
                     <div class="single-comment justify-content-between d-flex">
                        <div class="user justify-content-between d-flex">
                           <div class="thumb">
                              <img src="Img/profile.png" style="height:50px;width:50px"/>
                           </div>
                           <div class="desc">
                              <p class="comment">
                                 Multiply sea night grass fourth day sea lesser rule open subdue female fill which them
                                 Blessed, give fill lesser bearing multiply sea night grass fourth day sea lesser
                              </p>
                              <div class="d-flex justify-content-between">
                                 <div class="d-flex align-items-center">
                                    <h5>
                                       <a href="#">Emilly Blunt</a>
                                    </h5>
                                    <p class="date">March 4, 2023 at 3:12 pm </p>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
                    </div>
                </div>


                

    <%-- =====================================Comment================================================================ --%> 


              <%--  <div class="comment-form" >
                    <h4>Leave a Reply</h4>
                        <div class="row">
                        <div class="col-12">
                            <div class="form-group">
                                <asp:TextBox ID="txtComment" runat="server" Height="300px" TextMode="MultiLine" Width="1000px" placeholder="Comment" BorderColor="#0066FF" BorderStyle="Inset" BorderWidth="5px" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <asp:TextBox ID="txtName" runat="server" Width="460px" placeholder="Name" Height="50px" BorderColor="#0066FF" BorderStyle="Ridge" BorderWidth="5px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtEmail" runat="server" Width="460px" placeholder="Email" Height="50px" BorderColor="#0066FF" BorderStyle="Groove" BorderWidth="5px"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                        <div class="form-group">
                        <asp:Button ID="submitCommentbtn" runat="server" Text="Submit" CssClass="button" BackColor="lightBlue" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" Height="50px" Width="150px"/>
                        </div>
                </div>--%>


            </div>
        </div>
    </div>
    

</asp:Content>
