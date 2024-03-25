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

namespace AmHospital
{
    public partial class test : System.Web.UI.Page
    {
        BussinessObject.template temp = new BussinessObject.template();
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["username"] == null)
            {
                Response.Redirect("login_test.aspx");
            }
           else
            {
                if (!Page.IsPostBack)
                {
                    BindRepeater();
                }
            }
        }
        protected void btnUpdate_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null && e.CommandArgument != "")
            {
                
                temp.template_ID = Convert.ToInt32(e.CommandArgument);
                Session["test"] = temp.template_ID;
                Edit(temp.template_ID);

                panel2.Visible = true;
                panel1.Visible = false;



            }
        }

        public void Edit(int id )
        {

            BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
            DataSet ds = logic.ReturnDataSet("select * from TBL_TemplateMaster where Template_ID = "+id);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Template_Name"]))
                    {
                        txttemplateName.Text = ds.Tables[0].Rows[0]["Template_Name"].ToString();


                    }

                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Template_Code"]))
                    {
                        txttemplateCode.Text = ds.Tables[0].Rows[0]["Template_Code"].ToString();


                    }

                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Template_Description"]))
                    {
                        txttemplatedesc.Text = ds.Tables[0].Rows[0]["Template_Description"].ToString();


                    }


                    if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["Template_Content"]))
                    {
                        txttemplatecontent.Text = ds.Tables[0].Rows[0]["Template_Content"].ToString();


                    }

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

            DataSet dt = logic.ReturnDataSet("select * from TBL_TemplateMaster ");


            cpRepeater.DataSource = dt;
            cpRepeater.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                lblcheck.Text = "";
                BuissnessLogic.Class1 logic2 = new BuissnessLogic.Class1();
                DataSet DS = logic2.ReturnDataSet("select Template_ID from TBL_TemplateMaster where Template_Code =  '" + txttemplateCode.Text + "' and Template_ID != " + Convert.ToInt32(Session["test"]));
                if (DS.Tables[0].Rows.Count == 0)
                {

                    SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);
                    try
                    {


                        if (temp.template_ID != null)
                        {
                            SqlCommand SqlCmd = new SqlCommand("update TBL_TemplateMaster set Template_Name=@Template_Name, Template_Description=@Template_Description,Template_Content =@Template_Content,Template_Code =@Template_Code,Modified_By=@Modified_By ,Modified_On =@Modified_On where Template_ID=@Template_ID", SqlCnn);
                            SqlCmd.Parameters.Add("@Template_Name", txttemplateName.Text);
                            SqlCmd.Parameters.Add("@Template_Description", txttemplatedesc.Text);
                            SqlCmd.Parameters.Add("@Template_Content", txttemplatecontent.Text);
                            SqlCmd.Parameters.Add("@Template_Code", txttemplateCode.Text);

                            SqlCmd.Parameters.Add("@Modified_By", Session["username"].ToString());

                            SqlCmd.Parameters.Add("@Modified_On", DateTime.Now);

                            SqlCmd.Parameters.Add("@Template_ID", Convert.ToInt32(Session["test"]));

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
                    catch (Exception ex)
                    {


                    }

                }

                else
                {
                    lblcheck.Text = "Template code was found !! please insert another one ";

                }
            }
            catch (Exception ex)
            {

            }
        
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Session.Remove("test");
            panel2.Visible = false;
            panel1.Visible = true;
            BindRepeater();


        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
        }

        protected void btnAddsave_Click(object sender, EventArgs e)
        {
            BuissnessLogic.Class1 logic2 = new BuissnessLogic.Class1();
            DataSet DS = logic2.ReturnDataSet("select Template_ID from TBL_TemplateMaster where Template_Code =  '" + txttemplatecode1.Text + "' " );
            if (DS.Tables[0].Rows.Count == 0)
            {


                Label1.Text = "";

                SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AHDPortalConnection"].ConnectionString);
                try
                {
                    //get the last id 
                    int number = 0;

                    BuissnessLogic.Class1 logic = new BuissnessLogic.Class1();
                    DataSet dss = logic.ReturnDataSet("select top(1) Template_ID  from TBL_TemplateMaster order by Template_ID desc");
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        number = Convert.ToInt32(dss.Tables[0].Rows[0]["Template_ID"]);
                    }
                    else
                    {
                        //the first template 
                        number = 1;
                    }

                    if (temp.template_ID != null)
                    {
                        SqlCommand SqlCmd = new SqlCommand("insert into  TBL_TemplateMaster (Template_Code,Template_Name,Template_Description,Template_Content,Created_By,Created_On)  values (@Template_Code,@Template_Name,@Template_Description,@Template_Content,@Created_By,@Created_On)", SqlCnn);

                        SqlCmd.Parameters.Add("@Template_Code", txttemplatecode1.Text);
                        SqlCmd.Parameters.Add("@Template_Name", txttemplatename1.Text);
                        SqlCmd.Parameters.Add("@Template_Description", txttemplatedescription1.Text);
                        //Session["username"].ToString()
                        SqlCmd.Parameters.Add("@Template_Content", txttemplatecontent1.Text);

                        SqlCmd.Parameters.Add("@Created_By", Session["username"].ToString());

                        SqlCmd.Parameters.Add("@Created_On", DateTime.Now);

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
                }
                catch (Exception ex)
                {


                }
            }
            else
            {
                Label1.Text = "Template Code Was Found !! please insert another one ";
            }


        }

        protected void btnCancelsave_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = true;
            BindRepeater();
        }





  

    }
}