<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Clinics.aspx.cs" Inherits="AmHospital.Clinics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


 <meta charset="utf-8">  
  <meta name="viewport" content="width=device-width,initial-scale=1">
        <link href="styles/bootstrap-3.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="styles/bootstrap-3.4.1-dist/js/bootstrap.min.js"></script>
   
      <script src="scripts/jquery-1.11.3.min.js"></script>
    <script src="scripts/jquery-ui.js"></script>
  <link href="styles/jquery-ui.css" rel="stylesheet" />
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

        <div class="container-fluid" >
        <h3>
            Clinics 
        </h3>
        <div class="row">

            <div class="col-md-12" style = "text-align:left;">

         <asp:LinkButton runat="server" ID ="btnAddNew" text ="Add New Clinic" OnClick="btnAddNew_Click"></asp:LinkButton>

            </div>
        </div>
               <div class="table-wrapper-scroll-y my-custom-scrollbar">   
        <asp:Repeater ID="cpRepeater" runat="server"
           
            >
        <HeaderTemplate>
        <table class="table table-striped table-hover">
        <tr  >
       
        <td > Clinic Name </td>
        <td > Clinic Description</td>
        <td >Clinic Code</td>
                    <td >Edit Clinic</td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr  >
        
        
            <td>
                <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Name")%>'></asp:Label>
                         </td>
            <td>
            <asp:label ID="txtName"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Description")%>' ></asp:label>
            </td>
         <td>
            <asp:label ID="txtContent"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Code")%>' TextMode="MultiLine"></asp:label>
            </td>
         <td ><asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Clinic_ID") %>'  OnCommand="btnUpdate_Click" >Edit</asp:LinkButton>

            <asp:LinkButton Visible="false" ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Clinic_ID") %>'>Update</asp:LinkButton>
            <asp:LinkButton Visible="false" ID="lnkCancel" runat="server" CommandName="cancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Clinic_ID") %>'>Cancel</asp:LinkButton>
            

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
    <asp:Panel runat ="server" ID ="panel2" Visible ="false">

        <div class="container" style ="margin-top:70px;">
            <h4> Edit Clinic </h4>
<div class ="row">

    <div class="col-md-6">
        <p>Clinic Name 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtclinicName" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtclinicName" Class="form-control" MaxLength="250"></asp:TextBox>

    </div>
    <div class="col-md-6">
        <p>Clinic Description<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtclinicdescription" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtclinicdescription" Class="form-control" MaxLength="250"></asp:TextBox>

    </div>
</div>
<br />

            <div class ="row">

    <div class="col-md-6">
        <p>Clinic Code<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcliniccode" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtcliniccode" Class="form-control" MaxLength="50"></asp:TextBox>

    </div>

                
    <div class="col-md-6">
        <p> Clinic Status  </p>
            <asp:CheckBox runat="server" id ="Activeedit" Text ="Active"/>
      
     

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
                 <h4> Add New Clinic</h4>

<div class ="row">

    <div class="col-md-6">
        <p>Clinic Name<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtclinicname2" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtclinicname2" Class="form-control" MaxLength="250"></asp:TextBox>

    </div>
    <div class="col-md-6">
        <p>Clinic Description<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtclinicdescription2" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtclinicdescription2" Class="form-control" MaxLength="250"></asp:TextBox>

    </div>
</div>
<br />

            <div class ="row">

    <div class="col-md-6">
        <p>Clinic Code<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtcliniccode2" ErrorMessage="**" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:TextBox runat="server" ID ="txtcliniccode2" class="form-control" MaxLength="50"  ></asp:TextBox>

    </div>

                <div class="col-md-6">
        <p> Clinic Status  </p>
            <asp:CheckBox ID ="activeAdd" text ="Active" runat="server" Checked ="true"/>
         
         

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
