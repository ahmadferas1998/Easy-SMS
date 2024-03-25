<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="AmHospital.users" %>
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
            </style>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager runat="server" ID="scriptmanager1"></asp:ScriptManager>
        
    <asp:Panel runat ="server" id ="panel1">

        <div class="container-fluid" id ="cont_margin" style ="margin-top:50px;">
        <h3>
           Users 
        </h3>
        <div class="row">

            <div class="col-md-12" style = "text-align:left;">
                 <input class="form-control" id="myInput" type="text" placeholder="Search..">
                <br />
         <asp:Button runat="server" ID ="btnAddNew" text ="Add New User" OnClick="btnAddNew_Click" Class="btn btn-default" />
                <asp:Button runat ="server" ID ="btn_userprofile"  Text ="User Profile" class="btn btn-default" OnClick="btn_userprofile_Click"/>


        
       
                 &nbsp;<asp:Button ID="btn_userprofile0" runat="server" class="btn btn-default" OnClick="btn_userprofile0_Click" Text="User Group" />


        
       
                 &nbsp;<asp:Button ID="btnTemplateProfile" runat="server" class="btn btn-default" OnClick="btn_userprofile1_Click" Text="Template Access" />


        
       
               <br />

            </div>
        </div>
            <br />
            <br />
               <div class="table-wrapper-scroll-y my-custom-scrollbar">   
        <asp:Repeater ID="cpRepeater" runat="server"
            onitemcommand="cpRepeater_ItemCommand"
            >
        <HeaderTemplate>
        <table class="table table-striped table-hover">
        <tr >
       
        <td >  First Name </td>
        <td >Last Name</td>
        <td >Department</td>
            <td >UserName</td>
                    <td >Edit User</td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
               <tbody id="myTable">
        <tr >
        
        
            <td>
                <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Staff_Id") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Staff_First_Name")%>'></asp:Label>
                         </td>
            <td>
            <asp:label ID="txtName"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Staff_Last_Name")%>' ></asp:label>
            </td>
         <td>
            <asp:label ID="txtContent"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Staff_Department")%>' TextMode="MultiLine"></asp:label>
            </td>

            <td>
            <asp:label ID="Label2"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Staff_UserID")%>' TextMode="MultiLine"></asp:label>
            </td>
         <td ><asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Staff_Id") %>'  OnCommand="btnUpdate_Click" >Edit</asp:LinkButton>

            <asp:LinkButton Visible="false" ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Staff_Id") %>'>Update</asp:LinkButton>
            <asp:LinkButton Visible="false" ID="lnkCancel" runat="server" CommandName="cancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Staff_Id") %>'>Cancel</asp:LinkButton>
            

        </td>
        </tr>
                   </tbody>
        </ItemTemplate>
        <FooterTemplate>
        <tr >
        <td colspan="5">
            </FooterTemplate>
        </asp:Repeater>
                   <asp:Label runat ="server" ID ="lblSaveGroup"  Font-Size="Medium" ></asp:Label>
                   </div>
    </div>
    </asp:Panel>
    <asp:Panel runat ="server" ID ="panel2" Visible ="false">
        
        <div class="container-fluid" style ="margin-top:40px;">
            <h3> Edit User </h3>
<div class ="row">

    <div class="col-md-6">
        <p>First Name </p>
        <asp:TextBox runat="server" ID ="txtFirstName" Class="form-control"></asp:TextBox>

    </div>
    <div class="col-md-6">
        <p>Last Name </p>
        <asp:TextBox runat="server" ID ="txtlastname" Class="form-control"></asp:TextBox>

    </div>
</div>
<br />

            <div class ="row">

     
    <div class="col-md-6">
        <p>UserName</p>
        <asp:TextBox runat="server" ID ="txtwalaelyda5l" Class="form-control" ></asp:TextBox>
    
