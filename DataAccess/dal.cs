using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using BussinessObject;


namespace DataAccess
{
    public class Class1
    {

        // create connection and open it 

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ToString());
        SqlConnection consms = new SqlConnection(ConfigurationManager.ConnectionStrings["EasiSMS"].ToString());
        SqlCommand cmd;
        public void openconnection() // passing Bussiness object Here  
        {
            
            try
            {

                con.Open();

            }
            catch
            {

            }

        }

        public bool add_user_clinic (user_clinic user_clinic)
        {
            bool status = false;
            cmd = new SqlCommand("insert into TBL_UserLinkClinics (Staff_ID,Clinic_Code,Created_By,Created_On) values (@Staff_ID,@Clinic_Code,@Created_By,@Created_On)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Staff_ID", user_clinic.staff_id);
            cmd.Parameters.AddWithValue("@Clinic_Code", user_clinic.clinic_code);
            cmd.Parameters.AddWithValue("@Created_By", user_clinic.created_by);
            cmd.Parameters.AddWithValue("@Created_On", user_clinic.created_on);
 
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        public bool add_user_profile(User_profile user_profilr)
        {
            bool status = false;
            cmd = new SqlCommand("insert into User_Profile (Group_ID,Clinic_Code) values (@Group_ID,@Clinic_Code)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Group_ID", user_profilr.Group_ID);
            cmd.Parameters.AddWithValue("@Clinic_Code", user_profilr.cllinic_code);
      

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }

        public bool add_template_profile(Template_Group Template_Group)
        {
            bool status = false;
            cmd = new SqlCommand("insert into Template_UserGroupp (GroupID,TemplateCode,Template_Description,Template_ID,Template_Name) values (@GroupID,@TemplateCode,@Template_Description,@Template_ID,@Template_Name" +
")", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@GroupID", Template_Group.groupID);
            cmd.Parameters.AddWithValue("@TemplateCode", Template_Group.templateCode);
            //Template_Description
            cmd.Parameters.AddWithValue("@Template_Description", Template_Group.template_Description);
            cmd.Parameters.AddWithValue("@Template_ID", Template_Group.Template_ID);
            //Template_ID,Template_Name

            
            cmd.Parameters.AddWithValue("@Template_Name", Template_Group.Template_Name);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }
        public bool add_user_clinic_modified(user_clinic user_clinic)
        {
            bool status = false;
            cmd = new SqlCommand("insert into TBL_UserLinkClinics (Staff_ID,Clinic_Code,Modified_By,Mmodified_On) values (@Staff_ID,@Clinic_Code,@Modified_By,@Mmodified_On)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Staff_ID", user_clinic.staff_id);
            cmd.Parameters.AddWithValue("@Clinic_Code", user_clinic.clinic_code);
            cmd.Parameters.AddWithValue("@Modified_By", user_clinic.modified_by);
            cmd.Parameters.AddWithValue("@Mmodified_On", user_clinic.modified_on);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }

        public bool add_arbitary_sms(shistory  sms)
        {
            bool status = false;
            cmd = new SqlCommand("insert into TBL_SMS_Histroy (Mobile_No,SMS_Text,SMS_Type,Status,Status_Description ,Created_By,Created_On,Arbitary,Patient_Name) values (@Mobile_No,@SMS_Text,@SMS_Type,@Status,@Status_Description ,@Created_By,@Created_On,@Arbitary,@Patient_Name)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Mobile_No", sms.mobile_no);
            cmd.Parameters.AddWithValue("@SMS_Text", sms.sms_text);
            cmd.Parameters.AddWithValue("@SMS_Type", sms.sms_type);
            cmd.Parameters.AddWithValue("@Status", sms.status);
         
            cmd.Parameters.AddWithValue("@Status_Description", sms.status_description);
            cmd.Parameters.AddWithValue("@Created_By", sms.created_by);
            cmd.Parameters.AddWithValue("@Created_On", sms.created_on);
            cmd.Parameters.AddWithValue("@Arbitary", true);
            //Patient_Name 
            cmd.Parameters.AddWithValue("@Patient_Name",sms.patient_name);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        //add user group 
        public bool add1_User1_Group(UserGroup group)
        {
            bool status = false;
            cmd = new SqlCommand("insert into TBL_UserGroupMaster (UG_Name,Comments,UG_Status,Created_By,Created_Date ) values (@UG_Name,@Comments,@UG_Status,@Created_By,@Created_Date )", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UG_Name", group.UGName);
            cmd.Parameters.AddWithValue("@Comments", group.comment);
            cmd.Parameters.AddWithValue("@UG_Status", group.status);
            cmd.Parameters.AddWithValue("@Created_By", group.createdBy);

            cmd.Parameters.AddWithValue("@Created_Date", group.createddate);
           
            //Patient_Name 
         
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }
        public bool Update_Response_Status(Appointment App)
            
        {
            bool status = false;
            cmd = new SqlCommand("update TBL_Appointments set Reponse_Status = @Reponse_Status where Appointment_No =@Appointment_No ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Reponse_Status", App.Response_status);
            cmd.Parameters.AddWithValue("@Appointment_No", App.App_no);
          
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }
        public bool Update_Response_Status_for_show_all(Appointment App)

        {
            bool status = false;
            cmd = new SqlCommand("update TBL_Appointments set Reponse_Status = @Reponse_Status , Response =@Response ,Comments =@Comments where Appointment_No =@Appointment_No ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Reponse_Status", App.Response_status);
            cmd.Parameters.AddWithValue("@Response", App.Response);
            cmd.Parameters.AddWithValue("@Comments", App.comment);
            cmd.Parameters.AddWithValue("@Appointment_No", App.App_no);


            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }

        public bool delete_existing_user_details ( int  Staff_ID)

        {
            bool status = false;
            cmd = new SqlCommand("delete from TBL_UserLinkClinics where Staff_ID  = " + Staff_ID, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Staff_ID", Staff_ID);
            
        


            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }



        

            public bool delete_template_profile(int user_group_id)

        {
            bool status = false;
            cmd = new SqlCommand("delete from Template_UserGroupp where GroupID  = " + user_group_id, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            int res = cmd.ExecuteNonQuery();

            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        public bool delete_user_profile(int user_group_id)

        {
            bool status = false;
            cmd = new SqlCommand("delete from User_Profile where Group_ID  = " + user_group_id, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            int res = cmd.ExecuteNonQuery();

            con.Close();
            if (res > 0)
            {
                status = true;
            }
            return status;
        }


        public string  get_EasiSMS_user()
        {
            string easisms_user = "";
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EasiSMS"].ToString());
            try
            {
               // con.Open();

                SqlDataAdapter adapt = new SqlDataAdapter("select top (1) UserName from  EW_tblUsersSMSUsage where IsDeleted =0 ", con);
                adapt.Fill(ds);
                if (ds.Tables[0].Rows.Count >0)
                {
                    easisms_user = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                else
                {
                    easisms_user = "";
                }
               // con.Close();
                return easisms_user;





            }
            catch
            {

            }
            finally
            {
                con.Close();



            }

      return easisms_user;


        }
        public void ocloseconnection() // passing Bussiness object Here  
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ToString());
            try
            {

                con.Close();

            }
            catch
            {

            }

        }



        public DataSet  Get_dataset (string select ) // passing Bussiness object Here  
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ToString());
            //try
            //{
                con.Open();
                
                SqlDataAdapter adapt = new SqlDataAdapter(select, con);
                adapt.Fill(ds);
                con.Close();
                return ds;




         

            //}
            //catch
            //{

            //}
            //finally
            //{
                
         
               

            //}

           // return ds;
        }


    }
}
