<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="change_pass.aspx.cs" Inherits="AmHospital.change_pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">  
  <meta name="viewport" content="width=device-width,initial-scale=1">

    <link href="styles/bootstrap-3.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="styles/bootstrap-3.4.1-dist/js/bootstrap.min.js"></script>
      <script src="scripts/jquery-1.11.3.min.js"></script>
    <script src="scripts/jquery-ui.js"></script>
  <link href="styles/jquery-ui.css" rel="stylesheet" />
    <script src="styles/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:50px;">

        <h3> Change Password  </h3> 
        <div class="row">

            <div class="col-md-6">
                <p> Current Password<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcurrentpassword" ErrorMessage="**" Font-Size="Larger" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </p>
                <asp:textbox runat="server" id ="txtcurrentpassword" class="form-control" TextMode="Password"></asp:textbox>

                 
            </div>
        </div>

        <div class="row">

            <div class="col-md-6">
                <p> New Password<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnewpassword" ErrorMessage="**" Font-Size="Larger" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
    
<asp:RegularExpressionValidator ID="YourRegularExpressionValidator" runat="server" 
                                ControlToValidate="txtnewpassword" 
                                ErrorMessage="Minimum six characters!"  
    ForeColor="Red"
                                ValidationExpression="[0-9a-zA-Z]{6,}"></asp:RegularExpressionValidator>
                </p>
                <asp:textbox runat="server" class="form-control" id ="txtnewpassword" TextMode="Password"></asp:textbox>

            </div>
        </div>

        <div class="row">

            <div class="col-md-6">
                <p> New Password Again<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnewpassagain" ErrorMessage="**" Font-Size="Larger" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtnewpassword" ControlToValidate="txtnewpassagain" ErrorMessage="Insert The Same Password" ForeColor="Red"></asp:CompareValidator>
    
<asp:RegularExpressionValidator ID="YourRegularExpressionValidator0" runat="server" 
                                ControlToValidate="txtnewpassagain" 
                                ErrorMessage="Minimum six characters!"  
    ForeColor="Red"
                                ValidationExpression="[0-9a-zA-Z]{6,}"></asp:RegularExpressionValidator>
                </p>
                <asp:textbox runat="server" class="form-control" id ="txtnewpassagain" TextMode="Password"></asp:textbox>

            </div>
        </div>
        <br />
         <asp:Button ID="btnsave" runat="server" Text="Save" class="btn-primary" OnClick="btnsave_Click"/>
        <br />
        <asp:Label runat="server" ID ="lblincorrectpass" ForeColor="Red"></asp:Label>
    </div>

</asp:Content>
