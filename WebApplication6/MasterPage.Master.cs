using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;

namespace AmHospital
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
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

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            //sign out 
           



             
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("login_test.aspx", true);

        }
    }
}