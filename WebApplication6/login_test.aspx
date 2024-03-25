<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_test.aspx.cs" Inherits="AmHospital.login_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       
   <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width,initial-scale=1" />
 
    <link href="styles/bootstrap-3.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
  
  <link href="styles/jquery-ui.css" rel="stylesheet" />
    <script src="scripts/jquery-1.11.3.min.js"></script>
    <script src="scripts/jquery-ui.js"></script>
    <script src="styles/bootstrap-3.4.1-dist/js/bootstrap.min.js"></script>

      <link href="css/StyleSheet1.css" rel="stylesheet" />
     <style type="text/css" >

         #mydiv {
 position: fixed;
    top: 20%;
    left: 30%;
    margin-top: -50px;
    margin-left: -100px;
    background-color: #f3f3f3;
    width: 40%;
    min-height: 400px;
    
    padding:50px;
     
  border:1px dotted #717171;
}
         .p
         {
             font-size:18px;
             font-weight:bold;
         }
         /* enable absolute positioning */
.inner-addon { 
    position: relative; 
}

/* style icon */
.inner-addon .glyphicon {
  position: absolute;
  padding: 10px;
  pointer-events: none;
  color:#717171;
 
}

/* align icon */
.left-addon .glyphicon  { left:  0px;}
.right-addon .glyphicon { right: 0px;}

/* add padding  */
.left-addon input  { padding-left:  30px; }
.right-addon input { padding-right: 30px; }
     </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
         <div class="header">
             <div class="row">
                 <div class="col-md-4">
                     <img src="images/American-Hospital-Dubai-eds.jpg" width="150" height="80" />
                     
                 </div>
                 <div class="col-md-8">
                     

                 </div>
             </div>
            <hr />
         </div>
            <div style="margin-left:auto;margin-right:auto;margin-top:auto" id ="mydiv">

                <p style ="font-size:18px;font-weight:bold;font-family:Arial sans-serif"> UserName</p>

                <div class="inner-addon left-addon">
    <i class="glyphicon glyphicon-user"></i>
      <asp:TextBox runat="server" ID ="txtusername" PlaceHolder ="UserName" class="form-control"></asp:TextBox>
</div>
                <br />
                <p style ="font-size:18px;font-weight:bold;font-family:Arial sans-serif""> Password</p>

                <div class="inner-addon left-addon">
    <i class="glyphicon glyphicon-lock"></i>
      <asp:TextBox runat="server" ID ="txtpassword" PlaceHolder ="UserName" class="form-control" TextMode="Password"></asp:TextBox>
</div>
                <br />
                
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me"  />
                <br />
                <br />
                <asp:Button runat="server" ID ="btnlogin" Text ="LogIn"  class="btn-success" Width="100%" height="35px" OnClick="btnlogin_Click1"/>

               <asp:Label runat ="server" ID ="lblwrongpass" ForeColor ="Red" Font-Size="Medium" Visible ="false"></asp:Label>
              
            </div>
        </div>
    </form>
</body>
</html>
