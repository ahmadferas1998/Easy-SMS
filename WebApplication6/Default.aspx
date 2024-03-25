<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AmHospital.default2" %>


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
     


 
    
   
    <script type ="text/javascript">

        

$(function () {  
    $('#txtDatePicker').datepicker({  
        dateFormat: 'dd/mm/yy',  
        changeMonth: true,  
        changeYear: true,  
         selected:Date.now,
        yearRange: '1950:2100'  
    });  
     $('#txtDatePicker2').datepicker({  
        dateFormat: 'dd/mm/yy',  
        changeMonth: true,  
         changeYear: true,  
        selected:Date.now + 1,
         yearRange: '1950:2100'  
        
      });  
        })

        $(function() {
    
    $("#txtDatePicker").on("change",function(){
        var selected = $(this).val();
       document.getElementById("datefrom").value= selected;
        
    });
});

         $(function() {
    
    $("#txtDatePicker2").on("change",function(){
        var selected = $(this).val();
        document.getElementById("dateto").value = selected;
       
        
    });
        });

       


        	/*
		Gets the selected value for the radio or checkbox list control
		*/
	 
	</script>

    
    <style>
        .my-custom-scrollbar {
position: relative;
height: 200px;
overflow: auto;
}
                .my-custom-scrollbar3 {
position: relative;
height: 500px;
overflow: auto;
}
.table-wrapper-scroll-y {
display: block;
}
#dtVerticalScrollExample {
  border-collapse: collapse;
  border-spacing: 0;
  width: 100%;
  border: 1px solid #ddd;
}

th, td {
  text-align: left;
  padding: 8px;
}

tr:nth-child(even){background-color: #f2f2f2}
.dtHorizontalVerticalExampleWrapper {
max-width: 400px;
margin: 0 auto;
}
#dtHorizontalVerticalExample th, td {
white-space: nowrap;
}
table.dataTable thead .sorting:after,
table.dataTable thead .sorting:before,
table.dataTable thead .sorting_asc:after,
table.dataTable thead .sorting_asc:before,
table.dataTable thead .sorting_asc_disabled:after,
table.dataTable thead .sorting_asc_disabled:before,
table.dataTable thead .sorting_desc:after,
table.dataTable thead .sorting_desc:before,
table.dataTable thead .sorting_desc_disabled:after,
table.dataTable thead .sorting_desc_disabled:before {
bottom: .5em;
}    </style>
 
 
     

</head>
<body>

    <form id="form1" runat="server">
        
<asp:ScriptManager runat="server" ID ="scriptmanager1" AsyncPostBackTimeout="400"></asp:ScriptManager>
        <asp:HiddenField runat ="server" ID ="datefrom" />
             <asp:HiddenField runat ="server" ID ="dateto" />
        <asp:HiddenField runat ="server" ID ="date3" />

       <asp:Panel runat="server" ID ="panel1">
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
  
        <!--Bootstrap Table using .table-striped class-->  
            
          

       <div class="slider">
           <h4> Appoitments SMS</h4>
              </div>
           
           <div class="container-fluid">
               <br />
               <h4> Clinics </h4>
               <input class="form-control" id="myInput" type="text" placeholder="Search Clinics" width="150">
               <br />
              
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
    <ContentTemplate>
              <asp:CheckBox runat="server" ID ="checkboxall"  Text ="Select All" AutoPostBack="true" OnCheckedChanged="checkboxall_CheckedChanged" EnableViewState="true"/>
               &nbsp; &nbsp; 
                <br />

                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                        <asp:Repeater ID="repeater_clinics_profile" runat="server">
                            <HeaderTemplate>
                                <table class="table table-bordered table-striped mb-0">
                                    <tr>
                                        <td>Select</td>
                                        <td>Clinic Name</td>
                                        <td>Clinic Code</td>
                                    </tr>
                            
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody id="myTable">
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="checkboxselectttt1" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblclinicid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_ID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblclinic_code1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Code")%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblclinic_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Name")%>'></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
               </div>
               <br />
        </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="checkboxall" EventName="CheckedChanged" />
                       

 
