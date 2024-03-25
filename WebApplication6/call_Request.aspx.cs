using BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmHospital
{
    public partial class call_Request : System.Web.UI.Page
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
                    Fill_Repeater("", "");

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


        protected void GetValue(object sender, EventArgs e)
        {
           
            //Reference the Repeater Item using Button.
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

            //Reference the Label and TextBox.

            




            string Appointment_No = (item.FindControl("lblapp_no") as Label).Text;
            string comment_str = (item.FindControl("textboxcomment") as TextBox).Text;

          CheckBox checkbox_confirm  = item.FindControl("checkboxconfirm") as CheckBox;
            CheckBox checkbox_cancel = item.FindControl("checkboxcancel") as CheckBox;
            string confirm_reject; 
            if (checkbox_confirm.Checked)
            {

                try
                {

                    Appointment app = new Appointment();
                    
                    
                
                  
                    app.comment = comment_str;
                    app.Response_status = "Confirm";
                    app.App_no = Appointment_No;
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
              

            }
            else if (checkbox_cancel.Checked)
            {

                try
                {

                    Appointment app = new Appointment();


                    //app.Response_status = "Cancel";
                    //app.App_no = App_no;
                    //app.Response = "N";

                    app.comment = comment_str;
                    app.Response_status = "Cancel";
                    app.App_no = Appointment_No;
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

            }

            filter_repeater();
           // Fill_Repeater("", "");

        }
        protected void btn_filter_showall_Click(object sender, EventArgs e)
        {


            filter_repeater();
        }
        public void filter_repeater()
        {
            string filter1 = "";
            string filter2 = "";
            //check date try
            try
            {

                string ss = date3.Value.ToString();


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




                if (txtmobnumber.Text.Replace(" ", "") != string.Empty)
                {
                    filter2 = "and MobileNo like  '%" + txtmobnumber.Text + "%'";


                }
                else
                { filter2 = ""; }

            }
            catch (Exception ex)
            {


            }

            //here 

            Fill_Repeater(filter1, filter2);


        }

        public void Fill_Repeater(string filter1, string filter2)
        {
            try
            {

                DateTime todayDate = DateTime.Now;

                // var res = d.ToString("hh:mm tt");   // this show  11:12 Pm
                // var res2 = todayDate.ToString("HH:mm");  // this show  23:12

                string datetoday = todayDate.ToString("MM/dd/yyyy HH:mm:ss");
                DateTime tomorrowDate = todayDate.AddDays(1);
                string datetomorrow = tomorrowDate.ToString("MM/dd/yyyy HH:mm:ss");


                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds = logic.ReturnDataSet("select * from TBL_Appointments where Reponse_Status ='CALL REQUEST' and Appointment_Date >= '" + datetoday + "' " + " and Appointment_Date <=  '" + datetomorrow + "'  " + " " + filter1 + " " + filter2 + " " + "order by Appointment_Date desc ");

                cpRepeater.DataSource = ds;
                cpRepeater.DataBind();
            }
            catch (Exception ex)
            {

            }

        }

        protected void btndone_Click(object sender, EventArgs e)
        {

            labelcheck.Text = "";
            try
            {
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
            catch (Exception ex)
            {

            }
        }
    }
}