<asp:RegularExpressionValidator ID="YourRegularExpressionValidator" runat="server" 
                                ControlToValidate="txtwalaelyda5l" 
                                ErrorMessage="Minimum six characters!"  
    ForeColor="Red"
                                ValidationExpression="[0-9a-zA-Z]{6,}"></asp:RegularExpressionValidator>
    </div>
                <div class="col-md-6">
        <p>Password </p>
        <asp:TextBox runat="server" ID ="txtwalaelyda5l2" Class="form-control" TextMode ="Password" ></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtwalaelyda5l2" 
                                ErrorMessage="Minimum six characters!"  
    ForeColor="Red"
                                ValidationExpression="[0-9a-zA-Z]{6,}"></asp:RegularExpressionValidator>
    </div>
</div>

                        <div class ="row">
                            <div class="col-md-6">
        <p>Select Clinics </p>
                                <div class="table-wrapper-scroll-y my-custom-scrollbar2">   
        <asp:Repeater ID="repeater_clinic_edit" runat="server"
            onitemcommand="cpRepeater_ItemCommand">
             <HeaderTemplate>
             <table class="table table-striped table-hover">
       
       
        <tr >
         <td >  Select</td>
        <td >  Clinic Name</td>
        <td >Clinic Code</td>
        
        </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
        <tr >
        
              <td>
              <asp:CheckBox runat ="server" ID ="checkboxselectttt" />
                         </td>
            <td>
                <asp:Label ID="lblclinicid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblclinic_codett" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Code")%>'></asp:Label>
                         </td>
            <td>
            <asp:label ID="lblclinic_name"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Name")%>' ></asp:label>
            </td>
      

      
 
     
       
        </tr>
              
        </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
       
        </asp:Repeater>
                                 
                   </div>
                    

        
 
    </div>
     
    <div class="col-md-6">
        <p>User Group</p>
        <asp:DropDownList runat="server" ID ="ddluser_group_edit" Class="form-control" ></asp:DropDownList>
    
 
    </div>
                
</div>
             
            <br />
<asp:Button runat="server" ID ="btnsave" text ="Save" Class="btn btn-success" Width="120px" OnClick="btnsave_Click"/>
             <asp:Button runat="server" ID ="btncancel" text ="Cancel" Class="btn btn-default" Width="120px" OnClick="btncancel_Click" CausesValidation="False"/>
            <div class ="row">
 
                <br />

                   &nbsp;&nbsp;&nbsp;

                   <asp:Label runat ="server" id ="lblcheck"></asp:Label>
             
</div>
            
        </div>
    </asp:Panel>

         <asp:Panel runat ="server" ID ="panel3" Visible ="false" >
             <div class="container" style ="margin-top:40px;">
                 <h3> Add User </h3>

<div class ="row">

    <div class="col-md-6">
        <p>First Name</p>
        <asp:TextBox runat="server" ID ="txtfirstname2" Class="form-control"></asp:TextBox>

    </div>
    <div class="col-md-6">
        <p>Last Name</p>
        <asp:TextBox runat="server" ID ="txtlastName2" Class="form-control"></asp:TextBox>

    </div>
</div>
<br />

            <div class ="row">

     

                <div class="col-md-6">
        <p>Useraname</p>
        <asp:TextBox runat="server" ID ="txtusername2" class="form-control" ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="txtusername2" 
                                ErrorMessage="Minimum six characters!"  
    ForeColor="Red"
                                ValidationExpression="[0-9a-zA-Z]{6,}">
</asp:RegularExpressionValidator>

    </div>
                <div class="col-md-6">
        <p>Password</p>
        <asp:TextBox runat="server" ID ="txtpassword2" class="form-control" TextMode ="Password" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                ControlToValidate="txtpassword2" 
                                ErrorMessage="Minimum six characters!"  
    ForeColor="Red"
                                ValidationExpression="[0-9a-zA-Z]{6,}">
</asp:RegularExpressionValidator>
    </div>
     
