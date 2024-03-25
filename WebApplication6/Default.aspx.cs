using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace AmHospital
{
    public partial class default2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] ==null)
            {
                Response.Redirect("login_test.aspx", false);

            }
            else
            { 
            if (!IsPostBack)
            {
                fill_doc_clinic();



                Fill_Appointment();
                //    test();
                //Check_Multiple();
                //Check_Multiple_table();

                Fill_templates();
                fill_Appstatus();
                //check Role 
                try
                {
                    string group = Session["group_id_str"].ToString();
                    if (group == "Administrator")
                    {

                        panel1a.Visible = true;
                        panel1b.Visible = false;
                    }
                    else
                    {
                        panel1a.Visible = false;
                        panel1b.Visible = true;
                    }
                }
                catch (Exception ex)
                {

                }




                }
            }

        }
        
        public void fill_Appstatus()
        {
            try
            {
                ddlapp_status.Items.Clear();
                ListItem li0 = new ListItem();
                li0.Text = "--Select App Status--";
                li0.Value = "0";
                ddlapp_status.Items.Add(li0);
                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds = logic.ReturnDataSet("select distinct Appointment_Status from TBL_Appointments");
                for(int x =0; x<= ds.Tables[0].Rows.Count-1; x++)
                {
                   
                    ListItem li = new ListItem();
                    li.Text = ds.Tables[0].Rows[x]["Appointment_Status"].ToString();
                    li.Value = ds.Tables[0].Rows[x]["Appointment_Status"].ToString();
                    ddlapp_status.Items.Add(li);

                }
                ddlaptype.Items.Clear();
                ListItem li00 = new ListItem();
                li00.Text = "--Select App Type--";
                li00.Value = "0";
                ddlaptype.Items.Add(li00);
                BuissnessLogic.Class1 logic2 = new BuissnessLogic.Class1();
                DataSet ds2 = logic.ReturnDataSet("select distinct Appointment_Type from TBL_Appointments");
                for (int x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
                {
                    ListItem li = new ListItem();
                    li.Text = ds2.Tables[0].Rows[x]["Appointment_Type"].ToString();
                    li.Value = ds2.Tables[0].Rows[x]["Appointment_Type"].ToString();
                    ddlaptype.Items.Add(li);

                }
            }
            catch(Exception ex)
            {

            }
        }
        public void fill_doc_clinic()
        {
            try
            {
                BuissnessLogic.Class1 l = new BuissnessLogic.Class1();

                //check if he is admin or not 
                int ugid = Convert.ToInt32(Session["Group_ID"].ToString());

                DataSet dsgroup = l.ReturnDataSet("select UG_Name from TBL_UserGroupMaster where UG_ID = " + ugid);
                if (dsgroup.Tables[0].Rows[0]["UG_Name"].ToString() == "Administrator")
                {
                    DataSet dsadmin = l.ReturnDataSet("select Clinic_ID ,Clinic_Code ,Clinic_Name from TBL_ClinicsMaster ");
                    repeater_clinics_profile.DataSource = dsadmin;
                    repeater_clinics_profile.DataBind();


                    DataSet dsadmin_doc = l.ReturnDataSet("select Doctor_ID ,Doctor_Code ,Doctor_Name from TBL_DoctorsMaster ");
                    repeaterdoctor.DataSource = dsadmin_doc;
                    repeaterdoctor.DataBind();

                }
                else
                {
                    // fill clinics 
                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Clinic_Name", typeof(string));
                        dt.Columns.Add("Clinic_Code", typeof(string));


                        dt.Columns.Add("Clinic_ID", typeof(int));

                        //check the accepted clinics for this user  
                        DataSet dss = new DataSet();
                        DataSet dss2 = new DataSet();
                        BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                        dss = logic.ReturnDataSet("select Clinic_Code from User_Profile where Group_ID = " + ugid);
                        int staffid = Convert.ToInt32(Session["Staff_ID"]);

                        dss2 = logic.ReturnDataSet("select Clinic_Code from TBL_UserLinkClinics where Staff_ID = " + Session["Staff_ID"]);

                        for (int x = 0; x <= dss.Tables[0].Rows.Count - 1; x++)
                        {
                            DataSet dsss = new DataSet();
                            dsss = logic.ReturnDataSet("select Clinic_ID ,Clinic_Code ,Clinic_Name from TBL_ClinicsMaster where Clinic_Code = '" + dss.Tables[0].Rows[x]["Clinic_Code"] + "' order by Clinic_Name asc  ");
                            try
                            {
                                dt.Rows.Add(dsss.Tables[0].Rows[0]["Clinic_Name"].ToString(), dsss.Tables[0].Rows[0]["Clinic_Code"].ToString(), Convert.ToInt32(dsss.Tables[0].Rows[0]["Clinic_ID"]));
                            }
                            catch (Exception EX)
                            {
                            }

                        }

                        for (int x = 0; x <= dss2.Tables[0].Rows.Count - 1; x++)
                        {
                            DataSet dsss = new DataSet();
                            dsss = logic.ReturnDataSet("select Clinic_ID ,Clinic_Code ,Clinic_Name from TBL_ClinicsMaster where Clinic_Code = '" + dss2.Tables[0].Rows[x]["Clinic_Code"] + "' order by Clinic_Name asc  ");
                            try
                            {
                                dt.Rows.Add(dsss.Tables[0].Rows[0]["Clinic_Name"].ToString(), dsss.Tables[0].Rows[0]["Clinic_Code"].ToString(), Convert.ToInt32(dsss.Tables[0].Rows[0]["Clinic_ID"]));
                            }
                            catch (Exception EX)
                            {
                            }


                        }
                        DataTable dt3887 = new DataTable();
                        dt3887 = RemoveDuplicateRows(dt, "Clinic_ID");

                        repeater_clinics_profile.DataSource = dt3887;
                        repeater_clinics_profile.DataBind();

                        // now fill doctors 
                        DataTable dt3345 = new DataTable();
                        dt3345.Columns.Add("Doctor_Name", typeof(string));
                        dt3345.Columns.Add("Doctor_Code", typeof(string));


                        dt3345.Columns.Add("Doctor_ID", typeof(int));

                        for (int yy = 0; yy <= dt3887.Rows.Count - 1; yy++)
                        {
                            DataSet dd42234 = l.ReturnDataSet("select Doctor_ID ,Doctor_Code , Doctor_Name from TBL_DoctorsMaster where Clinic_Code ='" + dt3887.Rows[yy]["Clinic_Code"] + "' ");
                            for (int x = 0; x <= dd42234.Tables[0].Rows.Count - 1; x++)
                            {
                                try
                                {

                                    dt3345.Rows.Add(dd42234.Tables[0].Rows[x]["Doctor_Name"].ToString(), dd42234.Tables[0].Rows[x]["Doctor_Code"].ToString(), Convert.ToInt32(dd42234.Tables[0].Rows[x]["Doctor_ID"]));
                                }

                                catch (Exception ex)
                                {

                                }
                            }


                            repeaterdoctor.DataSource = dt3345;
                            repeaterdoctor.DataBind();
                        }


                    }
                    catch (Exception ex)
                    {

                    }


                }




                // 
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager
                            .ConnectionStrings["AHDPortalConnection"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select Doctor_Name,Doctor_Code  from TBL_DoctorsMaster";
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                ListItem item = new ListItem();
                                item.Text = sdr["Doctor_Name"].ToString();
                                item.Value = sdr["Doctor_Code"].ToString();
 

                            }
                        }
                        using (SqlCommand cmd_clinic = new SqlCommand())
                        {
                            cmd.CommandText = "select Clinic_Name,Clinic_Code  from TBL_ClinicsMaster";
                            cmd.Connection = conn;

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Clinic_Code"].ToString();
                                    item.Value = sdr["Clinic_Code"].ToString();
 
                                }
                            }
                            conn.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }


        public void fill_Template_By_Group ()
        {
            try
            {
                BuissnessLogic.Class1 l = new BuissnessLogic.Class1();

                //check if he is admin or not 
                int ugid = Convert.ToInt32(Session["Group_ID"].ToString());

                DataSet dsgroup = l.ReturnDataSet("select UG_Name from TBL_UserGroupMaster where UG_ID = " + ugid);
                if (dsgroup.Tables[0].Rows[0]["UG_Name"].ToString() == "Administrator")
                {
                    Fill_templates();
                    ;
                }
                else
                {
                    // fill clinics 
                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Clinic_Name", typeof(string));
                        dt.Columns.Add("Clinic_Code", typeof(string));


                        dt.Columns.Add("Clinic_ID", typeof(int));

                        //check the accepted clinics for this user  
                        DataSet dss = new DataSet();
                        DataSet dss2 = new DataSet();
                        BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                        dss = logic.ReturnDataSet("select Clinic_Code from User_Profile where Group_ID = " + ugid);
                        int staffid = Convert.ToInt32(Session["Staff_ID"]);

                        dss2 = logic.ReturnDataSet("select Clinic_Code from TBL_UserLinkClinics where Staff_ID = " + Session["Staff_ID"]);

                        for (int x = 0; x <= dss.Tables[0].Rows.Count - 1; x++)
                        {
                            DataSet dsss = new DataSet();
                            dsss = logic.ReturnDataSet("select Clinic_ID ,Clinic_Code ,Clinic_Name from TBL_ClinicsMaster where Clinic_Code = '" + dss.Tables[0].Rows[x]["Clinic_Code"] + "' order by Clinic_Name asc  ");
                            try
                            {
                                dt.Rows.Add(dsss.Tables[0].Rows[0]["Clinic_Name"].ToString(), dsss.Tables[0].Rows[0]["Clinic_Code"].ToString(), Convert.ToInt32(dsss.Tables[0].Rows[0]["Clinic_ID"]));
                            }
                            catch (Exception EX)
                            {
                            }

                        }

                        for (int x = 0; x <= dss2.Tables[0].Rows.Count - 1; x++)
                        {
                            DataSet dsss = new DataSet();
                            dsss = logic.ReturnDataSet("select Clinic_ID ,Clinic_Code ,Clinic_Name from TBL_ClinicsMaster where Clinic_Code = '" + dss2.Tables[0].Rows[x]["Clinic_Code"] + "' order by Clinic_Name asc  ");
                            try
                            {
                                dt.Rows.Add(dsss.Tables[0].Rows[0]["Clinic_Name"].ToString(), dsss.Tables[0].Rows[0]["Clinic_Code"].ToString(), Convert.ToInt32(dsss.Tables[0].Rows[0]["Clinic_ID"]));
                            }
                            catch (Exception EX)
                            {
                            }


                        }
                        DataTable dt3887 = new DataTable();
                        dt3887 = RemoveDuplicateRows(dt, "Clinic_ID");

                        repeater_clinics_profile.DataSource = dt3887;
                        repeater_clinics_profile.DataBind();

                        // now fill doctors 
                        DataTable dt3345 = new DataTable();
                        dt3345.Columns.Add("Doctor_Name", typeof(string));
                        dt3345.Columns.Add("Doctor_Code", typeof(string));


                        dt3345.Columns.Add("Doctor_ID", typeof(int));

                        for (int yy = 0; yy <= dt3887.Rows.Count - 1; yy++)
                        {
                            DataSet dd42234 = l.ReturnDataSet("select Doctor_ID ,Doctor_Code , Doctor_Name from TBL_DoctorsMaster where Clinic_Code ='" + dt3887.Rows[yy]["Clinic_Code"] + "' ");
                            for (int x = 0; x <= dd42234.Tables[0].Rows.Count - 1; x++)
                            {
                                try
                                {

                                    dt3345.Rows.Add(dd42234.Tables[0].Rows[x]["Doctor_Name"].ToString(), dd42234.Tables[0].Rows[x]["Doctor_Code"].ToString(), Convert.ToInt32(dd42234.Tables[0].Rows[x]["Doctor_ID"]));
                                }

                                catch (Exception ex)
                                {

                                }
                            }


                            repeaterdoctor.DataSource = dt3345;
                            repeaterdoctor.DataBind();
                        }


                    }
                    catch (Exception ex)
                    {

                    }


                }




                // 
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager
                            .ConnectionStrings["AHDPortalConnection"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select Doctor_Name,Doctor_Code  from TBL_DoctorsMaster";
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                ListItem item = new ListItem();
                                item.Text = sdr["Doctor_Name"].ToString();
                                item.Value = sdr["Doctor_Code"].ToString();


                            }
                        }
                        using (SqlCommand cmd_clinic = new SqlCommand())
                        {
                            cmd.CommandText = "select Clinic_Name,Clinic_Code  from TBL_ClinicsMaster";
                            cmd.Connection = conn;

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    ListItem item = new ListItem();
                                    item.Text = sdr["Clinic_Code"].ToString();
                                    item.Value = sdr["Clinic_Code"].ToString();

                                }
                            }
                            conn.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }



        public DataTable RemoveDuplicateRows(DataTable table, string DistinctColumn)
        {
            try
            {
                ArrayList UniqueRecords = new ArrayList();
                ArrayList DuplicateRecords = new ArrayList();

                // Check if records is already added to UniqueRecords otherwise,
                // Add the records to DuplicateRecords
                foreach (DataRow dRow in table.Rows)
                {
                    if (UniqueRecords.Contains(dRow[DistinctColumn]))
                        DuplicateRecords.Add(dRow);
                    else
                        UniqueRecords.Add(dRow[DistinctColumn]);
                }

                // Remove duplicate rows from DataTable added to DuplicateRecords
                foreach (DataRow dRow in DuplicateRecords)
                {
                    table.Rows.Remove(dRow);
                }

                // Return the clean DataTable which contains unique records.
                return table;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            //sign out 

            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("login_test.aspx", true);

        }

        public void Fill_templates()
        {

            // fill template should be depending on user group 
            // not all users can see all templates
           
            DataSet ds = new DataSet();
            ddltemplates.Items.Clear();
            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();

            try
            {



                
                int ugid = Convert.ToInt32(Session["Group_ID"].ToString());
                if (ugid == 1)
                {
                    if (RadioButtonapp_not.Checked)
                    {


                        ds = logic.ReturnDataSet("select Template_ID,Template_Name from TBL_TemplateMaster where Template_Description = 'Appointment Notification'");
                    }
                    else if (RadioButtonapp_reminder.Checked)
                    {
                        ds = logic.ReturnDataSet("select Template_ID,Template_Name,Template_Content from TBL_TemplateMaster where Template_Description = 'Reminders'");


                    }
                    else if (RadioButton_notify_cancell.Checked)
                    {
                        ds = logic.ReturnDataSet("select Template_ID,Template_Name from TBL_TemplateMaster where Template_Description = 'Notify Cancellation'");


                    }
                    else if (RadioButtonconfirm_cancel.Checked)
                    {
                        ds = logic.ReturnDataSet("select Template_ID,Template_Name from TBL_TemplateMaster where Template_Description = 'Confirm Cancel'");


                    }

                    for (int x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
                    {
                        ListItem li = new ListItem();
                        li.Text = ds.Tables[0].Rows[x]["Template_Name"].ToString();
                        li.Value = ds.Tables[0].Rows[x]["Template_ID"].ToString();
                        ddltemplates.Items.Add(li);





                    }
                }
                else
                {
                    // not administrator 
                    DataSet ds2 = new DataSet();
                    if (RadioButtonapp_not.Checked)
                    {
                        ds = logic.ReturnDataSet("select Template_ID,Template_Name from Template_UserGroupp where GroupID = " + ugid + "and Template_Description = 'Appointment Notification' "); 
                        

                       // ds = logic.ReturnDataSet("select Template_ID,Template_Name from TBL_TemplateMaster where Template_Description = 'Appointment Notification'");
                    }
                    else if (RadioButtonapp_reminder.Checked)
                    {
                        //
                        ds = logic.ReturnDataSet("select Template_ID,Template_Name from Template_UserGroupp where GroupID = " + ugid + "and Template_Description = 'Reminders'");


                    }
                    else if (RadioButton_notify_cancell.Checked)
                    {
                        //select Template_ID,Template_Name from TBL_TemplateMaster where Template_Description = ''
                        ds = logic.ReturnDataSet("select Template_ID,Template_Name from Template_UserGroupp where GroupID = " + ugid + "and Template_Description = 'Notify Cancellation'");


                    }
                    else if (RadioButtonconfirm_cancel.Checked)
                    {
 
                        ds = logic.ReturnDataSet("select Template_ID,Template_Name from Template_UserGroupp where GroupID = " + ugid + "and Template_Description = 'Confirm Cancel'");

                    }

                    for (int x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
                    {
                        ListItem li = new ListItem();
                        li.Text = ds.Tables[0].Rows[x]["Template_Name"].ToString();
                        li.Value = ds.Tables[0].Rows[x]["Template_ID"].ToString();
                        ddltemplates.Items.Add(li);





                    }

                }


            
                }
            catch(Exception ex)
            {

            }

                try
                {

                    string temp_id = ddltemplates.SelectedValue.ToString();
                    int id = Convert.ToInt32(temp_id);
                    DataSet ds2 = logic.ReturnDataSet("select Template_Content from TBL_TemplateMaster where Template_ID = " + id);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        if (!Convert.IsDBNull(ds2.Tables[0].Rows[0]["Template_Content"]))
                        {
                            txttempplate.Text = ds2.Tables[0].Rows[0]["Template_Content"].ToString();


                        }
                        else
                        {
                            txttempplate.Text = "";
                        }


                    }



                }

                catch (Exception ex)
                {


                }
                {
                }




            }
           

        

        protected void get_report(Object sender, CommandEventArgs e)
        {
            string iStID = e.CommandArgument.ToString();


            try
            {
                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds = logic.ReturnDataSet("select MobileNo from TBL_Appointments where Appointment_No = '" + iStID + "'");
                string mobile_no = ds.Tables[0].Rows[0]["MobileNo"].ToString();

                string url = "report.aspx?app_no=" + iStID + "&mobileno=" + mobile_no;
                Response.Redirect(url, false);


            }
            catch (Exception ex)
            {

            }


        }


        protected void show_all(Object sender, CommandEventArgs e)
        {
            string iStID = e.CommandArgument.ToString();


            try
            {
                string f1 = "";
                string f2 = "";
                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds = logic.ReturnDataSet("select MobileNo from TBL_Appointments where Appointment_No = '" + iStID + "'");
                string mobile_no = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                string url = "show_all_.aspx?app_no=" + iStID + "&mobileno=" + mobile_no;
                Response.Redirect(url, false);
                // show the panel 
                //panel_show_all.Visible = true;
                //panel1.Visible = false;
                //Session["mno"] = mobile_no;


                //Edit_show_all(Session["mno"].ToString(), f1,f2);


            }
            catch (Exception ex)
            {

            }


        }





        public void Fill_Appointment()
        {

           
            try
            {
                // Create a DataTable and add two Columns to it
                DataTable dt = new DataTable();
                dt.Columns.Add("Appointment_No", typeof(int));
                dt.Columns.Add("Appointment_Date", typeof(DateTime));
                dt.Columns.Add("Appointment_Time", typeof(string));


                dt.Columns.Add("ENNo", typeof(string));
                dt.Columns.Add("Patient_Name", typeof(string));

                dt.Columns.Add("Appointment_Status", typeof(string));
                dt.Columns.Add("SMSType", typeof(string));
                dt.Columns.Add("Appointment_Type", typeof(string));

                dt.Columns.Add("MobileNo", typeof(string));
                dt.Columns.Add("Doctor_Name", typeof(string));






                dt.Columns.Add("Status", typeof(string));


                dt.Columns.Add("Response", typeof(string));

                dt.Columns.Add("Reponse_Status", typeof(string));


                dt.Columns.Add("Patient_Code", typeof(string));

                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();


                DateTime todayDate = DateTime.Now;

                // var res = d.ToString("hh:mm tt");   // this show  11:12 Pm
                // var res2 = todayDate.ToString("HH:mm");  // this show  23:12

                string datetoday = todayDate.ToString("MM/dd/yyyy HH:mm:ss");
                DateTime tomorrowDate = todayDate.AddDays(1);
                string datetomorrow = tomorrowDate.ToString("MM/dd/yyyy HH:mm:ss");

                txtDatePicker.Text = datetoday;
                txtDatePicker2.Text = datetomorrow;


               DataSet ds = logic.ReturnDataSet("SELECT distinct MobileNo,Appointment_Date FROM TBL_Appointments where Appointment_Date >= '" + datetoday  + "' " + " and Appointment_Date <=  '" +  datetomorrow  + "' order by Appointment_Date desc ");

                for (int x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
                {
                    try
                    {
                        DateTime test = Convert.ToDateTime(ds.Tables[0].Rows[x]["Appointment_Date"]);
                        var sqlformattedDate = test.ToString("yyyy-MM-dd HH:mm:ss");


                        DataSet dss = logic.ReturnDataSet("select * from TBL_Appointments where  MobileNo = '" + ds.Tables[0].Rows[x]["MobileNo"] + "' and Appointment_Date ='" + sqlformattedDate + "'");
                        string res = dss.Tables[0].Rows[0]["Response"].ToString();
                        string pa_code = dss.Tables[0].Rows[0]["Patient_Code"].ToString();
                        dt.Rows.Add(dss.Tables[0].Rows[0]["Appointment_No"], dss.Tables[0].Rows[0]["Appointment_Date"], dss.Tables[0].Rows[0]["Appointment_Time"], dss.Tables[0].Rows[0]["ENNo"], dss.Tables[0].Rows[0]["Patient_Name"], dss.Tables[0].Rows[0]["Appointment_Status"].ToString(), dss.Tables[0].Rows[0]["SMSType"].ToString(), dss.Tables[0].Rows[0]["Appointment_Type"].ToString(), dss.Tables[0].Rows[0]["MobileNo"].ToString(), dss.Tables[0].Rows[0]["Doctor_Name"].ToString(), dss.Tables[0].Rows[0]["Status"].ToString(), res, dss.Tables[0].Rows[0]["Reponse_Status"].ToString(), pa_code);//
                    }
                    catch (Exception ex) { }
                }
                GridView1.DataSource = dt;

                GridView1.DataBind();
                repeater_appointment.DataSource = dt;
                repeater_appointment.DataBind();

            }

            catch (Exception ex)
            {

            }




        }

        protected void chklistDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            btnSearch_repeater();
        }

        public void btnSearch_repeater()
        {
            string ss =null; string ss2=null;
            DateTime XYZ =DateTime.Now;
            DateTime XYZ2 = DateTime.Now;
            repeater_appointment.DataSource = null;
            repeater_appointment.DataBind();

            // Create a DataTable and add two Columns to it
            DataTable dt = new DataTable();
            dt.Columns.Add("Appointment_No", typeof(int));
            dt.Columns.Add("Appointment_Date", typeof(DateTime));
            dt.Columns.Add("Appointment_Time", typeof(string));


            dt.Columns.Add("ENNo", typeof(string));
            dt.Columns.Add("Patient_Name", typeof(string));

            dt.Columns.Add("Appointment_Status", typeof(string));
            dt.Columns.Add("SMSType", typeof(string));
            dt.Columns.Add("Appointment_Type", typeof(string));

            dt.Columns.Add("MobileNo", typeof(string));
            dt.Columns.Add("Doctor_Name", typeof(string));






            dt.Columns.Add("Status", typeof(string));


            dt.Columns.Add("Response", typeof(string));

            dt.Columns.Add("Reponse_Status", typeof(string));


            dt.Columns.Add("Patient_Code", typeof(string));
            string query = "";
            string query2 = "";
            string query3 = "";
            string query4 = "";
            string query5 = "";
            //txtmrnomber

            if (txtmrnomber.Text.Replace(" ", "") != string.Empty)
            {

                query3 = "and Patient_Code  like '%" + txtmrnomber.Text + "%'";
            }
            else
            {

                query3 = "";
            }

            //if (txtpatientName.Text.Replace(" ", "") != string.Empty)
            //{

            //    query = "and Patient_Name  like '%" + txtpatientName.Text + "%'";
            //}
            //else
            //{

            //    query = "";
            //}

            if (txtmobilenumber.Text.Replace(" ", "") != string.Empty)
            {

                query2 = "and MobileNo  like '%" + txtmobilenumber.Text + "%'";
            }
            else
            {

                query2 = "";
            }


            if (ddlapp_status.SelectedValue.ToString() !=  "0") 
            {

                query4 = "and Appointment_Status  = '" + ddlapp_status.SelectedValue + "'";
            }
            else
            {

                query4 = "";
            }

            if (ddlaptype.SelectedValue.ToString() !=  "0")
            {

                query5 = "and Appointment_Type  = '" + ddlaptype.SelectedValue + "'";
            }
            else
            {

                query5 = "";
            }
            foreach (RepeaterItem rItem in repeaterdoctor.Items)
            {
                CheckBox cbx = rItem.FindControl("checkboxselectttt1") as CheckBox;
                if (cbx.Checked)
                {
                    Label doc_code = rItem.FindControl("lbldoccode") as Label;
                    BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                    string doccode_str = doc_code.Text;
                    DataSet ds = logic.ReturnDataSet("select top(20) * from TBL_Appointments where Doctor_Code = '" + doccode_str  + "'" + " " + query + " " + query2 + " " + query3 +" " +query4 + " "+ query5 + " " + "order by Appointment_Date desc");

                    try
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
                            {

                                // datet = DateTime.ParseExact(ds.Tables[0].Rows[x]["Appointment_Date"].ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                                DateTime datet1 = Convert.ToDateTime(ds.Tables[0].Rows[x]["Appointment_Date"]);

                                //  string datet3= datet1.ToString("yyyy-MM-dd HH:mm:ss");
                                //DateTime datet = DateTime.ParseExact(date1, "yyyy/MM/dd",
                                //            CultureInfo.InvariantCulture);

                                //DateTime test =Convert.ToDateTime(dateto.Value);

                                // string ss = datefrom.Value.ToString();
                                //  string ss2 = dateto.Value.ToString();
                                
                                try
                                {
                                     XYZ = Convert.ToDateTime(datefrom.Value.ToString());
                                    // string ss = XYZ.ToString("yyyy-MM-dd HH:mm:ss");
                                     ss = XYZ.ToString("yyyy-MM-dd HH:mm:ss");

                                     XYZ2 = Convert.ToDateTime(dateto.Value.ToString());
                                     ss2 = XYZ2.ToString("yyyy-MM-dd HH:mm:ss");

                                }
                                catch(Exception ec)
                                { }

                                if (ss != null && ss != "" && ss2 != null && ss2 != "")
                                {

                                    //DateTime d1 = DateTime.ParseExact(ss, "yyyy/MM/dd",
                                    //        CultureInfo.InvariantCulture);

                                    //DateTime d2 = DateTime.ParseExact(ss2, "yyyy/MM/dd",
                                    //                  CultureInfo.InvariantCulture);
                                    if (datet1 >= XYZ && datet1 <= XYZ2)
                                    {
                                        try
                                        {
                                            //Patient_Code
                                            string patient_code = ds.Tables[0].Rows[x]["Patient_Code"].ToString();
                                            string res = ds.Tables[0].Rows[x]["Response"].ToString();
                                       
                                                //  dt.Rows.Add(dss.Tables[0].Rows[0]["Appointment_No"], dss.Tables[0].Rows[0]["Appointment_Date"], dss.Tables[0].Rows[0]["Appointment_Time"], dss.Tables[0].Rows[0]["ENNo"], dss.Tables[0].Rows[0]["Patient_Name"], dss.Tables[0].Rows[0]["Appointment_Status"].ToString(), dss.Tables[0].Rows[0]["SMSType"].ToString(), dss.Tables[0].Rows[0]["Appointment_Type"].ToString(), dss.Tables[0].Rows[0]["MobileNo"].ToString(), dss.Tables[0].Rows[0]["Doctor_Name"].ToString(), dss.Tables[0].Rows[0]["Status"].ToString(), res, dss.Tables[0].Rows[0]["Reponse_Status"].ToString(), pa_code);//
                                            dt.Rows.Add(ds.Tables[0].Rows[x]["Appointment_No"], ds.Tables[0].Rows[x]["Appointment_Date"], ds.Tables[0].Rows[x]["Appointment_Time"], ds.Tables[0].Rows[x]["ENNo"], ds.Tables[0].Rows[x]["Patient_Name"].ToString(), ds.Tables[0].Rows[x]["Appointment_Status"].ToString(), ds.Tables[0].Rows[x]["SMSType"].ToString(), ds.Tables[0].Rows[x]["Appointment_Type"].ToString(), ds.Tables[0].Rows[x]["MobileNo"].ToString(), ds.Tables[0].Rows[x]["Doctor_Name"].ToString(), ds.Tables[0].Rows[x]["Status"].ToString(), ds.Tables[0].Rows[x]["Response"].ToString(), ds.Tables[0].Rows[x]["Reponse_Status"].ToString(), patient_code);

                                        }
                                        catch (Exception ex)
                                        { }

                                    }

                                }
                                else
                                {
                                    try
                                    {
                                        string res = ds.Tables[0].Rows[x]["Response"].ToString();
                                        dt.Rows.Add(ds.Tables[0].Rows[x]["Appointment_No"], ds.Tables[0].Rows[x]["Appointment_Date"], ds.Tables[0].Rows[x]["Appointment_Time"], ds.Tables[0].Rows[x]["ENNo"], ds.Tables[0].Rows[x]["Patient_Name"].ToString(), ds.Tables[0].Rows[x]["Appointment_Status"].ToString(), ds.Tables[0].Rows[x]["SMSType"].ToString(), ds.Tables[0].Rows[x]["Appointment_Type"].ToString(), ds.Tables[0].Rows[x]["MobileNo"].ToString(), ds.Tables[0].Rows[x]["Doctor_Name"].ToString(), ds.Tables[0].Rows[x]["Status"].ToString(), ds.Tables[0].Rows[x]["Response"].ToString(), ds.Tables[0].Rows[x]["Reponse_Status"].ToString(), ds.Tables[0].Rows[x]["Patient_Code"].ToString());

                                    }
                                    catch (Exception ex)
                                    { }
                                }

                            }
                        }

                    }

                    catch (Exception ex)
                    { }


                }



                {



                   




                }

                


            }
            try
            {
                repeater_appointment.DataSource = dt;
                repeater_appointment.DataBind();
            }
            catch(Exception ex)
            {

            }
            test();

        }

        protected void RadioButtonapp_not_CheckedChanged(object sender, EventArgs e)
        {
            Fill_templates();
        }

        protected void RadioButtonconfirm_cancel_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonconfirm_cancel.Checked)
            {
                Fill_templates();

            }
        }

        protected void RadioButton_notify_cancell_CheckedChanged(object sender, EventArgs e)
        {
            Fill_templates();
        }

        protected void RadioButtonapp_reminder_CheckedChanged(object sender, EventArgs e)
        {
            Fill_templates();

        }

        protected void ddltemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
            string temp_id = ddltemplates.SelectedValue.ToString();
            int id = Convert.ToInt32(temp_id);
            DataSet ds2 = logic.ReturnDataSet("select Template_Content from TBL_TemplateMaster where Template_ID = " + id);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (!Convert.IsDBNull(ds2.Tables[0].Rows[0]["Template_Content"]))
                {
                    txttempplate.Text = ds2.Tables[0].Rows[0]["Template_Content"].ToString();


                }
                else
                {
                    txttempplate.Text = "";
                }


            }
        }



        //protected void checbox_allclinics_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool flag = false;
        //    try
        //    {
        //        if (checbox_allclinics.Checked)
        //        {
        //            flag = true;


        //        }
        //        else
        //        {
        //            flag = false;
        //        }
        //        CheckBox2.Checked = flag;
        //        for (int i = 0; i < chklistClinic.Items.Count; i++)

        //            chklistClinic.Items[i].Selected = flag;

        //        for (int i = 0; i < chklistDoctors.Items.Count; i++)

        //            chklistDoctors.Items[i].Selected = flag;
        //    }
        //    catch (Exception ex)
        //    { }


        //}

        //protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool flag = false;
        //    try
        //    {
        //        if (CheckBox2.Checked)
        //        {

        //            flag = true;
        //        }
        //        else
        //        {
        //            flag = false;
        //        }
        //        for (int i = 0; i < chklistDoctors.Items.Count; i++)

        //            chklistDoctors.Items[i].Selected = flag;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        protected void checbox_grid_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (checbox_grid.Checked)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                    chkRow.Checked = flag;

                    //{
                    //    //string name = row.Cells[1].Text;
                    //    //string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;
                    //    //dt.Rows.Add(name, country);
                    //}
                }
            }
        }



    


        public void test ()
        {
            try
            {
            foreach (RepeaterItem item2 in repeater_appointment.Items)
            {
                
                    //Label lbl = (Label)item2.FindControl("lbl1");
                    //lbl.Attributes.Add("style", "background-color:Green;");

                Label lblstatussentornot = (Label)item2.FindControl("Label9"); //status label 

                Label lblstatus = (Label)item2.FindControl("Label10"); //status label 
                string str = "";
                string status = "";
                try
                {
                    status = lblstatus.Text;
                }
                catch (Exception ex)
                {

                }
                try
                {
                    str = lblstatussentornot.Text;
                }
                catch (Exception ex)
                {

                }

                if (str == "Sent")
                {
                    //style="font-weight:bold;color:red;"
                    if (status == "Confirm")
                    {
                            //e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f6f578");
                             
                            
                        lblstatus.Attributes.Add("style", "font-weight:bold");
                        lblstatus.Attributes.Add("style", "color:#f6f578");
                          
                            //if (status == "Confirm")
                            //{
                            //    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f6f578");


                            //}
                            //else if (status == "Cancel")
                            //{
                            //    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f6d743");
                            //    //#

                            //}
                            //else if (status == "Call Request")
                            //{
                            //    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#649d66");
                            //    //#

                            //}
                            //else
                            //{

                            //    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffe6e6");
                            //}

                        }
                    else if (status == "Cancel")
                    {
                        lblstatus.Attributes.Add("style", "font-weight:bold");
                        lblstatus.Attributes.Add("style", "color:#f6d743");
                        //#

                    }
                    else if (status == "CALL REQUEST")
                    {
                        lblstatus.Attributes.Add("style", "font-weight:bold;");
                        lblstatus.Attributes.Add("style", "color:#649d66");

                    }
                    else
                    {
                        lblstatus.Attributes.Add("style", "font-weight:bold");
                        lblstatus.Attributes.Add("style", "color:#ffe6e6");
                    }
                }


            }
            }
            catch(Exception ex)
            {

            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && !((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit)))
            {//
                Label lblstatussentornot = (Label)e.Row.FindControl("Label23"); //status label 

                Label lblstatus = (Label)e.Row.FindControl("Label25"); //status label 
                string status = lblstatus.Text;
                if (lblstatussentornot.Text == "Sent")
                {
                    if (status == "Confirm")
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f6f578");


                    }
                    else if (status == "Cancel")
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f6d743");
                        //#

                    }
                    else if (status == "Call Request")
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#649d66");
                        //#

                    }
                    else
                    {

                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffe6e6");
                    }
                }



            }
        }

        protected void btnpreview_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string name;
            string date = "";
            string patient_name = "";
            string mobile_number = "";
            string doctor = "";
            string date2 = "";
            string time2 = "";
            string status = "";

            try
            {
                
              foreach (RepeaterItem rItem in repeater_appointment.Items)
                {
                    CheckBox cbx = rItem.FindControl("checkboxselectttt10") as CheckBox;

                   
                        if (cbx.Checked)
                        {
                            counter++;
                           
                                Label lblapdate = rItem.FindControl("lblapdate") as Label;

                                date = lblapdate.Text;
                                DateTime test = Convert.ToDateTime((date));
                                date2 = test.ToString("dd-MM-yyyy");
                                //lblapptime
                                Label lblpatient_name = rItem.FindControl("lblapptime") as Label;

                                time2 = lblpatient_name.Text;

                                //Label18 5 patient name 
                                //Label5
                                Label lblpatient_name6 = rItem.FindControl("Label5") as Label;

                                patient_name = lblpatient_name6.Text;
                                //Label4
                                Label lblmobilenumber = rItem.FindControl("Label4") as Label;
                                mobile_number = lblmobilenumber.Text;
                                //
                                Label lbldoctor = rItem.FindControl("Label7") as Label;
                                doctor = lbldoctor.Text;
                                //Label9
                                Label lblstatus = rItem.FindControl("lblappstatus") as Label;

                                status = lblstatus.Text;
                                Label lblappno = rItem.FindControl("lblapno") as Label;
                                 
                                //

                            

                            //


                        }
                    }
             
              
                string Message_text = txttempplate.Text.Replace("{*Patient_Name}", patient_name).Replace("{*Doctor_Name }", doctor).Replace("{*Appointment_Date}", date2).Replace("{*Appointment_Time}", time2).Replace("{*Appointment_Status}", status).Replace("{*Doctor_name}", doctor).Replace("{*Doctor_Name}", doctor).Replace("{*Doctor_Name}", doctor).Replace("{*patient_name}", patient_name);
                txtpreview.Text = Message_text;
            }
            catch (Exception ex)
            {

            }
            //

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            send_SMS();




        }

        public void send_SMS ()
        {

            labelifsent.Text = "";

            string name;
            string date = "";
            string patient_name = "";
            string mobile_number = "";
            string doctor = "";
            string date2 = "";
            string time2 = "";
            string status = "";
            string appointment_no = "";

            try
            {
                var service = new WebApplication6.localhost.mySMS_SQLSoapClient();
                foreach (RepeaterItem rItem in repeater_appointment.Items)
                {
                    CheckBox cbx = rItem.FindControl("checkboxselectttt10") as CheckBox;
                    

                       
                   

                
                        if (cbx.Checked)
                        {
                        //check if there is multiple for the same patient 
                        //Label12
                        LinkButton Label12 = rItem.FindControl("Label12") as LinkButton;
                        if (Label12.Text == "")
                        { 


                        //DATE 
                        Label lblapdate = rItem.FindControl("lblapdate") as Label;

                        date = lblapdate.Text ;
                            DateTime test = Convert.ToDateTime((date));
                            date2 = test.ToString("dd-MM-yyyy");
                            //lblapptime
                            Label lblpatient_name = rItem.FindControl("lblapptime") as Label;

                            time2 = lblpatient_name.Text;

                        //Label18 5 patient name 
                        //Label5
                        Label lblpatient_name6 = rItem.FindControl("Label5") as Label;

                        patient_name = lblpatient_name6.Text;
                        //Label4
                        Label lblmobilenumber = rItem.FindControl("Label4") as Label;
                        mobile_number = lblmobilenumber.Text;
                        //
                        Label lbldoctor = rItem.FindControl("Label7") as Label;
                        doctor = lbldoctor.Text;
                        //Label9
                        Label lblstatus = rItem.FindControl("lblappstatus") as Label;

                        status = lblstatus.Text;
                            Label lblappno = rItem.FindControl("lblapno") as Label;
                            appointment_no = lblappno.Text;
                            //

                            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                            DataSet ds = logic.ReturnDataSet("select Clinic_Code from TBL_Appointments where Appointment_No ='"+ appointment_no +"' ");
                            string clinic = ds.Tables[0].Rows[0]["Clinic_Code"].ToString();
                            //Label1
                            //lblapno
                         
                            string Message_text = txttempplate.Text.Replace("{*Patient_Name}", patient_name).Replace("{*Doctor_Name }", doctor).Replace("{*Appointment_Date}", date2).Replace("{*Appointment_Time}", time2).Replace("{*Appointment_Status}", status).Replace("{*Doctor_name}", doctor).Replace("{*Doctor_Name}", doctor).Replace("{*Doctor_Name}", doctor).Replace("{*patient_name}", patient_name).Replace("patient_name",patient_name ).Replace ("doctor_name",doctor).Replace ("Appointment_Status",status).Replace ("appointment_time" ,time2).Replace ("Appointment_Date",date2);





                            //eemsadmin
                              SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ToString());
                            SqlConnection consms = new SqlConnection(ConfigurationManager.ConnectionStrings["EasiSMS"].ToString());

                            try
                            {
                                string s = "select top(1) UserName from aspnet_Users ";
                                SqlDataAdapter da = new SqlDataAdapter(s, consms);
                                DataSet DS = new DataSet();
                                da.Fill(DS);
                                BuissnessLogic.Class1 logic2 = new BuissnessLogic.Class1();
                                string smsuser = logic2.returnEasiSMS_user();

                                try
                                {
                                    //"text", "api", "TEST", 0, 10
                                    var x = service.SendSMS2(smsuser, "p@ssw0rd", mobile_number, patient_name, "4788", Message_text, "text", "api", "TEST", 0, 10);


                                    //insert into sms history table 
                                    try
                                    {




                                        con.Open();





                                        SqlCommand cmd = new SqlCommand();
                                        cmd.Connection = con;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.CommandText = "update TBL_Appointments set Status =@Status where Appointment_No =@Appointment_No  ";
                                        cmd.Parameters.AddWithValue("@Status", "Sent");
                                        cmd.Parameters.AddWithValue("@Appointment_No", appointment_no);
                                        cmd.ExecuteNonQuery();
                                        labelifsent.Text = "Message Sent Successfully";
                                        // now insert in sms history 


                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                    finally
                                    {
                                        con.Close();
                                    }
                                    try
                                    {

                                        con.Open();


                                        SqlCommand cmd = new SqlCommand();
                                        cmd.Connection = con;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.CommandText = "insert into  TBL_SMS_Histroy (Mobile_No ,SMS_Text ,SMS_Type ,Patient_Name ,Doctor_Name,Clinic_Name,Appointment_Code,Appointment_Date,Status,Created_By,Created_On,Arbitary) values (@Mobile_No ,@SMS_Text ,@SMS_Type ,@Patient_Name ,@Doctor_Name,@Clinic_Name,@Appointment_Code,@Appointment_Date,@Status,@Created_By,@Created_On,@Arbitary)  ";
                                        cmd.Parameters.AddWithValue("@Mobile_No", mobile_number);
                                        cmd.Parameters.AddWithValue("@SMS_Text", Message_text);
                                        if (RadioButtonapp_not.Checked)
                                        {
                                            cmd.Parameters.AddWithValue("@SMS_Type", "Appointment Notification");
                                        }
                                        else if (RadioButtonapp_reminder.Checked)
                                        {
                                            cmd.Parameters.AddWithValue("@SMS_Type", "Reminders");
                                        }
                                        else if (RadioButton_notify_cancell.Checked)
                                        {
                                            cmd.Parameters.AddWithValue("@SMS_Type", "Notify Cancellation");
                                        }
                                        else if (RadioButtonconfirm_cancel.Checked)
                                        {
                                            cmd.Parameters.AddWithValue("@SMS_Type", "Confirm Cancellation");
                                        }

                                        cmd.Parameters.AddWithValue("@Patient_Name", patient_name);
                                        cmd.Parameters.AddWithValue("@Doctor_Name", doctor);
                                        cmd.Parameters.AddWithValue("@Clinic_Name", clinic);
                                        //Appointment_Code,Appointment_Date,Status,Created_By,Created_On,Arbitary) values (@Mobile_No ,@SMS_Text ,@SMS_Type ,@Patient_Name ,@Doctor_Name,@Clinic_Name,@Appointment_Code,@Appointment_Date,@Status,@Created_By,@Created_On,@Arbitary)  ";
                                        cmd.Parameters.AddWithValue("@Appointment_Code", appointment_no);
                                        cmd.Parameters.AddWithValue("@Appointment_Date", date2);
                                        cmd.Parameters.AddWithValue("@Status", "Sent");
                                        cmd.Parameters.AddWithValue("@Created_By", Session["username"].ToString());
                                        cmd.Parameters.AddWithValue("@Created_On", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@Arbitary", false);
                                        cmd.ExecuteNonQuery();
                                        labelifsent.Text = "Message Sent Successfully";
                                        // now insert in sms history 


                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                    finally
                                    {
                                        con.Close();
                                    }
                                }
                                catch(Exception ex)
                                {

                                }
                               
                                


                                

                            }
                            //UPDATE STATUS 




                            catch (Exception es)
                            {
                                labelifsent.Text = "SomeThing Went Wrong !";
                            }

                        }
                        else
                        {
                            string date2_case2 = "";
                            string mobile_number_case2 = "";
                            Label lblapdate = rItem.FindControl("lblapdate") as Label;
                            date = lblapdate.Text;
                            DateTime test = Convert.ToDateTime((date));
                            date2_case2 = test.ToString("dd-MM-yyyy");
                            

                            //Label18 5 patient name 
                            //Label5
                          
                            //Label4
                            Label lblmobilenumber = rItem.FindControl("Label4") as Label;
                            mobile_number_case2 = lblmobilenumber.Text;


                            //select to send for both app
                            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();


                            DataSet ds = logic.ReturnDataSet("select * from TBL_Appointments where Appointment_Date= '"+ date2_case2 + "' and MobileNo ='"+ mobile_number_case2 +"' ");
                            for (int x =0; x<= ds.Tables[0].Rows.Count-1;x++)
                            {
                                string appno_case2 = ds.Tables[0].Rows[x]["Appointment_No"].ToString();
                                string time2_case2 = ds.Tables[0].Rows[x]["Appointment_Time"].ToString();
                                string patientname_case2 = ds.Tables[0].Rows[x]["Patient_Name"].ToString();
                                string doctor_case2 = ds.Tables[0].Rows[x]["Doctor_Name"].ToString();
                                string status_case2 = ds.Tables[0].Rows[x]["Appointment_Status"].ToString();
                                BuissnessLogic.Class1 logicc = new BuissnessLogic.Class1();
                                DataSet dsss = logic.ReturnDataSet("select Clinic_Code from TBL_Appointments where Appointment_No ='" + appno_case2 + "' ");
                                string clinic_case2 = dsss.Tables[0].Rows[0]["Clinic_Code"].ToString();

                                string Message_text_case2 = txttempplate.Text.Replace("{*Patient_Name}", patientname_case2).Replace("{*Doctor_Name }", doctor_case2).Replace("{*Appointment_Date}", date2_case2).Replace("{*Appointment_Time}", time2_case2).Replace("{*Appointment_Status}", status_case2).Replace("{*Doctor_name}", doctor_case2).Replace("{*Doctor_Name}", doctor_case2).Replace("{*Doctor_Name}", doctor_case2).Replace("{*patient_name}", patientname_case2).Replace("patient_name", patientname_case2).Replace("doctor_name", doctor_case2).Replace("Appointment_Status", status_case2).Replace("appointment_time", time2_case2).Replace("Appointment_Date", date2_case2);

                                try
                                {
                                    var xx = service.SendSMS2("sql.admin", "p@ssw0rd", mobile_number_case2, patientname_case2, "sq1-Tech", Message_text_case2, "EWAPI", "EW_square1", "Send SMS", 60, 3);
                                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ToString());
                                    try
                                    {
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand();
                                        cmd.Connection = con;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.CommandText = "update TBL_Appointments set Status =@Status where Appointment_No =@Appointment_No  ";
                                        cmd.Parameters.AddWithValue("@Status", "Sent");
                                        cmd.Parameters.AddWithValue("@Appointment_No", appno_case2);
                                        cmd.ExecuteNonQuery();
                                        labelifsent.Text = "Message Sent Successfully";
                                        // now insert in sms history 
                                        try
                                        {
                                            con.Open();
                                            SqlCommand cmd2 = new SqlCommand();
                                            cmd2.Connection = con;
                                            cmd2.CommandType = CommandType.Text;
                                            cmd2.CommandText = "insert into  TBL_SMS_Histroy (Mobile_No ,SMS_Text ,SMS_Type ,Patient_Name ,Doctor_Name,Clinic_Name,Appointment_Code,Appointment_Date,Status,Created_By,Created_On,Arbitary) values (@Mobile_No ,@SMS_Text ,@SMS_Type ,@Patient_Name ,@Doctor_Name,@Clinic_Name,@Appointment_Code,@Appointment_Date,@Status,@Created_By,@Created_On,@Arbitary)  ";
                                            cmd2.Parameters.AddWithValue("@Mobile_No", mobile_number_case2);
                                            cmd2.Parameters.AddWithValue("@SMS_Text", Message_text_case2);
                                            if (RadioButtonapp_not.Checked)
                                            {
                                                cmd.Parameters.AddWithValue("@SMS_Type", "Appointment Notification");
                                            }
                                            else if (RadioButtonapp_reminder.Checked)
                                            {
                                                cmd.Parameters.AddWithValue("@SMS_Type", "Reminders");
                                            }
                                            else if (RadioButton_notify_cancell.Checked)
                                            {
                                                cmd.Parameters.AddWithValue("@SMS_Type", "Notify Cancellation");
                                            }
                                            else if (RadioButtonconfirm_cancel.Checked)
                                            {
                                                cmd.Parameters.AddWithValue("@SMS_Type", "Confirm Cancellation");
                                            }

                                            cmd.Parameters.AddWithValue("@Patient_Name", patientname_case2);
                                            cmd.Parameters.AddWithValue("@Doctor_Name", doctor_case2);
                                            cmd.Parameters.AddWithValue("@Clinic_Name", clinic_case2);
                                            //Appointment_Code,Appointment_Date,Status,Created_By,Created_On,Arbitary) values (@Mobile_No ,@SMS_Text ,@SMS_Type ,@Patient_Name ,@Doctor_Name,@Clinic_Name,@Appointment_Code,@Appointment_Date,@Status,@Created_By,@Created_On,@Arbitary)  ";
                                            cmd.Parameters.AddWithValue("@Appointment_Code", appno_case2);
                                            cmd.Parameters.AddWithValue("@Appointment_Date", date2_case2);
                                            cmd.Parameters.AddWithValue("@Status", "Sent");
                                            cmd.Parameters.AddWithValue("@Created_By", Session["username"].ToString());
                                            cmd.Parameters.AddWithValue("@Created_On", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@Arbitary", false);
                                            cmd.ExecuteNonQuery();
                                            labelifsent.Text = "Message Sent Successfully";
                                            // now insert in sms history 


                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                        finally
                                        {
                                            con.Close();
                                        }


                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                    finally
                                    {
                                        con.Close();
                                    }



                                }
                                //UPDATE STATUS 




                                catch (Exception es)
                                {
                                    labelifsent.Text = "SomeThing Went Wrong !";
                                }

                            }
                        }
                    }
                }
            


            }
            catch (Exception ex)
            {

            }
            Fill_Appointment();

        }


        public void Check_Multiple()
        {

            foreach (GridViewRow row in GridView1.Rows)
            {

                string date = "";
                string patient_code = "";
                if (row.RowType == DataControlRowType.DataRow)
                {





                    date = (row.Cells[4].FindControl("Label2") as Label).Text;



                    //Label18 5 patient name fake 
                    patient_code = (row.Cells[7].FindControl("lblmobnumber") as Label).Text;





                    var service = new WebApplication6.localhost.mySMS_SQLSoapClient();
                    //eemsadmin

                    try
                    {
                        LinkButton button = (row.Cells[3].FindControl("linkbutton1") as LinkButton);
                        //var x = service.SendSMS2("sql.admin", "p@ssw0rd", mobile_number, patient_name, "sq1-Tech", Message_text, "EWAPI", "EW_square1", "Send SMS", 60, 3);
                        BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                        DataSet dss = logic.ReturnDataSet("select Appointment_ID from TBL_Appointments where MobileNo = '" + patient_code + "' and Appointment_Date ='" + date + "'");
                        if (dss.Tables[0].Rows.Count > 1)
                        {
                            // that means that there is multiple appointments 


                            button.Text = "Show All";

                        }
                        else
                        {
                            button.Text = "";

                        }


                    }
                    //UPDATE STATUS 




                    catch (Exception es)
                    {
                        labelifsent.Text = "SomeThing Went Wrong !";
                    }


                }
            }
        }


        public void Check_Multiple_table()
        {

            //

            try
            {

                foreach (RepeaterItem row in repeater_appointment.Items)
                {

                    string date = "";
                    string patient_code = "";


                    Label lbldate = row.FindControl("lblapdate") as Label;
                    Label lblpatient_code = row.FindControl("Label4") as Label;

                    date = lbldate.Text;
                    patient_code = lblpatient_code.Text;



                    var service = new WebApplication6.localhost.mySMS_SQLSoapClient();
                    //eemsadmin

                    try
                    {
                        LinkButton button = row.FindControl("Label12") as LinkButton;

                        //var x = service.SendSMS2("sql.admin", "p@ssw0rd", mobile_number, patient_name, "sq1-Tech", Message_text, "EWAPI", "EW_square1", "Send SMS", 60, 3);
                        BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                        DataSet dss = logic.ReturnDataSet("select Appointment_ID from TBL_Appointments where MobileNo = '" + patient_code + "' and Appointment_Date ='" + date + "'");
                        if (dss.Tables[0].Rows.Count > 1)
                        {
                            // that means that there is multiple appointments 


                            button.Text = "Show All";

                        }
                        else
                        {
                            button.Text = "";

                        }


                    }





                    catch (Exception es)
                    {
                        labelifsent.Text = "SomeThing Went Wrong !";
                    }



                }
            }

            catch (Exception ex)
            {

            }

        }

        protected void btnUpdate_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null && e.CommandArgument != "")
            {

                try
                {
                    string Appno = e.CommandArgument.ToString();
                    string f1 = "";
                    string f2 = "";
                    BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                    DataSet ds = logic.ReturnDataSet("select MobileNo from TBL_Appointments where Appointment_No = '" + Appno + "'");
                    string mobile_no = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    string url = "show_all_.aspx?app_no=" + Appno + "&mobileno=" + mobile_no;
                    Response.Redirect(url, false);



                }
                catch (Exception ex)
                {

                }


            }
        }

        protected void btnUpdate_Click2(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null && e.CommandArgument != "")
            {

                try
                {
                    string iStID = e.CommandArgument.ToString();


                    try
                    {
                        BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                        DataSet ds = logic.ReturnDataSet("select MobileNo from TBL_Appointments where Appointment_No = '" + iStID + "'");
                        string mobile_no = ds.Tables[0].Rows[0]["MobileNo"].ToString();

                        string url = "smshistory.aspx?app_no=" + iStID + "&mobileno=" + mobile_no;
                        Response.Redirect(url, false);


                    }
                    catch (Exception ex)
                    {

                    }


                }
                catch (Exception ex)
                {

                }


            }
        }
        protected void checkbox_onlyduplicate_CheckedChanged(object sender, EventArgs e)
        {
            display_double_booking();

        }

        public void display_double_booking()
        {
            try
            {
                string Doc_code = "";
                string App_date = "";
                string app_time = "";

                
                DataTable dt = new DataTable();
                dt.Columns.Add("Appointment_No", typeof(int));
                dt.Columns.Add("Appointment_Date", typeof(DateTime));
                dt.Columns.Add("Appointment_Time", typeof(string));


                dt.Columns.Add("ENNo", typeof(string));
                dt.Columns.Add("Patient_Name", typeof(string));

                dt.Columns.Add("Appointment_Status", typeof(string));
                dt.Columns.Add("SMSType", typeof(string));
                dt.Columns.Add("Appointment_Type", typeof(string));

                dt.Columns.Add("MobileNo", typeof(string));
                dt.Columns.Add("Doctor_Name", typeof(string));






                dt.Columns.Add("Status", typeof(string));


                dt.Columns.Add("Response", typeof(string));

                dt.Columns.Add("Reponse_Status", typeof(string));


                dt.Columns.Add("Patient_Code", typeof(string));

                if (checkbox_onlyduplicate.Checked)
                {

                    DateTime todayDate = DateTime.Now;

                    // var res = d.ToString("hh:mm tt");   // this show  11:12 Pm
                    // var res2 = todayDate.ToString("HH:mm");  // this show  23:12

                    string datetoday = todayDate.ToString("MM/dd/yyyy HH:mm:ss");
                    DateTime tomorrowDate = todayDate.AddDays(1);
                    string datetomorrow = tomorrowDate.ToString("MM/dd/yyyy HH:mm:ss");

                    txtDatePicker.Text = datetoday;
                    txtDatePicker2.Text = datetomorrow;

                   // DataSet ds = logic.ReturnDataSet("SELECT distinct MobileNo,Appointment_Date FROM TBL_Appointments where Appointment_Date >= '" + datetoday + "' " + " and Appointment_Date <=  '" + datetomorrow + "' order by Appointment_Date desc ");



                    BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                    DataSet ds = logic.ReturnDataSet("  SELECT A.* FROM TBL_Appointments A INNER JOIN(SELECT Doctor_Code, Appointment_Date, Appointment_time FROM TBL_Appointments GROUP BY Doctor_Code, Appointment_Date , Appointment_time HAVING COUNT(*) > 1) B ON A.Doctor_Code = B.Doctor_Code AND A.Appointment_Date = B.Appointment_Date AND A.Appointment_time = B.Appointment_time AND a.Appointment_Date >= '" + datetoday + "' " + " and A.Appointment_Date <=  '" + datetomorrow + "' ");


                  //  DataTable dtt = new DataTable();

                    //for (int x = 0; x <= ds.Tables[0].Rows.Count - 1; x++)
                    //{
                    //    DateTime test = Convert.ToDateTime(ds.Tables[0].Rows[x]["Appointment_Date"]);
                    //    var sqlformattedDate = test.ToString("yyyy-MM-dd HH:mm:ss");

                    //    DataSet dss = logic.ReturnDataSet("select top (10)* from TBL_Appointments where Doctor_Code ='" + ds.Tables[0].Rows[x]["Doctor_Code"] + "' and Appointment_Date ='" + sqlformattedDate + "'  and Appointment_Time = '" + ds.Tables[0].Rows[x]["Appointment_Time"] + "' order by Appointment_Date desc  ");

                    //    //for (int yy = 0; yy <= dss.Tables[0].Rows.Count - 1; yy++)
                    //    //{
                    //        try
                    //        {

                    //            //string p_code = dss.Tables[0].Rows[x]["Patient_Code"].ToString();
                    //            //string res = dss.Tables[0].Rows[x]["Response"].ToString();
                    //            //dt.Rows.Add(dss.Tables[0].Rows[x]["Appointment_No"], dss.Tables[0].Rows[x]["Appointment_Date"], dss.Tables[0].Rows[x]["ENNo"], dss.Tables[0].Rows[x]["Patient_Name"], dss.Tables[0].Rows[x]["MobileNo"].ToString(), dss.Tables[0].Rows[x]["Doctor_Name"].ToString(), dss.Tables[0].Rows[x]["Appointment_Status"].ToString(), dss.Tables[0].Rows[x]["SMSType"].ToString(), dss.Tables[0].Rows[x]["Reponse_Status"].ToString(), res, p_code);



                    //            string res = dss.Tables[0].Rows[0]["Response"].ToString();
                    //            string pa_code = dss.Tables[0].Rows[0]["Patient_Code"].ToString();
                    //            dt.Rows.Add(dss.Tables[0].Rows[0]["Appointment_No"], dss.Tables[0].Rows[0]["Appointment_Date"], dss.Tables[0].Rows[0]["Appointment_Time"], dss.Tables[0].Rows[0]["ENNo"], dss.Tables[0].Rows[0]["Patient_Name"], dss.Tables[0].Rows[0]["Appointment_Status"].ToString(), dss.Tables[0].Rows[0]["SMSType"].ToString(), dss.Tables[0].Rows[0]["Appointment_Type"].ToString(), dss.Tables[0].Rows[0]["MobileNo"].ToString(), dss.Tables[0].Rows[0]["Doctor_Name"].ToString(), dss.Tables[0].Rows[0]["Status"].ToString(), res, dss.Tables[0].Rows[0]["Reponse_Status"].ToString(), pa_code);//
                    //        }
                    //        catch (Exception ex)
                    //        { }

                    //    }





                    // }
                    {


                    }
                    repeater_appointment.DataSource = ds;

                    repeater_appointment.DataBind();


                }
                else
                {
                    Fill_Appointment();
                    Check_Multiple_table();
                }

            }
            catch (Exception ex)
            {


            }
        }



        protected void checkboxall_CheckedChanged(object sender, EventArgs e)
        {

            try
            {


                //at first delete* from clinic_usergroup where usergroup = the selected one 
                bool check = false;

                if (checkboxall.Checked)
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
            catch (Exception ex)
            {

            }

        }

        protected void btncheck_Click(object sender, EventArgs e)
        {

            repeaterdoctor.DataSource = null;
            repeaterdoctor.DataBind();
            DataTable dt3345 = new DataTable();
            dt3345.Columns.Add("Doctor_Name", typeof(string));
            dt3345.Columns.Add("Doctor_Code", typeof(string));


            dt3345.Columns.Add("Doctor_ID", typeof(int));
            foreach (RepeaterItem rItem in repeater_clinics_profile.Items)
            {
             
            CheckBox cbx = rItem.FindControl("checkboxselectttt1") as CheckBox;
                if (cbx != null)
                {
                    if (cbx.Checked)
                    {

                        Label clinic = rItem.FindControl("lblclinic_code1") as Label;
                        string code_clinic = clinic.Text;


                        BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                        string script = "select Doctor_Code,Doctor_Name,Doctor_ID from TBL_DoctorsMaster where Clinic_Code = '" + code_clinic + "'";

                        DataSet ds = logic.ReturnDataSet(script);
                        try
                        {

                            if (ds.Tables[0].Rows.Count > 0)
                            {

                                for (int count = 0; count <= ds.Tables[0].Rows.Count - 1; count++)
                                {

                                    try
                                    {
                                        dt3345.Rows.Add(ds.Tables[0].Rows[count]["Doctor_Name"].ToString(), ds.Tables[0].Rows[count]["Doctor_Code"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[count]["Doctor_ID"]));

                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                  


                                }

                            }


                            //
                        }
                        catch (Exception ex)
                        { }

                    }
                }
            }

            try
            {
                repeaterdoctor.DataSource = dt3345;
                repeaterdoctor.DataBind();


                foreach (RepeaterItem item in repeaterdoctor.Items)
                {
                    CheckBox chbx = item.FindControl("checkboxselectttt1") as CheckBox;
                    if (chbx != null)
                    {
                        chbx.Checked = true;
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void checboxalldocs_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checboxalldocs.Checked)
                {
                    foreach (RepeaterItem i in repeaterdoctor.Items)
                    {


                        //Retrieve the state of the CheckBox
                        CheckBox cb = (CheckBox)i.FindControl("checkboxselectttt1");
                        cb.Checked = true;


                    }
                    
                    }
              else
                    {
                        foreach (RepeaterItem i in repeaterdoctor.Items)
                        {


                            //Retrieve the state of the CheckBox
                            CheckBox cb = (CheckBox)i.FindControl("checkboxselectttt1");
                            cb.Checked = false;


                        }
                    }
              
               


            }
            catch (Exception ex)
            {

            }

        }

        protected void checkboxallappointments_CheckedChanged(object sender, EventArgs e)
        {

            try
            {


                //at first delete* from clinic_usergroup where usergroup = the selected one 
                bool check = false;

                if (checkboxallappointments.Checked)
                {
                    check = true;
                }
                else
                {
                    check = false;
                }

                foreach (RepeaterItem i in repeater_appointment.Items)
                {

                  
                    //Retrieve the state of the CheckBox
                    CheckBox cb = (CheckBox)i.FindControl("checkboxselectttt10");
                    cb.Checked = check;


                }


            }
            catch (Exception ex)
            {

            }

        }
    }
    }



         

         

    


        //protected void chklistClinic_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < chklistDoctors.Items.Count; i++)

        //      chklistDoctors.Items[i].Selected = true;

        //      }





 
 