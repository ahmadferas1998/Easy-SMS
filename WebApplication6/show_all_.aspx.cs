using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using BuissnessLogic;
using System.Globalization;

namespace AmHospital
{
    public partial class show_all_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (Session["username"] == null)
                {
                    Response.Redirect("login_test.aspx", false);
                }
                else
                {
                    if (!Page.IsPostBack)
                    {

                        if (Request.QueryString["app_no"] != null && (Request.QueryString["mobileno"] != null))
                        {
                            string f1 = "";
                            string f2 = "";
                            Session["mno"] = Request.QueryString["mobileno"];
                            Edit_show_all(Request.QueryString["mobileno"], f1, f2);
                        }
                        else { Response.Redirect("default.aspx", false); }

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

            public void Edit_show_all(string mobile_num, string f1, string f2)
            {
                //get the data from table appointment

                try
                {

                    BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                    DataSet ds = logic.ReturnDataSet("select * from TBL_Appointments where MobileNo = '" + mobile_num + "'" + " " + f1 + " " + f2);
                    cpRepeater.DataSource = ds;
                    cpRepeater.DataBind();

                }
                catch (Exception ex)
                {

                }



            }


            protected void btn_filter_showall_Click(object sender, EventArgs e)
            {


                filter_repeater();
            }
            public void filter_repeater()
            {
                string filter1 = "";
                string filter2 = "";
                //check date 
                string ss = date3.Value.ToString();

                try
                {
                    if (ss != null && ss != "")
                    {

                        DateTime d1 = DateTime.ParseExact(ss, "dd/MM/yyyy",
                                CultureInfo.InvariantCulture);

                        if (date3.Value != null && date3.Value != "")
                        {
                            filter1 = "and Appointment_Date =  '" + d1 + "'";

                        }
                        else
                        { filter1 = ""; }

                    }



                    try
                    {


                        if (txtmobnumber.Text.Replace(" ", "") != string.Empty)
                        {
                            filter2 = "and MobileNo like  '%" + txtmobnumber.Text + "%'";


                        }
                        else
                        { filter2 = ""; }

                        //here 

                        Edit_show_all(Session["mno"].ToString(), filter1, filter2);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                catch (Exception ex)
                {

                }

            }
            protected void btndone_Click(object sender, EventArgs e)
            {

                labelcheck.Text = "";
                foreach (RepeaterItem i in cpRepeater.Items)
                {


                    //Retrieve the state of the CheckBox
                    CheckBox cb = (CheckBox)i.FindControl("checkboxconfirm");
                    CheckBox cb2 = (CheckBox)i.FindControl("checkboxcancel");
                    if (cb.Checked)
                    {
                        try
                        {

                            Appointment app = new Appointment();
                            Label app_no = (Label)i.FindControl("lblapp_no");
                            string appointment_no = app_no.Text;
                            string App_no = app_no.Text;
                            TextBox comment = (TextBox)i.FindControl("textboxcomment");
                            string comm = comment.Text;
                            app.comment = comm;
                            app.Response_status = "Confirm";
                            app.App_no = appointment_no;
                            app.Response = "Y";
                            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                            logic.Update_Response_Status_for_show_all(app);
                            labelcheck.ForeColor = System.Drawing.Color.Green;
                            labelcheck.Text = "Saved Successfully";

                        }
                        catch (Exception ex)
                        {
                            labelcheck.ForeColor = System.Drawing.Color.Red;
                            labelcheck.Text = "Something  Went Wrong !!";


                        }
                        //Retrieve the value associated with that CheckBox





                        //Now we can use that value to do whatever we want

                    }
                    else if (cb2.Checked)
                    {
                        try
                        {
                            Appointment app = new Appointment();
                            Label app_no = (Label)i.FindControl("lblapp_no");
                            string App_no = app_no.Text;
                            TextBox comment = (TextBox)i.FindControl("textboxcomment");
                            string comm = comment.Text;
                            app.comment = comm;
                            app.Response_status = "Cancel";
                            app.App_no = App_no;
                            app.Response = "N";
                            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                            logic.Update_Response_Status_for_show_all(app);
                            labelcheck.ForeColor = System.Drawing.Color.Green;
                            labelcheck.Text = "Saved Successfully";
                        }
                        catch (Exception ex)
                        {
                            labelcheck.ForeColor = System.Drawing.Color.Red;
                            labelcheck.Text = "Something  Went Wrong !!";

                        }
                        //Retrieve the value associated with that CheckBox



                    }
                }

                filter_repeater();
            }


        }
    }