</div>

                     <div class ="row">
                         <div class="col-md-6" >

                             <p> Select Clinic </p>
                             <div class="table-wrapper-scroll-y my-custom-scrollbar2">   
        <asp:Repeater ID="repeater_clinic" runat="server"
            onitemcommand="cpRepeater_ItemCommand">
             <HeaderTemplate>
             <table class="table table-striped table-hover">
       
       
        <tr >
         <td >  Select</td>
        <td > Clinic Code  </td>
        <td> Clinic Name </td>
        
        </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
        <tr >
        
              <td>
              <asp:CheckBox runat ="server" ID ="checkboxselect" />
                         </td>
            <td>
                <asp:Label ID="lblclinicid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblclinic_code" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Code")%>'></asp:Label>
                         </td>
            <td>
            <asp:label ID="lblclinic_name"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Name")%>' ></asp:label>
            </td>
      

      
 
     
       
        </tr>
              
        </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
       
        </asp:Repeater>
                                 
                   </div>
                         </div>
                         <div class="col-md-6">
 <p> User Group </p>
                             <asp:DropDownList runat="server"  ID ="ddlusergroup" class="form-control">

                             </asp:DropDownList>
                         </div>
                         
                  
 
                         </div>
        
<div class="row">
    <div class="col-md-6">

          <asp:Button runat="server" ID ="btnAddsave" text ="Save" Class="btn btn-success" Width="120px" OnClick="btnAddsave_Click" />
             <asp:Button runat="server" ID ="btnCancelsave" text ="Cancel" Class="btn btn-default" Width="120px" OnClick="btnCancelsave_Click" CausesValidation="False" />
                 <br />
                 <asp:Label runat ="server" id ="Label1"></asp:Label>
            
    </div>
