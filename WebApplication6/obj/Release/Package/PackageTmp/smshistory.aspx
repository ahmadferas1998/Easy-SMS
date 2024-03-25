<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="smshistory.aspx.cs" Inherits="AmHospital.smshistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
         <meta charset="utf-8">  
  <meta name="viewport" content="width=device-width,initial-scale=1">

    <link href="styles/bootstrap-3.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="styles/bootstrap-3.4.1-dist/js/bootstrap.min.js"></script>
      <script src="scripts/jquery-1.11.3.min.js"></script>
    <script src="scripts/jquery-ui.js"></script>
  <link href="styles/jquery-ui.css" rel="stylesheet" />
    <script src="styles/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
    <script>
$(document).ready(function(){
  $("#myInput").on("keyup", function() {
    var value = $(this).val().toLowerCase();
    $("#myTable tr").filter(function() {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
  });
});
</script>

        <style type="text/css">
                .my-custom-scrollbar {
position: relative;
height: 400px;
overflow: auto;
}
                .my-custom-scrollbar2
                {
                    position: relative;
height: 200px;
overflow: auto;

                }
.table-wrapper-scroll-y {
display: block;
}
            .auto-style1 {
                left: 0px;
                top: 1px;
            }
    </style>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat ="server" id ="panel1">

        <div class="container-fluid" id ="cont_margin" style ="margin-top:50px;">
        <h3>
       SMS History 
        </h3>
        <div class="row">

            <div class="col-md-12" style = "text-align:left;">
                 <input class="form-control" id="myInput" type="text" placeholder="Search..">
              

            </div>
        </div>
            <br />
            <br />
               <div class="table-wrapper-scroll-y my-custom-scrollbar">   
        <asp:Repeater ID="cpRepeater" runat="server"
           
            >
        <HeaderTemplate>
        <table class="table table-striped table-hover">
        <tr >
       <td>Appointment Code </td>
        <td >  Mobile_No </td>
        <td >SMS_Text </td>
        <td >SMS_Type</td>
            <td >Patient_Name</td>
                    <td >Doctor_Name</td>
             <td >Clinic Name </td>
            <td>Appointment_Date</td>
            <td>Status </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
               <tbody id="myTable">
        <tr >
         
            <td>
                <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Appointment_Code") %>' ></asp:Label>
                
    
                         </td>
        
            <td>
                <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Mobile_No") %>' ></asp:Label>
                
    
                         </td>
            <td>
            <asp:label ID="txtName"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SMS_Text")%>' ></asp:label>
            </td>
         <td>
            <asp:label ID="txtContent"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SMS_Type")%>' TextMode="MultiLine"></asp:label>
            </td>

            <td>
            <asp:label ID="Label2"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Patient_Name")%>' TextMode="MultiLine"></asp:label>
            </td>

            <td>
            <asp:label ID="Label1"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Doctor_Name")%>' TextMode="MultiLine"></asp:label>
            </td>
            <td>
                
                <asp:label ID="Label3"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Name")%>' TextMode="MultiLine"></asp:label>
            </td>
                   <td>
                
                <asp:label ID="Label4"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Appointment_Date")%>' TextMode="MultiLine"></asp:label>
            </td>
                   <td>
                
                <asp:label ID="Label5"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>' TextMode="MultiLine"></asp:label>
            </td>

          
        </tr>
                   </tbody>
        </ItemTemplate>
        <FooterTemplate>
        <tr >
        <td colspan="9">
            </FooterTemplate>
        </asp:Repeater>
                   </div>
            <asp:Button runat="server"  ID ="btnOK" Class="btn btn-primary"  Text ="OK"  OnClick ="btnOK_Click"/>
    </div>
        
    </asp:Panel>
</asp:Content>
