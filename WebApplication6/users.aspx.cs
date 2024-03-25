using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuissnessLogic;
using BussinessObject;

namespace AmHospital
{
    public partial class users : System.Web.UI.Page
    {
        
            BussinessObject.User user = new BussinessObject.User();
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    BindRepeater();
                fill_clinic();
                Fill_usergroup();
                fill_groups();
                fill_template_();



                }
            }
            protected void btnUpdate_Click(object sender, CommandEventArgs e)
            {
                if (e.CommandArgument != null && e.CommandArgument != "")
                {

                    user.user_id = Convert.ToInt32(e.CommandArgument);
                    Session["testuser"] = user.user_id;

                    Edit(user.user_id);
                Edit_clinic(user.user_id);

                panel2.Visible = true;
                panel1.Visible = false;



                }
            }
        public void fill_groups ()
        {
          try
            {
                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();

                DataSet ds = logic.ReturnDataSet("SELECT * FROM TBL_UserGroupMaster order by UG_Name asc");

                Repeater_UserGroup.DataSource = ds;
                Repeater_UserGroup.DataBind();

              // fill the dropdownlist
            }
            catch(Exception ex)
            {

            }

        }


        public void fill_template_()
        {

           
           

            try
            {
                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();

                DataSet ds = logic.ReturnDataSet("SELECT * FROM TBL_TemplateMaster order by Template_Name asc");
                repeater_template_userGroup.DataSource = ds;
                repeater_template_userGroup.DataBind();
            }
            catch (Exception ex)
            {

            }

        }

        public void Edit(int id)
            {

                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds = logic.ReturnDataSet("select * from TBL_UserMaster where Staff_Id = " + id);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Staff_First_Name"]))
                        {
                            txtFirstName.Text = ds.Tables[0].Rows[0]["Staff_First_Name"].ToString();


                        }
                        else
                    {
                        txtFirstName.Text = "";
                    }

                        if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Staff_Last_Name"]))
                        {
                            txtlastname.Text = ds.Tables[0].Rows[0]["Staff_Last_Name"].ToString();


                        }
                        else
                    {
                        txtlastname.Text = "";

                    }

                      


                        if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Staff_UserID"]))
                        {
                            txtwalaelyda5l.Text = ds.Tables[0].Rows[0]["Staff_UserID"].ToString();


                        }
                        else
                        {
                        txtwalaelyda5l.Text = "";
                         }

                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Staff_Password"]))
                    {
                        txtwalaelyda5l2.Text = ds.Tables[0].Rows[0]["Staff_Password"].ToString();


                    }
                    else
                    {
                        txtwalaelyda5l2.Text = "";
                    }

                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Group_ID"]))
                    {
                        ddluser_group_edit.SelectedValue = ds.Tables[0].Rows[0]["Group_ID"].ToString();


                    }
                    else
                    {
             
                    }


                }

                }
                catch (Exception ex)
                {


                }

            }


        public void Edit_clinic(int id)
        {
            //get the clinics that are related to this user 
            //at first set all itemsfalse
            foreach (RepeaterItem i in repeater_clinic_edit.Items)
            {
                CheckBox cb2 = (CheckBox)i.FindControl("checkboxselectttt");

                cb2.Checked = false;
            }

            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
            DataSet ds = logic.ReturnDataSet("select Clinic_Code from TBL_UserLinkClinics where Staff_ID = " + id + " " + "and Clinic_Code is not null ");

            //now loop inside the repeater 

            try
            {
              string cliniccode = "";
              for (int x=0; x<=ds.Tables[0].Rows.Count-1;x++)
                {
                try
                    {
                        cliniccode = ds.Tables[0].Rows[x]["Clinic_Code"].ToString();
                    }
                    catch(Exception ex )
                    {

                    }
                    foreach (RepeaterItem i in repeater_clinic_edit.Items)
                    {


                      
                        
                            try
                            {

                                Appointment app = new Appointment();
                                Label clinic_codelabel = (Label)i.FindControl("lblclinic_codett");
                                string clinic_str = clinic_codelabel.Text;
                               CheckBox cb2 = (CheckBox)i.FindControl("checkboxselectttt");
                            if (cliniccode ==clinic_str)
                            {
                                
                                cb2.Checked=true;


                            }
                                


                            }
                            catch (Exception ex)
                            {
                          


                            }
                            //Retrieve the value associated with that CheckBox





                            //Now we can use that value to do whatever we want

                     
                       
                    }
                }
                
            }
            catch (Exception ex)
            {


            }

        }
        public void fill_clinic()
        {
            try
            {
                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds = logic.ReturnDataSet("select  Clinic_ID,Clinic_Code,Clinic_Name from TBL_ClinicsMaster");
                repeater_clinic.DataSource = ds;
                repeater_clinic.DataBind();
                repeater_clinic_edit.DataSource = ds;
                repeater_clinic_edit.DataBind();
                repeater_clinics_profile.DataSource = ds;
                repeater_clinics_profile.DataBind();

            }
            catch (Exception ex)
            {

            }

        }

        public void Edit_Template_Group()

        {

            int group_id = Convert.ToInt32(ddlUserGroupTemplate.SelectedValue);

            foreach (RepeaterItem i in repeater_template_userGroup.Items)
            {//
                CheckBox cb2 = (CheckBox)i.FindControl("checkboxselectttt1");

                cb2.Checked = false;
            }

            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
            DataSet ds = logic.ReturnDataSet("select TemplateCode from Template_UserGroupp where GroupID = " + group_id + " " + "and TemplateCode is not null ");

            //now loop inside the repeater 

            try
            {
                string templatecode = "";
                for (int x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
                {
                    try
                    {
                        templatecode = ds.Tables[0].Rows[x]["TemplateCode"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                    foreach (RepeaterItem i in repeater_template_userGroup.Items)
                    {




                        try
                        {

                            //Appointment app = new Appointment();
                            Label template_codelabel = (Label)i.FindControl("lbltemplateCode");
                            string templatecodelabel_str = template_codelabel.Text;
                            CheckBox cb2 = (CheckBox)i.FindControl("checkboxselectttt1");
                            if (templatecode == templatecodelabel_str)
                            {

                                cb2.Checked = true;


                            }



                        }
                        catch (Exception ex)
                        {



                        }
                        //Retrieve the value associated with that CheckBox





                        //Now we can use that value to do whatever we want



                    }
                }

            }
            catch (Exception ex)
            {


            }






        }

        public void Edit_user_profile()
        {

            int group_id = Convert.ToInt32(ddluser_group_profile.SelectedValue);

            foreach (RepeaterItem i in repeater_clinics_profile.Items)
            {//
                CheckBox cb2 = (CheckBox)i.FindControl("checkboxselectttt1");

                cb2.Checked = false;
            }

            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
            DataSet ds = logic.ReturnDataSet("select Clinic_Code from User_Profile where Group_ID = " + group_id + " " + "and Clinic_Code is not null ");

            //now loop inside the repeater 

            try
            {
                string cliniccode = "";
                for (int x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
                {
                    try
                    {
                        cliniccode = ds.Tables[0].Rows[x]["Clinic_Code"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                    foreach (RepeaterItem i in repeater_clinics_profile.Items)
                    {




                        try
                        {

                            Appointment app = new Appointment();
                            Label clinic_codelabel = (Label)i.FindControl("lblclinic_code1");
                            string clinic_str = clinic_codelabel.Text;
                            CheckBox cb2 = (CheckBox)i.FindControl("checkboxselectttt1");
                            if (cliniccode == clinic_str)
                            {

                                cb2.Checked = true;


                            }



                        }
                        catch (Exception ex)
                        {



                        }
                        //Retrieve the value associated with that CheckBox





                        //Now we can use that value to do whatever we want



                    }
                }

            }
            catch (Exception ex)
            {


            }






        }

        protected void cpRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                if (e.CommandName == "update")
                {
                    //TBL_TemplateMaster
                    SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.AppSettings["AHDPortalConnection"]);
                    SqlCommand SqlCmd = new SqlCommand("update TBL_TemplateMaster set Template_Name=@Template_Name, Template_Description=@Template_Description,Template_Content =@Template_Content  where Template_ID=@Template_ID", SqlCnn);
                    SqlCmd.Parameters.Add("@Template_Name", SqlDbType.VarChar).Value = "";
                    SqlCmd.Parameters.Add("@UpdatedType", SqlDbType.VarChar).Value = "";
                    SqlCmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = e.CommandArgument;
                    try
                    {
                        SqlCnn.Open();
                        SqlCmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                    finally
                    {
                        if (SqlCnn.State == ConnectionState.Open)
                            SqlCnn.Close();
                    }
                    BindRepeater();
                }
                if (e.CommandName == "delete")
                {
                    SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                    SqlCommand SqlCmd = new SqlCommand("delete CPMEMBERS where id=@ID", SqlCnn);
                    SqlCmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = e.CommandArgument;
                    try
                    {
                        SqlCnn.Open();
                        SqlCmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                    finally
                    {
                        if (SqlCnn.State == ConnectionState.Open)
                            SqlCnn.Close();
                    }
                    BindRepeater();
                }

            }

        public void Fill_usergroup()
        {
            ddlusergroup.Items.Clear();
            ddluser_group_edit.Items.Clear();
            ddluser_group_profile.Items.Clear();
            ddlUserGroupTemplate.Items.Clear();
            try
            {
                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds = logic.ReturnDataSet("select  UG_ID,UG_Name  from TBL_UserGroupMaster where UG_Name != '' ");
           for (int x=0; x<= ds.Tables[0].Rows.Count-1; x++)
                {
                    ListItem li = new ListItem();
                    li.Value = ds.Tables[0].Rows[x]["UG_ID"].ToString();
                    li.Text = ds.Tables[0].Rows[x]["UG_Name"].ToString();
                    ddlusergroup.Items.Add(li);
                    ddluser_group_edit.Items.Add(li);
                    ddluser_group_profile.Items.Add(li);
                    ddlUserGroupTemplate.Items.Add(li);

                }
            }
            catch (Exception ex)
            {

            }

        }
            private void BindRepeater()
            {

                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();

                DataSet dt = logic.ReturnDataSet("select * from TBL_UserMaster ");


                cpRepeater.DataSource = dt;
                cpRepeater.DataBind();
            }

            protected void btnsave_Click(object sender, EventArgs e)
            {
                lblcheck.Text = "";

                SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);
                try
                {

              
                    if (Session["testuser"] != null)
                    {

                    //check if username exist 
                    BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                    DataSet ds = logic.ReturnDataSet("select Staff_Id from TBL_UserMaster where Staff_UserID = '"+ txtwalaelyda5l.Text.Replace (" ","") + "' and Staff_Id != " + Convert.ToInt32(Session["testuser"]));
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SqlCommand SqlCmd = new SqlCommand("update TBL_UserMaster set Staff_First_Name=@Staff_First_Name, Staff_Last_Name=@Staff_Last_Name,Staff_UserID =@Staff_UserID,Staff_Password=@Staff_Password,Group_ID =@Group_ID where Staff_Id=@Staff_Id", SqlCnn);
                        SqlCmd.Parameters.Add("@Staff_First_Name", txtFirstName.Text);
                        SqlCmd.Parameters.Add("@Staff_Last_Name", txtlastname.Text);
                        
                        SqlCmd.Parameters.Add("@Staff_UserID", txtwalaelyda5l.Text.Replace(" ", ""));

                        SqlCmd.Parameters.Add("@Staff_Password", txtwalaelyda5l2.Text);
                        SqlCmd.Parameters.Add("@Group_ID", ddluser_group_edit.SelectedValue);

                        SqlCmd.Parameters.Add("@Staff_Id", Convert.ToInt32(Session["testuser"]));


                        //Group_ID

                        //Session["test"]

                        try
                        {
                            SqlCnn.Open();
                            SqlCmd.ExecuteNonQuery();
                            lblcheck.Text = "Saved Successfully";

                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                            lblcheck.Text = "Some Thing Went Wrong Please Contact Support !!";
                        }
                        finally
                        {

                            SqlCnn.Close();
                        }
                        user_clinic user_ = new user_clinic();
                        
                     
                        //at first remove for this user then add again 
                      BuissnessLogic.Class1 logicc = new BuissnessLogic.Class1();
                        logicc.delete_user_details_clinic(Convert.ToInt32(Session["testuser"]));
                        //now insert into usergroup table 
                        try
                        {
                             
                            
                         
                            foreach (RepeaterItem i in repeater_clinic_edit.Items)
                            {


                                //Retrieve the state of the CheckBox
                                CheckBox cb = (CheckBox)i.FindControl("checkboxselectttt");

                                if (cb.Checked)
                                {
                                    user_clinic us_clinic = new user_clinic();
                                    Label clinic_co = (Label)i.FindControl("lblclinic_codett");
                                    string clinic_code = clinic_co.Text;
                                    //get the id of the last user j

                                     
                                        us_clinic.staff_id = Convert.ToInt32(Session["testuser"]);
                                        us_clinic.clinic_code = clinic_code;
                                        us_clinic.modified_by = Session["username"].ToString();
                                        us_clinic.modified_on = DateTime.Now;
                                        logicc.add_user_clinic_modified(us_clinic);
                                        Label1.Text = "Saved Successfully";




                                    




                                }
                            }

                        }
                        catch (Exception ex)
                        {

                        }







                    }
                    else
                    {
                        lblcheck.Text = "Username Was already Found !";
                     }


                }
                }
                catch (Exception ex)
                {


                }


            }

            protected void btncancel_Click(object sender, EventArgs e)
            {
            //Session["testuser"]
                Session.Remove("testuser");
                panel2.Visible = false;
                panel1.Visible = true;
            BindRepeater();


            }

            protected void btnAddNew_Click(object sender, EventArgs e)
            {
                panel3.Visible = true;
                panel1.Visible = false;
                txtfirstname2.Text = "";
                txtlastName2.Text = "";
                txtusername2.Text = "";
            txtpassword2.Text = "";

        }

            protected void btnAddsave_Click(object sender, EventArgs e)
            {


                Label1.Text = "";

                SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);
                try
                {
                    //get the last id 
                    int number = 0;

                    BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();



                    SqlCommand SqlCmd = new SqlCommand("insert into  TBL_UserMaster (Staff_First_Name,Staff_Last_Name,Staff_UserID,Staff_Password,Group_ID)  values (@Staff_First_Name,@Staff_Last_Name,@Staff_UserID,@Staff_Password,@Group_ID)", SqlCnn);
                BuissnessLogic.Class1 logic2 = new BuissnessLogic.Class1();
                

                DataSet ds = logic2.ReturnDataSet("select Staff_Id from TBL_UserMaster where Staff_UserID = '" + txtusername2.Text.Replace(" ", "") + "'");
             
                if (ds.Tables[0].Rows.Count ==0)
                {
                    try
                    {

                        SqlCmd.Parameters.Add("@Staff_First_Name", txtfirstname2.Text);
                        SqlCmd.Parameters.Add("@Staff_Last_Name", txtlastName2.Text);
                      
                        //Session["username"].ToString()
                        SqlCmd.Parameters.Add("@Staff_UserID", txtusername2.Text.Replace(" ", ""));

                        SqlCmd.Parameters.Add("@Staff_Password", txtpassword2.Text);
                        SqlCmd.Parameters.Add("@Group_ID", ddlusergroup.SelectedValue);



                    }
                    catch (Exception ex)
                    {

                    }

                    //Session["test"]

                    try
                    {
                        SqlCnn.Open();
                        SqlCmd.ExecuteNonQuery();
                        Label1.Text = "Saved Successfully";
                        //now insert add clinics users  
                        try
                        {
                            BuissnessLogic.Class1 logicc = new BuissnessLogic.Class1();
                            DataSet dss = logicc.ReturnDataSet("select top (1) Staff_Id from TBL_UserMaster order by Staff_Id desc ");
                            foreach (RepeaterItem i in repeater_clinic.Items)
                            {

                               
                                //Retrieve the state of the CheckBox
                                CheckBox cb = (CheckBox)i.FindControl("checkboxselect");
                     
                                if (cb.Checked)
                                {
                                    user_clinic us_clinic = new user_clinic();
                                    Label clinic_co = (Label)i.FindControl("lblclinic_code");
                                    string clinic_code = clinic_co.Text;
                                    //get the id of the last user j

                                    if (dss.Tables[0].Rows.Count >0)
                                    {
                                        us_clinic.staff_id = Convert.ToInt32(dss.Tables[0].Rows[0]["Staff_Id"]);
                                        us_clinic.clinic_code = clinic_code;
                                        us_clinic.created_by = Session["username"].ToString();
                                        us_clinic.created_on = DateTime.Now;
                                        logicc.add_user_clinic(us_clinic);
                                        Label1.Text = "Saved Successfully";




                                    }


                                    

                                }
                             }

                        }
                        catch(Exception ex)
                        {

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        Label1.Text = "Some Thing Went Wrong Please Contact Support !!";
                    }
                    finally
                    {

                        SqlCnn.Close();
                    }

                }
                else
                {

                    Label1.Text = "UserName Was Found !";
                }

                }

                catch (Exception ex)
                {


                }
         
            

            }

            protected void btnCancelsave_Click(object sender, EventArgs e)
            {
            panel3.Visible = false;
            panel1.Visible = true;
            BindRepeater();
            }

        protected void btn_userprofile_Click(object sender, EventArgs e)
        {
            panel_user_profile.Visible = true;
            panel1.Visible = false;


            Edit_user_profile();
        }

        protected void btnsave_profile_Click(object sender, EventArgs e)
        {

            try
            {


                //at first delete* from clinic_usergroup where usergroup = the selected one 
                int user_groupid = Convert.ToInt32(ddluser_group_profile.SelectedValue);


                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                logic.delete_user_profile(user_groupid);

                foreach (RepeaterItem i in repeater_clinics_profile.Items)
                {


                    //Retrieve the state of the CheckBox
                    CheckBox cb = (CheckBox)i.FindControl("checkboxselectttt1");

                    if (cb.Checked)
                    {
                        BuissnessLogic.Class1 logicc = new BuissnessLogic.Class1();
                        User_profile us_pr = new User_profile();
                        Label clinic_co = (Label)i.FindControl("lblclinic_code1");
                        string clinic_code = clinic_co.Text;
                        //get the id of the last user j


                        us_pr.Group_ID = user_groupid;
                        us_pr.cllinic_code = clinic_code;
                    
                            logicc.add_user_profile(us_pr);
                            Label1.Text = "Saved Successfully";




                         




                    }
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void Add_Template_Clinic ()
        {

            try
            {


                //at first delete* from clinic_usergroup where usergroup = the selected one 
                int user_groupid = Convert.ToInt32(ddlUserGroupTemplate.SelectedValue);


                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                logic.delete_template_profile(user_groupid);
                //

                foreach (RepeaterItem i in repeater_template_userGroup.Items)
                {


                    //Retrieve the state of the CheckBox
                    CheckBox cb = (CheckBox)i.FindControl("checkboxselectttt1");

                    if (cb.Checked)
                    {
                        BuissnessLogic.Class1 logicc = new BuissnessLogic.Class1();
                     //   User_profile us_pr = new User_profile();
                       
                        Label template_code = (Label)i.FindControl("lbltemplateCode");
                        string template_codestr = template_code.Text;
                        //get the id of the last user j
                        // get template desc

                        Label template_description = (Label)i.FindControl("lbltemp_desc");
                        string template_descriptionstr  = template_description.Text;
                        //get the id of the last user j
                        //get TEMPLATE id 
                        Label template_id = (Label)i.FindControl("lbltemplateID");
                        int template_idint = Convert.ToInt32(template_id.Text);

                        //get the id of the last user j

                        //get template name 
                        // lblremplateName
                        Label template_Name = (Label)i.FindControl("lblremplateName");
                        string  template_Namestr = template_Name.Text;


                        BussinessObject.Template_Group template_group = new BussinessObject.Template_Group();
                        template_group.groupID = user_groupid;
                        template_group.templateCode = template_codestr;
                        template_group.template_Description = template_descriptionstr;
                        template_group.Template_ID = template_idint;
                        template_group.Template_Name = template_Namestr;

                        logicc.add_utemplate_profile(template_group);
                        lblcheck2.Text = "Saved Successfully";









                    }
                }

            }
            catch (Exception ex)
            {
                lblcheck2.Text = "Sorry !! Something Went Wrong Please try again later ";

            }
        }
   
        protected void btncancel_profile_Click(object sender, EventArgs e)
        {

        }

        protected void btncancel_profile_Click1(object sender, EventArgs e)
        {
            panel_user_profile.Visible = false;
            panel1.Visible = true;

        }

        protected void ddluser_group_profile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Edit_user_profile();
            }
            catch(Exception ex)
            {


            }
        }

        protected void checkbox22_CheckedChanged(object sender, EventArgs e)
        {
            //repeater_clinics_profile 
            bool check = false;
            if (checkbox22.Checked)
            {
                check = true;


            }
            else
            {
                check = false;
            }
            foreach (RepeaterItem i in repeater_clinics_profile.Items)
            {


                //Retrieve the state of the CheckBox
                CheckBox cb = (CheckBox)i.FindControl("checkboxselectttt1");

                cb.Checked = check;


            }


        }

        protected void linkbuttonAddGroup_Click(object sender, EventArgs e)
        {
            paneluserGroup.Visible = false;
            paneladding.Visible = true;
           
        }

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            //add new user group 
            BussinessObject.UserGroup group = new BussinessObject.UserGroup();
            group.UGName = txtusergroupname.Text;
            if (checkboxActive1_group.Checked)
            {
                group.status = true;
            }
            else
            {
                group.status = false;
            }
            if (txtcomment.Text.Replace (" ","") != string.Empty)
            {
                group.comment = txtcomment.Text;
            }
            else

            { group.comment = ""; }


            group.createddate = DateTime.Now;
            group.createdBy = Session["username"].ToString();

try
            {

                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                logic.add_user_group(group);
               
                lblSaveGroup.Text = "Added Successfully";


            }
            catch (Exception ex)
            {
                lblSaveGroup.Text = "Sorry !! SomeThing went wrong please try again later ";
            }


        }

        protected void btnCancelAddingGroup_Click(object sender, EventArgs e)
        {
            paneladding.Visible = false ;
            panel1.Visible = true;

        }

        protected void btnCancelAddingGroup_Click1(object sender, EventArgs e)
        {
            paneluserGroup.Visible = true;
            paneladding.Visible = false;
            fill_groups();
        }

        protected void btn_userprofile1_Click(object sender, EventArgs e)
        {


            panelTemplate.Visible = true;
            panel1.Visible = false;
            Edit_Template_Group();
     
        }

        protected void btn_saveTemplate_UserGroup_Click(object sender, EventArgs e)
        {
            Add_Template_Clinic();

        }

        protected void btn_CancelTemplateUserGruop_Click(object sender, EventArgs e)
        {
            panelTemplate.Visible = false;
            panel1.Visible = true;


        }

        protected void ddlUserGroupTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edit_Template_Group();
        }

        protected void checkbox1_CheckedChanged(object sender, EventArgs e)
        {
           
            bool check = false;
            if (checkbox1.Checked)
            {
                check = true;


            }
            else
            {
                check = false;
            }
            foreach (RepeaterItem i in repeater_template_userGroup.Items)
            {


                //Retrieve the state of the CheckBox
                CheckBox cb = (CheckBox)i.FindControl("checkboxselectttt1");

                cb.Checked = check;


            }

        }

        protected void btn_CancelTemplateUserGruop_Click1(object sender, EventArgs e)
        {
            panelTemplate.Visible = false;
            panel1.Visible = true; 

        }

        protected void btn_userprofile0_Click(object sender, EventArgs e)
        {
            paneluserGroup.Visible = true;
            panel1.Visible = false;
        }
    }

     
    }
