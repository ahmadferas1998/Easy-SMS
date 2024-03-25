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
using DataAccess;
using BussinessObject;


namespace BuissnessLogic
{
    public class Class1
    {
        
        public DataSet ReturnDataSet (string sel_statement)

        {
            DataSet ds = new DataSet();
            //try
            //{
                DataAccess.Class1 cl = new DataAccess.Class1();
                return cl.Get_dataset(sel_statement);
            //}
            //catch (Exception ex)

            //{

            //}
            //finally
            //{

              
               
            //}

           // return ds;

        }

        public string returnEasiSMS_user()
        {
            string username = "";
            try
            {
                DataAccess.Class1 cl = new DataAccess.Class1();
               username = cl.get_EasiSMS_user();
                return username;
            }
            catch (Exception ex)

            {
                return username;

            }
            finally
            {

                

            }

            


        }


        public bool add_arbitary_sms(BussinessObject.shistory sms)
        {
            DataAccess.Class1 cl = new DataAccess.Class1();
            bool status = false;
           status =  cl.add_arbitary_sms(sms);
            return status;
        }

        public bool add_user_group(UserGroup usergroup)
        {
            try
            {
                DataAccess.Class1 cl = new DataAccess.Class1();
                bool status = false;
                status = cl.add1_User1_Group(usergroup);
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool add_user_clinic(user_clinic user_clinic)
        {
            try
            {
                DataAccess.Class1 cl = new DataAccess.Class1();
                bool status = false;
                status = cl.add_user_clinic(user_clinic);
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public bool add_user_profile(User_profile user_profile)
        {
            try
            {
                DataAccess.Class1 cl = new DataAccess.Class1();
                bool status = false;
                status = cl.add_user_profile(user_profile);
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }

        }



        public bool add_utemplate_profile(Template_Group template_group)
        {
            try
            {
                DataAccess.Class1 cl = new DataAccess.Class1();
                bool status = false;
                status = cl.add_template_profile(template_group);
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool add_user_clinic_modified(user_clinic user_clinic)
        {
            try
            {
                DataAccess.Class1 cl = new DataAccess.Class1();
                bool status = false;
                status = cl.add_user_clinic_modified(user_clinic);
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool delete_user_details_clinic(int  staff_id)
        {
            try
            {
                DataAccess.Class1 cl = new DataAccess.Class1();
                bool status = false;
                status = cl.delete_existing_user_details(staff_id);
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool delete_user_profile(int group_id)
        {
            try
            {
                DataAccess.Class1 cl = new DataAccess.Class1();
                bool status = false;
                status = cl.delete_user_profile(group_id);
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool delete_template_profile(int group_id)
        {
            try
            {
                DataAccess.Class1 cl = new DataAccess.Class1();
                bool status = false;
                status = cl.delete_template_profile(group_id);
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        

        public bool Update_Response_Status(Appointment App)
        {
            DataAccess.Class1 cl = new DataAccess.Class1();
            bool status = false;
            status = cl.Update_Response_Status(App);
            return status;
        }
        //Update_Response_Status_for_show_all

        public bool Update_Response_Status_for_show_all(Appointment App)
        {
            DataAccess.Class1 cl = new DataAccess.Class1();
            bool status = false;
            status = cl.Update_Response_Status_for_show_all(App);
            return status;
        }
    }
}
