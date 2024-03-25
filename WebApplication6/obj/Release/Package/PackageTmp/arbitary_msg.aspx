<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="arbitary_msg.aspx.cs" Inherits="AmHospital.arbitary_msg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:scriptManager runat="server" id ="scriptManager1" AsyncPostBackTimeout ="300"></asp:scriptManager>
        

    <asp:Panel runat="server" ID ="panel1">
        <div class="container-fluid">
         <h4> Arbitary Messages</h4>
      
        <div class="grid">
            <asp:LinkButton runat ="server" ID ="lnkbutton" Text ="Send New Message" OnClick="lnkbutton_Click" ></asp:LinkButton>
            <br />
             <input class="form-control" id="myInput" type="text" placeholder="Search..">
            <br />
          <div class="table-wrapper-scroll-y my-custom-scrollbar"> 
        <asp:Repeater ID="cpRepeater" runat="server">
        <HeaderTemplate>
        <table class="table table-striped table-hover">
        <tr >
       
        <td > Mobile Number </td>
             <td > MR No </td>
        <td  > SMS Text </td>
        <td >SMS Type </td>
                    <td >Status</td>
            <td  > Description</td>
        </tr>
        </HeaderTemplate>
            
        <ItemTemplate>
            <tbody id="myTable">
        <tr >
        
        
            <td>
                <asp:Label ID="lblsmsID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SMS_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblmobnum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Mobile_No")%>'></asp:Label>
                         </td>

            <td>
            <asp:label ID="Label1"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Patient_Name")%>' ></asp:label>
            </td>
            <td>
            <asp:label ID="lblsmstext"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SMS_Text")%>' ></asp:label>
            </td>
         <td>
            <asp:label ID="lblsmstype"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SMS_Type")%>' ></asp:label>
            </td>
             <td>
            <asp:label ID="lblstatus"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>' ></asp:label>
            </td>
             <td>
            <asp:label ID="lblstatusdesc"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status_Description")%>' ></asp:label>
            </td>
       
        </tr>
                </tbody>
        </ItemTemplate>
        <FooterTemplate>
        <tr >
        <td colspan="5">
            </FooterTemplate>
        </asp:Repeater>
              </div> 
        </div>
    </div>
    </asp:Panel>
        
         <asp:Panel runat="server" ID ="panel2" Visible ="false">

<div class="container-fluid">

                   <div class="row">

            <div class="col-md-6">
                <p> Mobile Number <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  
       ControlToValidate="txtmobile_no" ErrorMessage="InValid Mobile Nmber!!"   
           ValidationExpression="[0-9]{10,12}" Font-Size="Medium" ForeColor="Red"></asp:RegularExpressionValidator> 
                </p>
                <asp:TextBox runat="server" id ="txtmobile_no" class="form-control" MaxLength="12"></asp:TextBox>

            </div>

              <div class="col-md-6">
                  
                <p> Message Text<asp:requiredfieldvalidator runat="server" errormessage="**" ControlToValidate="txtmessagetext" Font-Size="Medium" ForeColor="Red"></asp:requiredfieldvalidator> </p>

                <asp:TextBox runat="server" id ="txtmessagetext" class="form-control" MaxLength="500" TextMode="MultiLine"></asp:TextBox>

                
            </div>

            

        </div>
        <div class="row">

            <div class="col-md-6">
                <p> Recipient Name </p>
                <asp:TextBox runat="server" id ="txtrecipient" class="form-control" MaxLength="50"></asp:TextBox> 

                 

                <br />
         <asp:label runat="server" id ="labelcheck" ></asp:label>
            </div>

            <div class="col-md-6">
                <p> Patient Name </p>
                <asp:DropDownList runat="server" ID ="ddlpatient" class="form-control"></asp:DropDownList> 

                <br />
         <asp:Button runat="server" id ="btnsend"  class="btn btn-primary" text ="Send" OnClick="btnsend_Click" />
                 <asp:Button runat="server" id ="btncancel"  class="btn btn-default" text ="Cancel" OnClick="btncancel_Click" CausesValidation="False" />
            </div>
            
                  <br />
                  
                  
               
                

        </div>
</div>
         </asp:Panel>
           
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

</asp:Content>
