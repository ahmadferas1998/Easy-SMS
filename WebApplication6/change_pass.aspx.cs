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
    public partial class change_pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login_test.aspx", false);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        
{
            if (Session["username"] != null)
            {


                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds = logic.ReturnDataSet("select Staff_Id from TBL_UserMaster where Staff_UserID ='" + Session["username"] + "' and Staff_Password = '" + txtcurrentpassword.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);


                    try
                    {


                        SqlCnn.Open();

                        SqlCommand SqlCmd = new SqlCommand("update TBL_UserMaster set Staff_Password=@Staff_Password where Staff_UserID=@Staff_UserID", SqlCnn);
                        SqlCmd.Parameters.Add("@Staff_Password", txtnewpassword.Text);

                        SqlCmd.Parameters.Add("@Staff_UserID", Session["username"].ToString());
                        SqlCmd.ExecuteNonQuery();
                        FormsAuthentication.SignOut();
                        Session.Clear();
                        Response.Redirect("login_test.aspx", true);



                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        SqlCnn.Close();

                    }
                }
                else
                {
                    lblincorrectpass.Text = "Incorrect Password !";
                }
            }
           
        }
    }
     
}