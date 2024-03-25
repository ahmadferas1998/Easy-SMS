using BussinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmHospital
{
    public partial class login_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           // if (!Page.IsPostBack)

            {
                 
         }
        }


       

        private bool ValidateUser(string userName, string passWord)
        {
            SqlConnection conn;
            SqlCommand cmd;
            string lookupPassword = null;

            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
            {
                System.Diagnostics.Trace.WriteLine("Input validation of userName failed!");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed!");
                return false;
            }

            //try
            //{
                // Consult with your SQL Server administrator for an appropriate connection
                // string to use to connect to your local SQL Server.
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);
                conn.Open();

                // Create SqlCommand to select pwd field from users table given supplied userName.
                cmd = new SqlCommand("Select Staff_Password ,Staff_UserID,Group_ID  from TBL_UserMaster where Staff_UserID=@Staff_UserID ", conn);
                cmd.Parameters.Add("@Staff_UserID", SqlDbType.VarChar, 50);
                cmd.Parameters["@Staff_UserID"].Value = userName;

                



                // Execute command and fetch pwd field into lookupPassword string.
                lookupPassword = (string)cmd.ExecuteScalar();

                // Cleanup command and connection objects.
                cmd.Dispose();
                conn.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    // Add error handling here for debugging.
            //    // This error message should not be sent back to the caller.
            //    System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            //}

            // If no password found, return false.
            if (null == lookupPassword)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            if (String.Equals(lookupPassword, passWord))

            {
                //

                return true;

            }
            else

            { return false; }


        }



       

        protected void btnlogin_Click1(object sender, EventArgs e)
        {
            string x = "test";
            lblwrongpass.Visible = true;
            if (ValidateUser(txtusername.Text, txtpassword.Text))
            {

                //get the groupid 
                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds =   logic.ReturnDataSet("select Group_ID,Staff_ID  from TBL_UserMaster where  Staff_UserID ='" + txtusername.Text + "'");
                int group_id = Convert.ToInt32(ds.Tables[0].Rows[0]["Group_ID"]);
                DataSet dss= logic.ReturnDataSet("select UG_Name from TBL_UserGroupMaster where  UG_ID ="+ group_id );
                string group_id_str = dss.Tables[0].Rows[0]["UG_Name"].ToString();
                int staffID = Convert.ToInt32(ds.Tables[0].Rows[0]["Staff_ID"]);
                Session["Group_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Group_ID"]);
                //Staff_ID
                Session["group_id_str"] = group_id_str;
                Session["Staff_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Staff_ID"]);


                User USER = new User();
                USER.username = txtusername.Text;
                USER.password = txtpassword.Text;
                Session["username"] = USER.username;



                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, txtusername.Text, DateTime.Now,
          DateTime.Now.AddMinutes(30), CheckBox1.Checked, "your custom data");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (CheckBox1.Checked)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "default.aspx";
                Response.Redirect(strRedirect, true);
            }
            else

                lblwrongpass.Text = "Wrong Username Or Password !!";
            lblwrongpass.Visible = true;
           

            //LogOut '
        }
    }
}