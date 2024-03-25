using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmHospital
{
    public partial class Clinics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindRepeater();
                

            }
        }

        BussinessObject.clinic clinic  = new BussinessObject.clinic();
       
        protected void btnUpdate_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null && e.CommandArgument != "")
            {

                clinic.Clinic_ID = Convert.ToInt32(e.CommandArgument);
                Session["testclin"] = clinic.Clinic_ID;
                Edit(clinic.Clinic_ID);

                panel2.Visible = true;
                panel1.Visible = false;



            }
        }

        public void Edit(int id)
        {
            lblcheck.Text = "";
            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
            DataSet ds = logic.ReturnDataSet("select * from TBL_ClinicsMaster where Clinic_ID = " + id);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Clinic_Name"]))
                    {
                        txtclinicName.Text = ds.Tables[0].Rows[0]["Clinic_Name"].ToString();


                    }
                    else { txtclinicName.Text = ""; }

                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Clinic_Description"]))
                    {
                        txtclinicdescription.Text = ds.Tables[0].Rows[0]["Clinic_Description"].ToString();


                    }
                    else
                    {
                        txtclinicdescription.Text = "";
                    }

                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Clinic_Code"]))
                    {
                        try
                        {
                            txtcliniccode.Text = ds.Tables[0].Rows[0]["Clinic_Code"].ToString();
                        }
                        catch (Exception ex)
                        {

                        }


                    }
                    else
                    { txtcliniccode.Text = ""; }





                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Clinic_Status"]))
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["Clinic_Status"]) == 1)

                        {
                            Activeedit.Checked = true;

                        }
                        else
                        { Activeedit.Checked = false; }


                    }
                    else
                    { Activeedit.Checked = false; }

                }

            }
            catch (Exception ex)
            {


            }

        }
      

        private void BindRepeater()
        {

            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();

            DataSet dt = logic.ReturnDataSet("select * from TBL_ClinicsMaster ");


            cpRepeater.DataSource = dt;
            cpRepeater.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            lblcheck.Text = "";

            SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);
            try
            {
                int num = Convert.ToInt32(Session["testclin"]);

                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
              DataSet DS =   logic.ReturnDataSet("select Clinic_ID from TBL_ClinicsMaster where Clinic_Code =  '" + txtcliniccode.Text + "' and Clinic_ID != "+ num);
               if (DS.Tables[0].Rows.Count  ==0)
                { 
                if (Session["testclin"] != null)
                {
                    SqlCommand SqlCmd = new SqlCommand("update TBL_ClinicsMaster set Clinic_Code=@Clinic_Code, Clinic_Name=@Clinic_Name,Clinic_Description =@Clinic_Description,Modified_By=@Modified_By ,Modified_On =@Modified_On, Clinic_Status=@Clinic_Status where Clinic_ID=@Clinic_ID", SqlCnn);
                    SqlCmd.Parameters.Add("@Clinic_Code", txtcliniccode.Text);
                    SqlCmd.Parameters.Add("@Clinic_Name", txtclinicName.Text);
                    SqlCmd.Parameters.Add("@Clinic_Description", txtclinicdescription.Text);
                   

                    SqlCmd.Parameters.Add("@Modified_By", Session["username"].ToString());

                    SqlCmd.Parameters.Add("@Modified_On", DateTime.Now);
                    //Clinic_Status
                    if (Activeedit.Checked)
                    {
                        SqlCmd.Parameters.Add("@Clinic_Status", true);
                    }
                    else
                    {
                        SqlCmd.Parameters.Add("@Clinic_Status", false);
                    }

                    SqlCmd.Parameters.Add("@Clinic_ID", Convert.ToInt32(Session["testclin"]));

                    //Session["test"]

                    try
                    {
                        SqlCnn.Open();
                        SqlCmd.ExecuteNonQuery();
                        lblcheck.Text = "Saved Successfully";

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        lblcheck.Text = "Some Thing Went Wrong Please Contact Support !!";
                    }
                    finally
                    {

                        SqlCnn.Close();
                    }


                }
                }
               else
                {
                    lblcheck.Text = "Clinic Code was Found !! Plaese insert another one ";
                }
            }
            catch (Exception ex)
            {


            }


        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            BindRepeater();
            Session.Remove("testclin");
            panel2.Visible = false;
            panel1.Visible = true;


        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            txtclinicname2.Text = "";
            txtclinicdescription2.Text = "";

            txtcliniccode2.Text = "";
            Label1.Text = "";
        }

        protected void btnAddsave_Click(object sender, EventArgs e)
        {


            Label1.Text = "";

            SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);

            BuissnessLogic.Class1 logic2 = new BuissnessLogic.Class1();
            DataSet DS = logic2.ReturnDataSet("select Clinic_ID from TBL_ClinicsMaster where Clinic_Code =  '" + txtcliniccode2.Text + "' ");
            if (DS.Tables[0].Rows.Count == 0)
            {
                try
                {
                    //get the last id 
                    int number = 0;

                    BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();



                    SqlCommand SqlCmd = new SqlCommand("insert into  TBL_ClinicsMaster (Clinic_Code,Clinic_Name,Clinic_Description,Created_By,Created_On,Clinic_Status)  values (@Clinic_Code,@Clinic_Name,@Clinic_Description,@Created_By,@Created_On,@Clinic_Status)", SqlCnn);

                    try
                    {




                        SqlCmd.Parameters.Add("@Clinic_Code", txtcliniccode2.Text);
                        SqlCmd.Parameters.Add("@Clinic_Name", txtclinicname2.Text);
                        SqlCmd.Parameters.Add("@Clinic_Description", txtclinicdescription2.Text);
                        //Session["username"].ToString()


                        SqlCmd.Parameters.Add("@Created_By", Session["username"].ToString());

                        SqlCmd.Parameters.Add("@Created_On", DateTime.Now);
                        //
                        if (activeAdd.Checked)
                        {
                            SqlCmd.Parameters.Add("@Clinic_Status", true);
                        }
                        else
                        {
                            SqlCmd.Parameters.Add("@Clinic_Status", false);

                        }
                    }



                    catch (Exception ex)
                    {

                    }


                    //Session["test"]

                    try
                    {
                        SqlCnn.Open();
                        SqlCmd.ExecuteNonQuery();
                        Label1.Text = "Saved Successfully";

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        Label1.Text = "Some Thing Went Wrong Please Contact Support !!";
                    }

                    finally
                    {

                        SqlCnn.Close();
                    }


                }

                catch (Exception ex)
                {


                }
            }
else
            {
                Label1.Text = "Clinic code was found !! Please insert another ";
            }
       


        }

        protected void btnCancelsave_Click(object sender, EventArgs e)
        {
            BindRepeater();
            panel3.Visible = false;
            panel1.Visible = true;
        }

      
    }
}