</Triggers>
        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
    <ContentTemplate>

                <asp:LinkButton  ID="linkbtn" runat="server"  OnClick="btncheck_Click" Text="Check Related Doctors" EnableViewState="true"  ></asp:LinkButton>
                 <h4> Doctors </h4>

                    
              
              
               <asp:CheckBox runat="server" ID ="checboxalldocs"  Text ="Select All" AutoPostBack="true" OnCheckedChanged="checboxalldocs_CheckedChanged" EnableViewState="true" />
                  <br />
               <div class="table-wrapper-scroll-y my-custom-scrollbar">   
        <asp:Repeater ID="repeaterdoctor" runat="server"
            >
             <HeaderTemplate>
             <table class="table table-bordered table-striped mb-0">
       
       
        <tr >
         <td >  Select</td>
        <td >  Doctor Name</td>
        <td >Doctor Code</td>
        
        </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
              <tbody id="myTable2">
        <tr >
        
              <td>
              <asp:CheckBox runat ="server" ID ="checkboxselectttt1" />
                         </td>
            <td>
                <asp:Label ID="lbldoctorid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Doctor_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lbldocname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Doctor_Name")%>'></asp:Label>
                         </td>
            <td>
            <asp:label ID="lbldoccode"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Doctor_Code")%>' ></asp:label>
            </td>
      

      
 
     
       
        </tr>
              </tbody>
        </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
       
        </asp:Repeater>
                 
                        
                  </div>
        </ContentTemplate>
<Triggers>
            <asp:AsyncPostBackTrigger ControlID="linkbtn" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="checboxalldocs" EventName="CheckedChanged" />

 
