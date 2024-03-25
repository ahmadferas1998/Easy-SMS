<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="doctors.aspx.cs" Inherits="AmHospital.doctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <meta charset="utf-8">  
  <meta name="viewport" content="width=device-width,initial-scale=1">

    <link href="styles/bootstrap-3.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="styles/bootstrap-3.4.1-dist/js/bootstrap.min.js"></script>
      <script src="scripts/jquery-1.11.3.min.js"></script>
    <script src="scripts/jquery-ui.js"></script>
  <link href="styles/jquery-ui.css" rel="stylesheet" />
    <script src="styles/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
     <style type="text/css">
         .auto-style2 {
             position: relative;
             min-height: 1px;
             float: left;
             width: 50%;
             left: 0px;
             top: -1750px;
             padding-left: 15px;
             padding-right: 15px;
         }
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

        <div class="container-fluid" id ="cont_margin" style="margin-right:60px;">
        <h3>
            Doctors 
        </h3>
        <div class="row">

            <div class="col-md-12" style = "text-align:left;">

         <asp:LinkButton runat="server" ID ="btnAddNew" text ="Add New Doctor" OnClick="btnAddNew_Click"></asp:LinkButton>

            </div>
        </div>
             <div class="table-wrapper-scroll-y my-custom-scrollbar">   
        <asp:Repeater ID="cpRepeater" runat="server"
            onitemcommand="cpRepeater_ItemCommand"
            >
        <HeaderTemplate>
        <table class="table table-striped table-hover">
        <tr  >
       
        <td > Doctor_Name </td>
        <td >Doctor_Description</td>
        <td >Clinic_Code</td>
                    <td >Edit Doctor</td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr  >
        
        
            <td>
                <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Doctor_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Doctor_Name")%>'></asp:Label>
                         </td>
            <td>
            <asp:label ID="txtName" class="form-control" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Doctor_Description")%>' ></asp:label>
            </td>
         <td>
            <asp:label ID="txtContent" class="form-control" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Code")%>' TextMode="MultiLine"></asp:label>
            </td>
         <td ><asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Doctor_ID") %>'  OnCommand="btnUpdate_Click" >Edit</asp:LinkButton>

            <asp:LinkButton Visible="false" ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Doctor_ID") %>'>Update</asp:LinkButton>
            <asp:LinkButton Visible="false" ID="lnkCancel" runat="server" CommandName="cancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Doctor_ID") %>'>Cancel</asp:LinkButton>
            

        </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        <tr  >
        <td colspan="5">
            </FooterTemplate>
        </asp:Repeater>
                 </div>
    </div>
    </asp:Panel>
    <asp:Panel runat ="server" ID ="panel2" Visible ="false">

        <div class="container" style ="margin-top:70px;">
            <h4> Edit Doctor</h4>
<div class ="row">

    <div class="col-md-6">
        <p>Doctor Name 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdoctorName" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtdoctorName" Class="form-control" MaxLength="250"></asp:TextBox>

    </div>
    <div class="col-md-6">
        <p>Doctor Description<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdoctordescription" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtdoctordescription" Class="form-control" MaxLength="250"></asp:TextBox>

    </div>
</div>
<br />

            <div class ="row">

    <div class="col-md-6">
        <p>Clinic Code</p>
        <asp:DropDownList runat="server" ID ="ddlcliniccode" Class="form-control"></asp:DropDownList>

    </div>
    <div class="col-md-6">
        <p>Doctor_Code<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDoctorcode" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtDoctorcode" Class="form-control" MaxLength="50" ></asp:TextBox>

    </div>
</div>



            <div class ="row">

    <div class="col-md-6">
        <p>Doctor Status </p>
        <asp:checkbox  runat="server" ID ="activeedit" Text ="Active"></asp:checkbox>

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
    </asp:Panel>

         <asp:Panel runat ="server" ID ="panel3" Visible ="false" >
             <div class="container" style ="margin-top:70px;">
                 <h4> Add Doctor </h4>

<div class ="row">

    <div class="col-md-6">
        <p>Doctor Name<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdoctorname2" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtdoctorname2" Class="form-control" MaxLength="250"></asp:TextBox>

    </div>
    <div class="col-md-6">
        <p>Doctor Description<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdoctordescription2" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtdoctordescription2" Class="form-control" MaxLength="250"></asp:TextBox>

    </div>
</div>
<br />

            <div class ="row">
                 <div class="col-md-6">
        <p>Clinic Code</p>
        <asp:DropDownList runat="server" ID ="ddlcliniccode1" class="form-control" ></asp:DropDownList>

    </div>
    <div class="col-md-6">
        <p>Doctor Code<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdoctorcode2" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtdoctorcode2" class="form-control" MaxLength="50"  ></asp:TextBox>

    </div>

               
     
</div>
                

                  <div class ="row">
                 <div class="col-md-6">
        <p>Doctor Status</p>
 <asp:CheckBox runat="server" ID ="activeadd"  Text ="Active" Checked="true"/>

    </div>
     

               
     
</div>
            <br />
                 <div class="row">
                     
    
                
                 </div>
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