</div>
                       
        </div>

         </asp:Panel>
    <asp:Panel runat ="server" ID ="panel_user_profile" Visible ="false">
        
        <div class="container-fluid">

            <h4> Link User Group to Clinic </h4>

            <div class="row">
                <div class="col-md-6">

                    <p>User Groups</p>
                    <asp:DropDownList runat="server" ID ="ddluser_group_profile" Class="form-control" AutoPostBack ="true" OnSelectedIndexChanged="ddluser_group_profile_SelectedIndexChanged" >


                    </asp:DropDownList>
                </div>

                <div class="col-md-6">
                  <p> Select Clinic </p>
                    <asp:CheckBox runat="server" ID ="checkbox22"  Text ="Select All " OnCheckedChanged="checkbox22_CheckedChanged" AutoPostBack ="true"/>
                    <div class="table-wrapper-scroll-y my-custom-scrollbar2">   
        <asp:Repeater ID="repeater_clinics_profile" runat="server"
            onitemcommand="cpRepeater_ItemCommand">
             <HeaderTemplate>
             <table class="table table-striped table-hover">
       
       
        <tr >
         <td >  Select</td>
        <td > Clinic Code  </td>
        <td > Clinic Name</td>
        
        </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
        <tr >
        
              <td>
              <asp:CheckBox runat ="server" ID ="checkboxselectttt1" />
                         </td>
            <td>
                <asp:Label ID="lblclinicid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblclinic_code1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Code")%>'></asp:Label>
                         </td>
            <td>
            <asp:label ID="lblclinic_name"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Clinic_Name")%>' ></asp:label>
            </td>
      

      
 
     
       
        </tr>
              
        </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
       
        </asp:Repeater>
                                 
                   </div>
                </div>

            </div>
            <br />
            <asp:Button runat="server" ID ="btnsave_profile" text ="Save" Class="btn btn-success" Width="120px" OnClick="btnsave_profile_Click" />
             <asp:Button runat="server" ID ="btncancel_profile" text ="Cancel" Class="btn btn-default" Width="120px" OnClick="btncancel_profile_Click1"  />
        </div>
        
         
    </asp:Panel>
    <asp:Panel runat="server" ID ="paneluserGroup" Visible ="false">
        <div class="container-fluid">
            <h4> User Groups </h4>
            <br />
            <asp:LinkButton runat="server" ID ="linkbuttonAddGroup" text ="Add New Group" OnClick="linkbuttonAddGroup_Click"></asp:LinkButton>
            <div class="table-wrapper-scroll-y my-custom-scrollbar">   
        <asp:Repeater ID="Repeater_UserGroup" runat="server"
            onitemcommand="cpRepeater_ItemCommand"
            >
        <HeaderTemplate>
        <table class="table table-striped table-hover">
        <tr >
       
        <td > Group ID  </td>
        <td >Group Name</td>
        <td >Comment</td>
          
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
               <tbody id="myTable">
        <tr >
        
        
            <td>
                <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UG_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UG_Name")%>'></asp:Label>
                         </td>
           
         <td>
            <asp:label ID="txtContent"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Comments")%>' TextMode="MultiLine"></asp:label>
            </td>

            <td>
            <asp:label ID="Label2"   runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UG_Status")%>' TextMode="MultiLine"></asp:label>
            </td>
         

           

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


    </asp:Panel>
     <asp:Panel runat="server" ID ="paneladding" Visible ="false">
         <div class="container-fluid">

           <div class="row">

               <div class="col-md-6"> 
                   <p>UserGroup Name </p>

                   <asp:TextBox runat="server" ID ="txtusergroupname"  class="form-control" MaxLength="100"></asp:TextBox>
               </div>

                 <div class="col-md-6">
                   <p>Comment</p>
                   <asp:TextBox runat="server" ID ="txtcomment"  class="form-control" MaxLength="200"></asp:TextBox>
               </div>
           </div>
             <div class="row">
               <div class="col-md-6">
                   <br />
                   <br />
                   <asp:checkbox runat="server" id ="checkboxActive1_group" Text ="Active"></asp:checkbox>
               </div>
             </div>
             <br />
           <asp:Button runat="server"  ID ="btnAddGroup"  class="btn btn-success" Text ="Add Group" OnClick="btnAddGroup_Click" Width ="130"/>
      <asp:Button runat ="server" ID ="btnCancelAddingGroup"  class="btn btn-default" text="Cancel" Width ="130" OnClick="btnCancelAddingGroup_Click1"  />

            
         
         </asp:Panel>
    <asp:Panel runat ="server" ID ="panelTemplate" Visible ="false">

        <div class="container-fluid">

            <h4> Link User Group to Templates</h4>

            <div class="row">
                <div class="col-md-6">

                    <p>User Groups</p>
                    <asp:DropDownList runat="server" ID ="ddlUserGroupTemplate" Class="form-control" AutoPostBack ="true" OnSelectedIndexChanged="ddlUserGroupTemplate_SelectedIndexChanged" >


                    </asp:DropDownList>
                </div>

                <div class="col-md-6">
                  <p> Select Template  </p>
                    <asp:CheckBox runat="server" ID ="checkbox1"  Text ="Select All " OnCheckedChanged="checkbox1_CheckedChanged" AutoPostBack ="true"/>
                    <div class="table-wrapper-scroll-y my-custom-scrollbar2">   
        <asp:Repeater ID="repeater_template_userGroup" runat="server"
            onitemcommand="cpRepeater_ItemCommand">
             <HeaderTemplate>
             <table class="table table-striped table-hover">
       
       
        <tr >
         <td >  Select</td>
        <td >Template_Code  </td>
        <td > Template Name</td>
            <td > Template Description</td>
        
        </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
        <tr >
        
              <td>
              <asp:CheckBox runat ="server" ID ="checkboxselectttt1" />
                         </td>
            <td>
                <asp:Label ID="lbltemplateID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Template_ID") %>' Visible="false"></asp:Label>
            <asp:Label ID="lbltemplateCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Template_Code")%>'></asp:Label>
                         </td>
            <td>
            <asp:label ID="lblremplateName"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Template_Name")%>' ></asp:label>
            </td>
      
            <td>
            <asp:label ID="lbltemp_desc"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Template_Description")%>' ></asp:label>
            </td>
      
 
     
       
        </tr>
              
        </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
       
        </asp:Repeater>
                                 
                   </div>
                </div>

            </div>
            <br />
            <asp:Button runat="server" ID ="btn_saveTemplate_UserGroup" text ="Save" Class="btn btn-success" Width="120px" OnClick="btn_saveTemplate_UserGroup_Click" />
             <asp:Button runat="server" ID ="btn_CancelTemplateUserGruop" text ="Cancel" Class="btn btn-default" Width="120px" OnClick="btn_CancelTemplateUserGruop_Click1"  />
            <br />
            <asp:Label runat ="server" ID ="lblcheck2"></asp:Label>
        </div>
    </asp:Panel>
</asp:Content>
