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
    public partial class doctors : System.Web.UI.Page
    {
        BussinessObject.doctor doctor = new BussinessObject.doctor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("default.aspx", false);
            }

            else


            if (!Page.IsPostBack)
            {
                BindRepeater();
                Fill_DropdownList();

            }
        }
    
        protected void btnUpdate_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null && e.CommandArgument != "")
            {

                doctor.Doctor_ID = Convert.ToInt32(e.CommandArgument);
                Session["testdoc"] = doctor.Doctor_ID;
                
                Edit(doctor.Doctor_ID);

                panel2.Visible = true;
                panel1.Visible = false;



            }
        }

        public void Edit(int id)
        {
            lblcheck.Text = "";
            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
            DataSet ds = logic.ReturnDataSet("select * from TBL_DoctorsMaster where Doctor_ID = " + id);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Doctor_Name"]))
                    {
                        txtdoctorName.Text = ds.Tables[0].Rows[0]["Doctor_Name"].ToString();


                    }
                    else
                    {
                        txtdoctorName.Text = "";
                    }

                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Doctor_Description"]))
                    {
                        txtdoctordescription.Text = ds.Tables[0].Rows[0]["Doctor_Description"].ToString();


                    }
                    else
                    { txtdoctordescription.Text = ""; }

                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Clinic_Code"]))
                    {
                        try
                        {
                            ddlcliniccode.SelectedValue = ds.Tables[0].Rows[0]["Clinic_Code"].ToString();
                        }
                        catch (Exception ex)
                        {

                        }


                    }


                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Doctor_Code"]))
                    {
                        txtDoctorcode.Text = ds.Tables[0].Rows[0]["Doctor_Code"].ToString();


                    }
                    else
                    { txtDoctorcode.Text = ""; }

                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Status"]))
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) == 1)

                        {
                            activeedit.Checked = true;

                        }
                        else
                        { activeedit.Checked = false; }


                    }
                    else
                    { activeedit.Checked = false; }

                }

            }
            catch (Exception ex)
            {


            }

        }
        protected void cpRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                //TBL_TemplateMaster
                SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.AppSettings["AHDPortalConnection"]);
                SqlCommand SqlCmd = new SqlCommand("update TBL_TemplateMaster set Template_Name=@Template_Name, Template_Description=@Template_Description,Template_Content =@Template_Content  where Template_ID=@Template_ID", SqlCnn);
                SqlCmd.Parameters.Add("@Template_Name", SqlDbType.VarChar).Value = "";
                SqlCmd.Parameters.Add("@UpdatedType", SqlDbType.VarChar).Value = "";
                SqlCmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = e.CommandArgument;
                try
                {
                    SqlCnn.Open();
                    SqlCmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                finally
                {
                    if (SqlCnn.State == ConnectionState.Open)
                        SqlCnn.Close();
                }
                BindRepeater();
            }
            if (e.CommandName == "delete")
            {
                SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                SqlCommand SqlCmd = new SqlCommand("delete CPMEMBERS where id=@ID", SqlCnn);
                SqlCmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = e.CommandArgument;
                try
                {
                    SqlCnn.Open();
                    SqlCmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                finally
                {
                    if (SqlCnn.State == ConnectionState.Open)
                        SqlCnn.Close();
                }
                BindRepeater();
            }

        }

        private void BindRepeater()
        {

            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();

            DataSet dt = logic.ReturnDataSet("select * from TBL_DoctorsMaster ");


            cpRepeater.DataSource = dt;
            cpRepeater.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            lblcheck.Text = "";

            SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);
            try
            {
                  BuissnessLogic.Class1 logic2 = new BuissnessLogic.Class1();
            DataSet DS = logic2.ReturnDataSet("select Doctor_ID from TBL_DoctorsMaster where Doctor_Code =  '" + txtDoctorcode.Text + "' and Doctor_ID != " + Convert.ToInt32(Session["testdoc"]));//Convert.ToInt32(Session["testdoc"])
                if (DS.Tables[0].Rows.Count == 0)
                {

                    if (Session["testdoc"] != null)
                    {
                        SqlCommand SqlCmd = new SqlCommand("update TBL_DoctorsMaster set Doctor_Code=@Doctor_Code, Doctor_Name=@Doctor_Name,Doctor_Description =@Doctor_Description,Clinic_Code =@Clinic_Code,Modified_By=@Modified_By ,Modified_On =@Modified_On, Status=@Status where Doctor_ID=@Doctor_ID", SqlCnn);
                        SqlCmd.Parameters.Add("@Doctor_Code", txtDoctorcode.Text);
                        SqlCmd.Parameters.Add("@Doctor_Name", txtdoctorName.Text);
                        SqlCmd.Parameters.Add("@Doctor_Description", txtdoctordescription.Text);
                        SqlCmd.Parameters.Add("@Clinic_Code", ddlcliniccode.SelectedValue);

                        SqlCmd.Parameters.Add("@Modified_By", Session["username"].ToString());

                        SqlCmd.Parameters.Add("@Modified_On", DateTime.Now);
                        if (activeedit.Checked)
                        {
                            //Status
                            SqlCmd.Parameters.Add("@Status", true);
                        }
                        else
                        {
                            SqlCmd.Parameters.Add("@Status", false);
                        }

                        SqlCmd.Parameters.Add("@Doctor_ID", Convert.ToInt32(Session["testdoc"]));

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
                    lblcheck.Text = "Doctor code was found !!Please insert another one ";
                }
            }
            catch (Exception ex)
            {


            }


        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Session.Remove("testdoc");
            panel2.Visible = false;
            panel1.Visible = true;
            BindRepeater();


        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            txtdoctorcode2.Text = "";
            txtdoctorname2.Text = "";
            txtdoctordescription2.Text = "";

        }

        protected void btnAddsave_Click(object sender, EventArgs e)
        {


            Label1.Text = "";

            SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);
            try
            {
                //get the last id 
                int number = 0;

                BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();

                BuissnessLogic.Class1 logic2 = new BuissnessLogic.Class1();
                DataSet DS = logic2.ReturnDataSet("select Doctor_ID from TBL_DoctorsMaster where Doctor_Code =  '" + txtdoctorcode2.Text + "' ");//Convert.ToInt32(Session["testdoc"])
                if (DS.Tables[0].Rows.Count == 0)
                {

                    SqlCommand SqlCmd = new SqlCommand("insert into  TBL_DoctorsMaster (Doctor_Code,Doctor_Name,Doctor_Description,Clinic_Code, Created_By,Created_On,Status)  values (@Doctor_Code,@Doctor_Name,@Doctor_Description,@Clinic_Code,@Created_By,@Created_On,@Status)", SqlCnn);
                    try
                    {

                        SqlCmd.Parameters.Add("@Doctor_Code", txtdoctorcode2.Text);
                        SqlCmd.Parameters.Add("@Doctor_Name", txtdoctorname2.Text);
                        SqlCmd.Parameters.Add("@Doctor_Description", txtdoctordescription2.Text);
                        //Session["username"].ToString()
                        SqlCmd.Parameters.Add("@Clinic_Code", ddlcliniccode1.SelectedValue);

                        SqlCmd.Parameters.Add("@Created_By", Session["username"].ToString());

                        SqlCmd.Parameters.Add("@Created_On", DateTime.Now);
                        //Status
                        if (activeadd.Checked)
                        {
                            SqlCmd.Parameters.Add("@Status", true);

                        }
                        else
                        {
                            SqlCmd.Parameters.Add("@Status", false);

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
                else
                {
                    Label1.Text = "Doctor Code Was found !! please insert another one ";
                }
            }
            

            catch (Exception ex)
            {


            }


        }

        protected void btnCancelsave_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = true;
            BindRepeater();
        }

        public void Fill_DropdownList()
        {
            ddlcliniccode1.Items.Clear();
            ddlcliniccode.Items.Clear();

            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
           DataSet ds =  logic.ReturnDataSet("select  Clinic_Code ,Clinic_Name from TBL_ClinicsMaster");
            if (ds.Tables[0].Rows.Count > 0)
              {
                for (int x =0; x<= ds.Tables[0].Rows.Count -1; x++)
                {

                    ListItem li = new ListItem();
                    li.Text = ds.Tables[0].Rows[x]["Clinic_Code"].ToString();
                    li.Value = ds.Tables[0].Rows[x]["Clinic_Code"].ToString();
                    ddlcliniccode.Items.Add(li);
                    ddlcliniccode1.Items.Add(li);

                }

            }



        }
            


    }
}