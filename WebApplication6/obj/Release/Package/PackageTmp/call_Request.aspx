<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="call_Request.aspx.cs" Inherits="AmHospital.call_Request" %>

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
     
    <style type="text/css">
        .my-custom-scrollbarscrollbar {
position: relative;
height: 200px;
overflow: auto;
}
.table-wrapper-scroll-y {
display: block;
}
    </style>

    <style type="text/css">
                .my-custom-scrollbar {
position: relative;
height: 400px;
overflow: auto;
}
         
.table-wrapper-scroll-y {
display: block;
}
            </style>

 
    
   
    <script type ="text/javascript">

        

$(function () {  
 
      $('#txtdate3').datepicker({  
        dateFormat: 'dd/mm/yy',  
        changeMonth: true,  
        changeYear: true,  
         yearRange: '1950:2100'  
        
      }); 
        })

              $(function() {
    
    $("#txtdate3").on("change",function(){
        var selected = $(this).val();
        document.getElementById("date3").value = selected;
        
        
    });
});

 



       


        	/*
		Gets the selected value for the radio or checkbox list control
		*/
	 
	</script>
 
</head>
<body>
    <form id="form1" runat="server">
         <asp:HiddenField runat ="server" ID ="date3" />
        <asp:panel runat="server" ID ="panel1a" Visible="false">

                <div class="div">
             <nav class="navbar navbar-inverse" style="">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">American Hospital</a>
    </div>
    <ul class="nav navbar-nav">
      <li class="active"><a href="default.aspx">Home</a></li>
      <li ><a href="Clinics.aspx">Clinics</a></li>
         <li class="active"><a href="doctors.aspx">Doctors</a></li>
         <li class="active"><a href="test.aspx">Templates</a></li>
         <li class="active"><a href="users.aspx">Users</a></li>
       <li ><a href="arbitary_msg.aspx">Arbitary Messages</a></li>
         <li ><a href="call_Request.aspx">Call Request</a></li>
    </ul>
       <ul class="nav navbar-nav navbar-right">
      <li><a href="change_pass.aspx"><span class="glyphicon glyphicon-user"></span> Change Password </a></li>
      <li><a href="login_test.aspx"><span class="glyphicon glyphicon-log-in">LogOut</span></a></li>
    </ul>
  </div>
</nav>
       

             
         
        </div>
            </asp:panel>


           <asp:panel runat="server" ID ="panel1b">

                <div class="div">
             <nav class="navbar navbar-inverse" style="">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">American Hospital</a>
    </div>
    <ul class="nav navbar-nav">
      <li class="active"><a href="default.aspx">Home</a></li>
      
       <li ><a href="arbitary_msg.aspx">Arbitary Messages</a></li>
         <li ><a href="call_Request.aspx">Call Request</a></li>
    </ul>
       <ul class="nav navbar-nav navbar-right">
      <li><a href="change_pass.aspx"><span class="glyphicon glyphicon-user"></span> Change Password </a></li>
      <li><a href="login_test.aspx"><span class="glyphicon glyphicon-log-in">LogOut</span></a></li>
    </ul>
  </div>
</nav>
       

             
         
        </div>
            </asp:panel>
            <div class="container-fluid">
         <h4> Call Request</h4>
            <div class="row" style="margin-top:10px">

                      <div class="col-md-6">
                          <p>Mobile Number </p>
                          <asp:TextBox runat="server" ID ="txtmobnumber" class="form-control"></asp:TextBox>

                      </div>

                      <div class="col-md-6">
                          <p>Date: </p>
                          <asp:TextBox runat="server" ID ="txtdate3" class="form-control"></asp:TextBox>

                      </div>
                      
              
                  </div>
                <br />
                <div class="row">

                    <div class="col-md-6">
                         <asp:Button runat="server" ID ="btn_filter_showall" Text ="Search" class="btn btn-default" OnClick="btn_filter_showall_Click" />
                    </div>
                </div>
         
        <div class="grid">

             <div class="table-wrapper-scroll-y my-custom-scrollbar">             
        <asp:Repeater ID="cpRepeater" runat="server">
        <HeaderTemplate>
        <table class="table table-striped table-hover">
        <tr >
       
        
        <td > App No </td>
        <td >App Date </td>
                    <td >MR Number </td>
                 <td  > Patient  </td>
             <td  > Mobile No</td>
               <td  > Clinic  </td>
            <td  > Doctor</td>
             <td  > Response</td>
        
              
            <td  > Comment</td>
             <td  > Confirm</td>
            <td  > Cancel</td>
             <td  > Save </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr >
        
        
            <td>
                <asp:Label ID="lblapp_no" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Appointment_No") %>' ></asp:Label>
            
                         </td>
            <td>
            <asp:label ID="lblapp_date"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Appointment_Date")%>' ></asp:label>
            </td>
         <td>
            <asp:label ID="lblapp_time"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Patient_Code")%>' ></asp:label>
            </td>
             <td>
            <asp:label ID="lbldoc_name"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Patient_Name")%>' ></asp:label>
            </td>
             <td>
            <asp:label ID="lblclinic_code"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>' ></asp:label>
            </td>
            
            

             <td>
            <asp:label ID="lblmob_number"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Code")%>' ></asp:label>
            </td>
             <td>
            <asp:label ID="lblresponse"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Doctor_Name")%>' ></asp:label>
            </td>
               <td>
            <asp:label ID="lblcoment"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Response")%>' ></asp:label>
            </td>
                 <td>
            <asp:TextBox ID="textboxcomment"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Comments")%>' ></asp:TextBox>
            </td>
              
                <td>
                   
                    <asp:CheckBox runat="server" ID ="checkboxconfirm" />
                </td>
            <td>
                    <asp:CheckBox runat="server" ID ="checkboxcancel" />
                </td>
        
             <td > 
                 <asp:Button Text="Save" runat="server" OnClick="GetValue" class ="btn btn-primary" />
        </td>
          
         
        </tr>
        
        </ItemTemplate>
        
        <FooterTemplate>
        <tr >
        <td colspan="12">
            </FooterTemplate>
        </asp:Repeater>
           </div>
                     
                        <asp:Label runat="server" ID ="labelcheck"></asp:Label>
        </div>
                <br />
                <br />
                
                       
    </div>
        
    </form>
</body>

</html>
