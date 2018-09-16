<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="AdaptiveLearningSystem.CourseDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" runat="server" media="screen" href="main.css"/>
    <link rel="stylesheet" runat="server" media="screen" href="CourseList.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script> 

        $(document).ready(function () {
            $(".dropdown").click(function (e) {
                e.stopPropagation();
                if ($('.dropdown').hasClass('active')) {
                    
                    $(".dropdown").removeClass("active");
                    $(".dropdown").removeClass("activeBackground");
                }
                else {
                    $(".dropdown").addClass("active");
                    $(".dropdown").addClass("activeBackground");
                }
            });
        });

        $(document).click(function () {
            
            $(".dropdown").removeClass("active");
            $(".dropdown").removeClass("activeBackground");
           
        });


        </script>
    <style type="text/css">
        .auto-style1 {
            width: 126px;
        }
        .auto-style2 {
            width: 427px;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
    <div id="upperNavBar">
        
    <ul id="UpperNavList">
        <li><img id="tarcIcon" src="images/tarcIcon.png" width="50"/><p>Adaptive Learning System</p></li>
        <li class="dropdown"><a><asp:Image ID="profilePic"  ImageUrl="~/images/profIcon.png" runat="server" style="width: 35px" />
            <span id="welcome"><small>Welcome</small><br />
                <small><asp:Label ID="lblUserName" runat="server" Text="Label">Loo Zhe Xin</asp:Label></small>
            </span>
            <div id="downIcon"> &#9660;</div></a>
            <div class="dropdown-content">
      <asp:LinkButton  CssClass="dropdown-item" ID="ProfileLinkButton" runat="server">Profile</asp:LinkButton>
      <asp:LinkButton  CssClass="dropdown-item" ID="LogOutLinkButton" runat="server">Log Out</asp:LinkButton>
    </div>
                  
          </li>
        <li><a><img src="images/notificationIcon.png" width="35px"/></a></li>
          
          
        
    </ul>
    </div>   
       <div>
        <ul class="SecondNavBar">
          <li><asp:LinkButton CssClass="SecondNavList" ID="HomeLinkButton" runat="server">Home</asp:LinkButton></li>
          <li><asp:LinkButton CssClass="SecondNavList" ID="TutorialLinkButton" runat="server">Course</asp:LinkButton></li>
          <li><asp:LinkButton CssClass="SecondNavList" ID="ResultLinkButton" runat="server" >Report</asp:LinkButton></li>
          <li><asp:LinkButton CssClass="SecondNavList" ID="ProfilesLinkButton" runat="server">My Profile</asp:LinkButton></li>
        </ul>
        </div> 
       <%-- start your coding inside div below --%>
    <div class="wrap-content" >
        <div class="Header">
            <h1><i>
            Course Details</i>
            </h1>
       </div>
        <div class="Header">
            <h2><i>
            Please choose tutorial group(s).</i>
            </h2>
            
       </div>
       
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

            
        <div class="tutorialGrpList">
            <asp:Label ID="lblErrorMessage" runat="server" Text="[lblErrorMessage]" ForeColor="Red"></asp:Label>
            <asp:CheckBoxList ID="chkboxTutorialGroup" runat="server"></asp:CheckBoxList>
        </div>
                <div class="BottomButtonGroup">
                    <asp:Button ID="btnBack" CssClass="BottomButton" runat="server" Text="Back" OnClick="btnBack_Click" />
                    <asp:Button ID="btnConfrim" CssClass="BottomButton" runat="server" Text="Confirm" OnClick="btnConfrim_Click" />
                </div>

        
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

