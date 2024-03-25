using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmHospital
{
    public partial class smshistory : System.Web.UI.Page
    {
        
            protected void Page_Load(object sender, EventArgs e)
            {

                if (!Page.IsPostBack)
                {

                    if (Request.QueryString["app_no"] != null && Request.QueryString["mobileno"] != null)
                    {
                        //mobileno
                        FILL_SMShISTORY(Request.QueryString["mobileno"]);
                    }
                    else

                    {

                        Response.Redirect("default.aspx", false);

                    }
                }
            }

            protected void btnOK_Click(object sender, EventArgs e)
            {
                try
                {
                    Response.Redirect("default.aspx", false);
                }
                catch (Exception ex)
                {

                }
            }

            public void FILL_SMShISTORY(string mobile_num)
            {
                try
                {
                    BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                    DataSet ds = logic.ReturnDataSet("select *  from TBL_SMS_Histroy where Mobile_No = '" + mobile_num + "' order by Created_On desc");
                    cpRepeater.DataSource = ds;
                    cpRepeater.DataBind();


                }
                catch (Exception ex)
                {

                }
            }

        }
    }
