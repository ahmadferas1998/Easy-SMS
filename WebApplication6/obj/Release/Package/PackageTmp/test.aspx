<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="AmHospital.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="utf-8">  
  <meta name="viewport" content="width=device-width,initial-scale=1">

     <link href="styles/bootstrap-3.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="styles/bootstrap-3.4.1-dist/js/bootstrap.min.js"></script>
      <script src="scripts/jquery-1.11.3.min.js"></script>
    <script src="scripts/jquery-ui.js"></script>
  <link href="styles/jquery-ui.css" rel="stylesheet" />
 <script type="text/javascript">
$(document).ready(function(){
    $('#show').click(function() {
      $('.menu').toggle("slide");
    });
     $('#show2').click(function() {
      $('.menu2').toggle("slide");
    });
});
</script>
    <style >

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
            position: relative;
            min-height: 1px;
            float: left;
            width: 50%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
            </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <asp:Panel runat ="server" id ="panel1">

        <div class="container-fluid" style ="margin-top:40px;">
        <h3>
            Templates 
        </h3>
        <div class="row">

            <div class="col-md-12" style = "text-align:left;">

         <asp:LinkButton runat="server" ID ="btnAddNew" text ="Add New Template" OnClick="btnAddNew_Click"></asp:LinkButton>

            </div>
        </div>
            <div class="table-wrapper-scroll-y my-custom-scrollbar">
        <asp:Repeater ID="cpRepeater" runat="server"
            onitemcommand="cpRepeater_ItemCommand"
            >
        <HeaderTemplate>
        <table class="table table-bordered table-striped mb-0">
        <tr >
       
        <td >Template Name</td>
        <td >Template Description</td>
        <td >Template Content</td>
                    <td >Edit/Delete</td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr >
        
        
            <td>
                <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Template_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Template_Name")%>'></asp:Label>
                         </td>
            <td>
            <asp:TextBox ID="txtName" class="form-control" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Template_Description")%>' ></asp:TextBox>
            </td>
         <td>
            <asp:TextBox ID="txtContent" class="form-control" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Template_Content")%>' TextMode="MultiLine"></asp:TextBox>
            </td>
         <td ><asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Template_ID") %>'  OnCommand="btnUpdate_Click" >Edit</asp:LinkButton>

            <asp:LinkButton Visible="false" ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Template_ID") %>'>Update</asp:LinkButton>
            <asp:LinkButton Visible="false" ID="lnkCancel" runat="server" CommandName="cancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Template_ID") %>'>Cancel</asp:LinkButton>
            

        </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        <tr >
        <td colspan="5">
            </FooterTemplate>
        </asp:Repeater>
                </div>
    </div>
    </asp:Panel>
    <asp:Panel runat ="server" ID ="panel2" Visible ="false" style="margin-top:70px;">

        <div class="container-fluid">
             <h4> Edit Template </h4>
<div class ="row">
    
    <div class="col-md-6">
        <p>Template Name<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttemplateName" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txttemplateName" Class="form-control" MaxLength ="50"></asp:TextBox>

    </div>
    <div class="col-md-6">
        <p>Template Description</p>
        <asp:TextBox runat="server" ID ="txttemplatedesc" Class="form-control"  MaxLength ="50"></asp:TextBox>

    </div>
</div>
<br />

            <div class ="row">

    <div class="col-md-6">
        <p>Template Code<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttemplateCode" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txttemplateCode" Class="form-control"  MaxLength ="50"></asp:TextBox>

    </div>
    <div class="col-md-6">
           <span>Template Content <span  id="show2" style="font-weight:bold;color:red;cursor: -webkit-grab; cursor: grab;"> Please Note </span> <div class="menu2" style="display: none;"> Please Use {*patient_name} ,{*Doctor_Name} ,{*Appointment_Date} and {*Appointment_Time} as Keywords </div>
        <asp:TextBox runat="server" ID ="txttemplatecontent" Class="form-control" TextMode ="MultiLine"  MaxLength ="500" ></asp:TextBox>

    </div>
</div>
            <br />
<asp:Button runat="server" ID ="btnsave" text ="Save" Class="btn-primary" Width="120px" OnClick="btnsave_Click"/>
             <asp:Button runat="server" ID ="btncancel" text ="Cancel" Class="btn-primary" Width="120px" OnClick="btncancel_Click" CausesValidation="False"/>
            <div class ="row">
 
                <br />

                   &nbsp;&nbsp;&nbsp;

                   <asp:Label runat ="server" id ="lblcheck"></asp:Label>
             
</div>
            
        </div>
        </span>
    </asp:Panel>

         <asp:Panel runat ="server" ID ="panel3" Visible ="false"  style="margin-top:70px;">

             <div class="container-fluid">
                 <h4>Add Template </h4> 
<div class ="row">

    <div class="col-md-6">
        <p>Template Name<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttemplatename1" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txttemplatename1" Class="form-control"  MaxLength ="50"></asp:TextBox>

    </div>
    <div class="col-md-6">
        <p>Template Description</p>
        <asp:TextBox runat="server" ID ="txttemplatedescription1" Class="form-control"  MaxLength ="50"></asp:TextBox>

    </div>
</div>
<br />

            <div class ="row">

    <div class="auto-style1">
        <p>Template Code<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txttemplatecode1" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txttemplatecode1" Class="form-control"  MaxLength ="50"></asp:TextBox>

    </div>
    <div class="col-md-6">
        <span>Template Content <span  id="show" style="font-weight:bold;color:red;cursor: -webkit-grab; cursor: grab;"> Please Note </span> <div class="menu" style="display: none;"> Please Use {*patient_name} ,{*Doctor_Name} ,{*Appointment_Date} and {*Appointment_Time} as Keywords </div>
        <asp:TextBox runat="server" ID ="txttemplatecontent1" Class="form-control" TextMode ="MultiLine"  MaxLength ="500"></asp:TextBox>

    </div>
</div>
            <br />
<asp:Button runat="server" ID ="btnAddsave" text ="Save" Class="btn-primary" Width="120px" OnClick="btnAddsave_Click" />
             <asp:Button runat="server" ID ="btnCancelsave" text ="Cancel" Class="btn-primary" Width="120px" OnClick="btnCancelsave_Click" CausesValidation="False" />
            <div class ="row">
 
                <br />

                   &nbsp;&nbsp;&nbsp;

                   <asp:Label runat ="server" id ="Label1"></asp:Label>
             
</div>
            
        </div>

         </asp:Panel>
    

</asp:Content>
