using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            String connection_string = "Data Source=localhost;Initial Catalog=election;Integrated Security=True";
            cn = new SqlConnection(connection_string);
            try
            {
                cn.Open();
                
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Somthhing went wrong to database connection')</script>");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            String aadhar_no = txtAadhar.Text;
            try
            {
                aadhar_no = aadhar_no.Trim();
                foreach(char a in aadhar_no)
                {
                    if (Char.IsDigit(a))
                    {

                    }
                    else throw new Exception();
                }
                if (aadhar_no.Length == 12)
                {
                    String state = dropdownState.SelectedValue;
                    String register_query = "select count(*) from registered where aadhar_no=" + aadhar_no;
                    SqlCommand cmd = new SqlCommand(register_query, cn);
                    int i = (int)cmd.ExecuteScalar();
                    
                    if (i != 1)
                    {
                        String new_query = "insert into registered values(" + aadhar_no + ",'" + state + "',0)";
                        cmd = new SqlCommand(new_query, cn);
                        cmd.ExecuteNonQuery();
                        
                        Session["User"] = aadhar_no;
                        Session["Connection"] = cn;
                        Session["State"] = state;
                        
                        Response.Redirect("vote_page.aspx");
                    }
                    else
                    {
                        register_query = "select * from registered where aadhar_no=" + aadhar_no;
                        cmd = new SqlCommand(register_query, cn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            String vote = reader.GetString(2);
                            if (vote == "0")
                            {
                                Session["User"] = aadhar_no;
                                Session["Connection"] = cn;
                                Session["State"] = state;
                                reader.Close();
                                Response.Redirect("vote_page.aspx");

                            }
                            else
                            {
                                Response.Write("<script>alert('You Have Already given a vote')</script>");
                            }
                        }
                        
                    }
                }
                else
                {
                    Response.Write("<script>alert('Enter Valid Aadhar')</script>");
                }

            }
            catch(Exception ex)
            {
                
                Response.Write("<script>alert('Enter Valid Aadhar')</script>");
                txtAadhar.Text = "";
            }
            
            
            
        }
    }
}