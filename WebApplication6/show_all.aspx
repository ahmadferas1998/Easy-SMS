<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="show_all.aspx.cs" Inherits="AmHospital.show_all" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Panel runat="server" ID ="panel_show_all" Visible ="false">

            <div class="container">

              
                <h4> Appointments Of The Same Patient</h4>
                  <div class="row">

                      <div class="col-md-6">
                          <p>Mobile Number </p>
                          <asp:TextBox runat="server" ID ="txtmobnumber" class="form-control"></asp:TextBox>

                      </div>
                      
                      <div class="col-md-6">
                          <p>Date : </p>

                          <asp:TextBox ID="txtdate3" runat="server"  BackColor="#cccccc" placeholder="DD/MM/YYYY" class="form-control"></asp:TextBox> 
                          <br />
                         
                      </div>
                  </div>

                <div class="row">

                    <div class="col-md-6">

                         <asp:Button runat="server" ID ="btn_filter_showall" Text ="Search" class="btn-success" OnClick="btn_filter_showall_Click" />

                    </div>
                </div>
                <div class="grid">
                    
        <asp:Repeater ID="cpRepeater" runat="server">
        <HeaderTemplate>
        <table class="table table-striped table-hover">
        <tr style="background-color:#00B140;color:#ffffff;font-weight:bold">
       
        
        <td style ="width:400px" > Appointment Number </td>
        <td style ="width:200px">Appointment Date </td>
                    <td style ="width:200px" >MR Number </td>
                 <td  style ="width:200px"> Patient Name </td>
             <td  style ="width:200px"> Mobile Number</td>
               <td  style ="width:200px"> Clinic  </td>
            <td  style ="width:200px"> Doctor</td>
             <td  style ="width:200px"> Response</td>
        
              
            <td  style ="width:200px"> Comment</td>
             <td  style ="width:200px"> Confirm</td>
            <td  style ="width:200px"> Cancel</td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr style="background-color:#ffffff">
        
        
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

            <asp:LinkButton Visible="false" ID="LinkButton2" runat="server" CommandName="update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Appointment_No") %>'>Update</asp:LinkButton>
            <asp:LinkButton Visible="false" ID="LinkButton3" runat="server" CommandName="cancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Appointment_No") %>'>Cancel</asp:LinkButton>
            

        </td>
         <td > 

            

        </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        <tr style="background-color:#00B140">
        <td colspan="11">
            </FooterTemplate>
        </asp:Repeater>
                </div>
                
            </div>
        </asp:Panel>
</asp:Content>
