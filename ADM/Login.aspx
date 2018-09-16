<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdaptiveLearningSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" runat="server" media="screen" href="Login.css"/>
    <script type="text/javascript">
        function check() {
            if (!document.getElementById("txtLecturerID").value) {
               
                document.getElementById('lblError').style.display = 'inherit';
                document.getElementById("lblError").innerText = "Username is empty";
                return false;
            }
            else if (!document.getElementById("txtLecturerPassword").value) {
                
                document.getElementById('lblError').style.display = 'inherit';
                document.getElementById("lblError").innerText = "Password is empty";
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="SystemTitle">
                <h1>Adaptive Learning System</h1>
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="loginPanel" id="MainPanel" runat="server">

                        <div class="loginTitle">
                            <h1>
                                <asp:Label ID="Label1" runat="server" Text="Label"> Log In</asp:Label></h1>
                        </div>
                        <div class="errorMessage">
                            
                                <asp:Label ID="lblError" runat="server" Text="Label" ForeColor="Red" style="display: none;"></asp:Label>
                        </div>
                        <div class="categoryButton" runat="server" id="CategoryPanel">
                            <asp:Button CssClass="btnSignIn" ID="btnStudent" runat="server" Text="Sign In As Student" OnClick="btnStudent_Click" />
                            <asp:Button CssClass="btnSignUp" ID="btnLecturer" runat="server" Text="Sign In As Lecturer" OnClick="btnLecturer_Click" />
                        </div>


                        <div runat="server" id="StudentPanel">
                            <div class="loginDetails">

                                <asp:TextBox ID="txtStudentID" CssClass="LoginTextbox" runat="server" placeholder="Student ID"></asp:TextBox>
                                <asp:TextBox ID="txtStudentPassword" CssClass="LoginTextbox" runat="server" placeholder="Password"></asp:TextBox>
                                <asp:LinkButton CssClass="ForgetPass" ID="lbtnStudForgetPass" runat="server">Forget Password?</asp:LinkButton>
                            </div>

                            <div class="loginButton">
                                <asp:Button CssClass="btnSignIn" ID="btnStudentSignIn" runat="server" Text="Sign In" OnClick="btnStudentSignIn_Click" />
                                <asp:Button CssClass="btnSignUp" ID="btnStudentSignUp" runat="server" Text="Sign Up" OnClick="btnStudentSignUp_Click" />
                            </div>
                        </div>

                        <div runat="server" id="LecturerPanel">
                            <div class="loginDetails">

                                <asp:TextBox ID="txtLecturerID" CssClass="LoginTextbox" runat="server" placeholder="Lecturer ID"></asp:TextBox>
                                <asp:TextBox ID="txtLecturerPassword" CssClass="LoginTextbox" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                <asp:LinkButton CssClass="ForgetPass" ID="lbtnLecForgetPass" runat="server">Forget Password?</asp:LinkButton>
                            </div>

                            <div class="loginButton">
                                <asp:Button CssClass="btnSignIn" ID="btnLecturerSignIn" runat="server" Text="Sign In" OnClientClick="return check()"  OnClick="btnLecturerSignIn_Click"/>
                                <asp:Button CssClass="btnSignUp" ID="btnLecturerSignUp" runat="server" Text="Sign Up" OnClick="btnLecturerSignUp_Click1" />
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
              

        
   
    </form>
</body>
</html>