</Triggers>

        </asp:UpdatePanel>
                 <div class="row" style="margin-top:10px">

                       <div class="col-md-3">
                          <h5> Filtering Date and MR NO  </h5>
                       </div>
                       
                       <div class="col-md-3">
                 <asp:TextBox ID="txtDatePicker" runat="server"  placeholder="From Date" Class="form-control"></asp:TextBox>
                          
                       </div>

                        
                       <div class="col-md-3">
                      
                           <asp:TextBox ID="txtDatePicker2" runat="server"   placeholder="To DATE " Class="form-control"></asp:TextBox>
                       </div>
                          
                      <div class="col-md-3">
                     
                           <asp:TextBox runat="server" ID ="txtmrnomber"  placeholder="MR Number" Class="form-control" ></asp:TextBox>
                       </div>
                   </div>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Always">
    <ContentTemplate>

               <div class="row" style="margin-top:10px">

                       <div class="col-md-3">
                          <h5>  App Status  </h5>
                       </div>
                       
                       <div class="col-md-3">
                 <asp:DropDownList runat="server" ID ="ddlapp_status" Class="form-control"></asp:DropDownList>
                       </div>

                        
                       <div class="col-md-3">
                      
                        <asp:DropDownList runat="server" ID ="ddlaptype" Class="form-control"></asp:DropDownList>
                       </div>
                          
                       <div class="col-md-3">
                           <asp:TextBox runat="server" ID ="txtmobilenumber" Class="form-control" PlaceHolder="Nobile No" ></asp:TextBox>

                      
                       
                       </div>
                   </div>
        <br />
        
        <br />
         <asp:Button runat ="server" ID ="btnsearch" class="btn btn-primary" Text ="Search"  OnClick="btnsearch_Click" EnableViewState="true"  />
        <br></br>
        <div class="slider">
            <asp:CheckBox runat="server" id ="checkbox_onlyduplicate" text ="Only Double Booking" OnCheckedChanged="checkbox_onlyduplicate_CheckedChanged" AutoPostBack="true" EnableViewState ="true"></asp:CheckBox>
        </div>

               <div class="row">
                   <div class="col-md-6">
                       
                       <br />
                       <asp:CheckBox runat="server" id ="checkboxallappointments" text ="Select All" OnCheckedChanged="checkboxallappointments_CheckedChanged" AutoPostBack="true" EnableViewState ="true"></asp:CheckBox>
                       <br />

                   </div>
               </div>
              
                       <div style="overflow-x:auto;" class="table-wrapper-scroll-y my-custom-scrollbar3" >
                       <asp:Repeater ID="repeater_appointment" runat="server" >
             <HeaderTemplate>
             <table id="dtVerticalScrollExample" class="table table-striped table-bordered table-sm " cellspacing="0"
  width="100%" >
       
       
        <tr >
         <td >  Select</td>
        <td > Appointment No </td>
              <td > SMS History </td>
              <td > Show All </td>
        <td >Appointment Date</td>
               <td > Appontment Time   </td>
            
        <td > EN No</td>
               <td > Patient  </td>
        <td > Appointment_Status</td>
             <td > SMS Type </td>
               <td > Appointment Type </td>
        <td >Mobile No</td>
               <td >Doctor_Name </td>
                
            <td>Status</td>
              <td>Response</td>
              <td>Reponse Status </td>
             <td>Patient Code </td>
        
        </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
              <tbody id="myTable3">
        <tr id="Tr1" runat="server">
        
              <td>
              <asp:CheckBox runat ="server" ID ="checkboxselectttt10" />
                         </td>
          
            <td>
                <asp:Label ID="lblapno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Appointment_No") %>'  ></asp:Label>
            
                         </td>
             <td>
                            <asp:LinkButton ID="LinkButton2" runat="server" Text ="SMS History"  CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Appointment_No") %>'  OnCommand="btnUpdate_Click2"></asp:LinkButton>

            </td>
              <td>
                <asp:LinkButton ID="Label12" runat="server" Text =""  CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Appointment_No") %>'  OnCommand="btnUpdate_Click"></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="lblapdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Appointment_Date")%>'></asp:Label>
            </td>
            <td>
            <asp:label ID="lblapptime"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Appointment_Time")%>' ></asp:label>

            </td>
                 <td>
            <asp:label ID="Label6"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ENNo")%>' ></asp:label>

            </td>
                <td>
            <asp:label ID="Label5"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Patient_Name")%>' ></asp:label>

            </td>
             <td>
            <asp:label ID="lblappstatus"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Appointment_Status")%>' ></asp:label>

            </td>
            <td>
                <asp:label ID="Label14"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SMSType")%>' ></asp:label>
            </td>
            
            
      
               <td>
            <asp:label ID="Label3"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Appointment_Type")%>' ></asp:label>

            </td>
            
                  <td>
            <asp:label ID="Label4"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MobileNo")%>' ></asp:label>

            </td>
      
      <td>
            <asp:label ID="Label7"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Doctor_Name")%>' ></asp:label>

            </td>
           
       
            <td>
            <asp:label ID="Label9"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>' ></asp:label>

            </td>
                    <td>
            <asp:label ID="Label11"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Response")%>' ></asp:label>

            </td>
                <td>
            <asp:label ID="Label10"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Reponse_Status")%>' ></asp:label>

            </td>
              
            
                   <td>
            <asp:label ID="Label15"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Patient_Code")%>' ></asp:label>

            </td>
       
       
        </tr>
              </tbody>
        </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
       
        </asp:Repeater>
                           </div>
                </ContentTemplate>
                            <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="btnsearch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="checkbox_onlyduplicate" EventName="CheckedChanged" />
                                 <asp:AsyncPostBackTrigger ControlID="checkboxallappointments" EventName="CheckedChanged" />
                            </Triggers>
                  </asp:UpdatePanel>

           </div>
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
    <ContentTemplate>
     <div class="slider">
                <p> Notification Type </p>  

              </div>
             
              <div class="row">
      
                  <div class ="col-md-3">
                     
                      <asp:RadioButton ID="RadioButtonapp_not" runat="server" GroupName="sms_type" Text ="Appointment Notification" OnCheckedChanged="RadioButtonapp_not_CheckedChanged" Checked="true" AutoPostBack="true" EnableViewState="true" class="form-check-input" />
                  </div>
                   <div class ="col-md-3">  <asp:RadioButton ID="RadioButtonapp_reminder" runat="server" GroupName="sms_type" Text ="Reminder" OnCheckedChanged="RadioButtonapp_reminder_CheckedChanged" AutoPostBack="true" EnableViewState="true" class="form-check-input" /></div>
                   <div class ="col-md-3"> <asp:RadioButton ID="RadioButton_notify_cancell" runat="server" GroupName="sms_type"  Text ="Notify Cancellation" OnCheckedChanged="RadioButton_notify_cancell_CheckedChanged" AutoPostBack="true" EnableViewState="true" class="form-check-input" /></div>
                   <div class ="col-md-3"> <asp:RadioButton ID="RadioButtonconfirm_cancel" runat="server" GroupName="sms_type" Text ="Confirm  Cancel" OnCheckedChanged="RadioButtonconfirm_cancel_CheckedChanged"  AutoPostBack="true" EnableViewState="true"  /></div>
   

                      

                         
                       

              </div>


                  <div class="slider">
                <p> Template  </p>  

              </div>

              <br />


              <div class="row">

                  <div class ="col-md-4">

                      <p> SMS Template</p>
                  </div>
                   <div class ="col-md-8">

                       <asp:DropDownList runat ="server" ID ="ddltemplates" class="form-control" EnableViewState="true" OnSelectedIndexChanged="ddltemplates_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  </div>
              </div>

              <br />
             

              
              <div class="row">

                  <div class ="col-md-4">

                      <p> SMS Text</p>
                  </div>
                   <div class ="col-md-8">
                       <asp:TextBox runat ="server" ID ="txttempplate" TextMode ="MultiLine" class="form-control" Height="120px"></asp:TextBox>

                  </div>
              </div>

                            <div class="row" >

                  <div class ="col-md-4">

                      <p>   <asp:Button runat ="server" ID ="btnpreview" class="btn btn-primary" Text ="To Preview Click Here" OnClick="btnpreview_Click"  /> </p>
                  </div>
                   <div class ="col-md-8">

                                 <asp:Panel ID="panelpreview" runat="server" ScrollBars="Vertical" Height="110px">
                               <asp:TextBox runat ="server" ID ="txtpreview" TextMode ="MultiLine" class="form-control" Height="120px"></asp:TextBox>

                                     </asp:Panel>
                  </div>

                               
              </div>

      

      
      
 
              <br />
          
        </ContentTemplate>

                        <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="RadioButtonapp_not" EventName="CheckedChanged" />
                  
                    <asp:AsyncPostBackTrigger ControlID="RadioButtonapp_reminder" EventName="CheckedChanged" />

                             <asp:AsyncPostBackTrigger ControlID="RadioButton_notify_cancell" EventName="CheckedChanged" />
                  
                    <asp:AsyncPostBackTrigger ControlID="RadioButtonconfirm_cancel" EventName="CheckedChanged" />
              </Triggers>
                      </asp:UpdatePanel>
              <asp:Button ID="btnSend" runat="server" class="btn btn-primary" OnClick="btnSend_Click" Text="Send" />
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <table > 
            <tr>
                <td>
          
                  
          
                </td>
            </tr>
        </table> 
               
              <asp:CheckBox runat ="server" ID ="checbox_grid" Text ="Select All" OnCheckedChanged="checbox_grid_CheckedChanged" AutoPostBack="true" Visible="false"  />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  Visible="false"   
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"   Width ="100%" 
            CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowDataBound ="GridView1_RowDataBound" >  
            <AlternatingRowStyle BackColor="White" />  
            <Columns>  

                <asp:TemplateField HeaderText="Select">  
                    <EditItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                    </ItemTemplate>  
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Appointment History" HeaderStyle-Width="120px">
                        <ItemTemplate>
                          
      <asp:LinkButton   CommandArgument='<%#Eval("Appointment_No")%>' OnCommand="show_all" ToolTip="Edit" Width="20px" Height="20px" runat="server" Text="App History" style ="color:black;" />
   
 
                        </ItemTemplate>

                    </asp:TemplateField>
                <asp:TemplateField HeaderText="App No">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Appointment_No") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Appointment_No") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  


                <asp:TemplateField HeaderText="Multiple Appointment" HeaderStyle-Width="120px">
                        <ItemTemplate>
                          
      <asp:LinkButton   CommandArgument='<%#Eval("Appointment_No")%>' OnCommand="show_all" ToolTip="Edit" Width="20px" Height="20px" runat="server"  style ="color:black;" ID ="linkbutton1"/>
   
 
                        </ItemTemplate>

                    </asp:TemplateField>
                <asp:TemplateField HeaderText="App Date">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Appointment_Date") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Appointment_Date") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="EN No">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ENNo") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("ENNo") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                

                <asp:TemplateField HeaderText="Patient Name">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Patient_Name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("Patient_Name") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
                  

                <asp:TemplateField HeaderText="Mobile No">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("MobileNo") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="lblmobnumber" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Doctor">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Doctor_Name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Labe15" runat="server" Text='<%# Bind("Doctor_Name") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>

                
                <asp:TemplateField HeaderText="App Status">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Appointment_Status") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label20" runat="server" Text='<%# Bind("Appointment_Status") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>

                

                            <asp:TemplateField HeaderText="SMS Type ">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("SMSType") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label22" runat="server" Text='<%# Bind("SMSType") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SMS Status ">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label23" runat="server" Text='<%# Bind("Status") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>

                  

                <asp:TemplateField HeaderText="Response Status ">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Reponse_Status") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label25" runat="server" Text='<%# Bind("Reponse_Status") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Respons">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Response") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label26" runat="server" Text='<%# Bind("Response") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
                
                
                <asp:TemplateField HeaderText="patient_code" >  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txtpatient_code" runat="server" Text='<%# Bind("Patient_Code") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="lblpatient_code" runat="server" Text='<%# Bind("Patient_Code") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
            </Columns>  
            <FooterStyle BackColor="#CCCC99" />  
            <HeaderStyle BackColor="#00B140" Font-Bold="True" ForeColor="White" />  
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />  
            <RowStyle BackColor="#F7F7DE" />  
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />  
            <SortedAscendingCellStyle BackColor="#FBFBF2" />  
            <SortedAscendingHeaderStyle BackColor="#848384" />  
            <SortedDescendingCellStyle BackColor="#EAEAD3" />  
            <SortedDescendingHeaderStyle BackColor="#575357" />  
        </asp:GridView>  
        <br />
        <br />

        </ContentTemplate>
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="checbox_grid" EventName="CheckedChanged" />
                  
                    <asp:AsyncPostBackTrigger ControlID="checkbox_onlyduplicate" EventName="CheckedChanged" />
              </Triggers>
              </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanelCheckBoxes" runat="server" UpdateMode="Always">
    <ContentTemplate>
        

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="RadioButtonapp_reminder" EventName="CheckedChanged" />
                       
