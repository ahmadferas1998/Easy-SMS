using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using BuissnessLogic;

namespace AmHospital
{
    public partial class arbitary_msg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                Fill_repeater();
               Fill_patient();
            }

        }

        public void Fill_patient()
        {
            ddlpatient.Items.Clear();

            try
            {
                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                DataSet ds = logic.ReturnDataSet("select  distinct Patient_Code, Patient_Name , Appointment_Date from TBL_Appointments order by Appointment_Date desc  ");
                ListItem li2 = new ListItem();
                li2.Text = "----Select Patient----";
                li2.Value = "0";
                ddlpatient.Items.Add(li2);

                for (int x = 0; x <= 100 ; x++)
                {
                    ListItem li = new ListItem();
                    li.Value = ds.Tables[0].Rows[x]["Patient_Code"].ToString();
                    li.Text = ds.Tables[0].Rows[x]["Patient_Name"].ToString();
                    ddlpatient.Items.Add(li);
                }
            }
            catch (Exception ex)
            {

            }

        }


        public void Fill_repeater()
        {

            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
            DataSet ds = logic.ReturnDataSet("select top (100) * from TBL_SMS_Histroy where Arbitary =1  order by Created_On asc");
            cpRepeater.DataSource = ds;
            cpRepeater.DataBind();


        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            labelcheck.Text = "";


            // get the sms username at first 
            string recipient_name = "rec";
            if (txtrecipient.Text.Replace(" ", "") != string.Empty)
            {
                recipient_name = txtrecipient.Text;
            }
            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
            string smsuser = ConfigurationManager.AppSettings["ahd_admin"];
           // string smsuser = "ahd.admin";
            if (smsuser != "")
            {


                var service = new WebApplication6.localhost.mySMS_SQLSoapClient();
                //eemsadmin


                try
                {
                    bool check = false;
                    try
                    {
                        //Update By Ahmad Abuabdo 03/2023
                        string Password = ConfigurationManager.AppSettings["Password"];
                        string SenderId = ConfigurationManager.AppSettings["SenderId"];
                        var x = service.SendSMS2(smsuser, Password, txtmobile_no.Text.Replace (" ",""), recipient_name, SenderId, txtmessagetext.Text, "text", "api", "TEST", 0, 10);
                        //Update By Ahmad Abuabdo 03/2023
                        check = true;
                    }
                    catch (Exception ex) { }


                    // now add the record to sms history table 
                    shistory sms = new shistory();
                    if (ddlpatient.SelectedValue != "0")
                    {

                        sms.patient_name = ddlpatient.SelectedItem.Text;

                    }
                    else
                    {
                        sms.patient_name = "";
                    }

                    sms.mobile_no = txtmobile_no.Text.Replace(" ", "");
                    sms.sms_text = txtmessagetext.Text;
                    sms.sms_type = "Arbitary";
                    if (check)
                    {
                        sms.status = "Sent";
                    }
                    else
                    {
                        sms.status = "Not Sent";
                    }
                    sms.status_description = "Sent Arbitary message";
                    sms.created_by = Session["username"].ToString();
                    sms.created_on = DateTime.Now;
                    BuissnessLogic.Class1 logic2 = new BuissnessLogic.Class1();

                    bool check_if_sent = logic2.add_arbitary_sms(sms);
                    if (check_if_sent)
                    {
                        labelcheck.ForeColor = System.Drawing.Color.Green;

                        labelcheck.Text = "Saved Successfully";

                    }
                    else
                    {
                        labelcheck.ForeColor = System.Drawing.Color.Red;
                        labelcheck.Text = "SomeThing Wen Wrong PLease Contact Support !!";


                    }






                }
                catch (Exception ex)
                {
                    labelcheck.ForeColor = System.Drawing.Color.Red;
                    labelcheck.Text = "SomeThing Went Wrong PLease Contact Support !!";

                }


            }
            //send the sms and add record to the sms history table 
            Fill_repeater();
        }

        protected void lnkbutton_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;

        }
    }
}