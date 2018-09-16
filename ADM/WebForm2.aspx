<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="AdaptiveLearningSystem.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script>
function myFunction() {
    var input, filter, ul, li, a, i;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    ul = document.getElementById("myUL");
    li = ul.getElementsByTagName("li");
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}
</script>

    <style>
* {
  box-sizing: border-box;
}

#myInput {
  background-image: url('/css/searchicon.png');
  background-position: 10px 12px;
  background-repeat: no-repeat;
  width: 100%;
  font-size: 16px;
  padding: 12px 20px 12px 40px;
  border: 1px solid #ddd;
  margin-bottom: 12px;
}

#myUL {
  list-style-type: none;
  padding: 0;
  margin: 0;
}

#myUL li a {
  border: 1px solid #ddd;
  margin-top: -1px; /* Prevent double borders */
  background-color: #f6f6f6;
  padding: 12px;
  text-decoration: none;
  font-size: 18px;
  color: black;
  display: block
}

#myUL li a:hover:not(.header) {
  background-color: #eee;
}
</style>

</head>
<body >
<form runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   

       
    
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        <asp:ListItem Text="qwer" Value="qwer" ></asp:ListItem>
        <asp:ListItem Text="req" Value="reqw" ></asp:ListItem>
    </asp:CheckBoxList>
            
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
     </form>
</body>
</html>