<asp:AsyncPostBackTrigger ControlID="RadioButton_notify_cancell" EventName="CheckedChanged" />
                           <asp:AsyncPostBackTrigger ControlID="RadioButtonapp_not" EventName="CheckedChanged" />
<asp:AsyncPostBackTrigger ControlID="RadioButtonconfirm_cancel" EventName="CheckedChanged" />
          
            <asp:AsyncPostBackTrigger ControlID="ddltemplates" EventName="SelectedIndexChanged" />
</Triggers>
      
        </asp:UpdatePanel>
              <div class="row" style="margin-top:30px;" >

                 <div class="col-md-offset-4 col-md-8">

                     <br />
                     <br />
                     <asp:Label runat="server" ID ="labelifsent" ></asp:Label>
                 </div>



              </div>
    </div>
       </asp:Panel>
        
    </form>
</body>
        <script>
$(document).ready(function(){
  $("#myInput").on("keyup", function() {
    var value = $(this).val().toLowerCase();
    $("#myTable tr").filter(function() {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
    });


     $("#myInput2").on("keyup", function() {
    var value = $(this).val().toLowerCase();
    $("#myTable2 tr").filter(function() {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
    });
     $("#myInput3").on("keyup", function() {
    var value = $(this).val().toLowerCase();
    $("#myTable3 tr").filter(function() {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
    });

            });

                    $(document).ready(function () {
$('#dtVerticalScrollExample').DataTable({
"scrollY": "200px",
"scrollCollapse": true,
});
$('.dataTables_length').addClass('bs-select');
});
</script>
 
</html>
