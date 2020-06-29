using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing
{
    public partial class vote_page : System.Web.UI.Page
    {
        String aadhar_no;
        String state;
        SqlConnection cn;
        SqlCommand cmd;
        private bool checkSession()
        {
            if (Session["user"] == null)
                return false;

            return true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            String time = DateTime.Now.ToString("HH:mm");
            time = time.Substring(0, 2);

            if (Convert.ToInt32(time) < 17)
            {
                bool check = checkSession();
                if (check)
                {
                    aadhar_no = Session["User"].ToString();
                    state = Session["State"].ToString();
                    cn = (SqlConnection)Session["Connection"];


                }
                else
                {
                    Response.Write("<script>alert('You Have not login or your session is expired.');window.location='login.aspx'</script>");
                    // Response.Redirect("login.aspx");
                    Response.Write("HELLO WORLD");
                }
            }
            else
                {
                Response.Write("<script>alert('Sorry Voting is over......');window.location='Result.aspx'</script>");
                
                }
            

            }

        

        protected void btnBJP_Click(object sender, EventArgs e)
            {

            
            {
                String result_update;
                String user_update = "UPDATE registered SET vote=1 WHERE aadhar_no=" + aadhar_no;
                cmd = new SqlCommand(user_update, cn);
                cmd.ExecuteNonQuery();


                if (state == "Gujarat")
                {

                    result_update = "UPDATE result SET Gujarat=Gujarat+1 Where name='BJP'";
                }
                else if (state == "Rajsthan")
                {
                    result_update = "UPDATE result SET Rajsthan=Rajsthan+1 Where name='BJP'";
                }
                else
                {
                    result_update = "UPDATE result SET Maharashtra=Maharashtra+1 Where name='BJP'";
                }
                cmd = new SqlCommand(result_update, cn);
                cmd.ExecuteNonQuery();
                Session.Abandon();
                Response.Write("<script>alert('Your Vote Submitted SuccesFully.');window.location='login.aspx'</script>");
            }
           
            }

            protected void btnCongress_Click(object sender, EventArgs e)
            {
           
            {
                String result_update;
                String user_update = "UPDATE registered SET vote=1 WHERE aadhar_no=" + aadhar_no;
                cmd = new SqlCommand(user_update, cn);
                cmd.ExecuteNonQuery();


                if (state == "Gujarat")
                {

                    result_update = "UPDATE result SET Gujarat=Gujarat+1 Where name='Congress'";
                }
                else if (state == "Rajsthan")
                {
                    result_update = "UPDATE result SET Rajsthan=Rajsthan+1 Where name='Congress'";
                }
                else
                {
                    result_update = "UPDATE result SET Maharashtra=Maharashtra+1 Where name='Congress'";
                }
                cmd = new SqlCommand(result_update, cn);
                cmd.ExecuteNonQuery();
                Session.Abandon();
                Response.Write("<script>alert('Your Vote Submitted SuccesFully.');window.location='login.aspx'</script>");
            }
            
        }

            protected void btnOthers_Click(object sender, EventArgs e)
            {
            
            {
                String result_update;
                String user_update = "UPDATE registered SET vote=1 WHERE aadhar_no=" + aadhar_no;
                cmd = new SqlCommand(user_update, cn);
                cmd.ExecuteNonQuery();


                if (state == "Gujarat")
                {

                    result_update = "UPDATE result SET Gujarat=Gujarat+1 Where name='Shivsena'";
                }
                else if (state == "Rajsthan")
                {
                    result_update = "UPDATE result SET Rajsthan=Rajsthan+1 Where name='Shivsena'";
                }
                else
                {
                    result_update = "UPDATE result SET Maharashtra=Maharashtra+1 Where name='Shivsena'";
                }
                cmd = new SqlCommand(result_update, cn);
                cmd.ExecuteNonQuery();
                Session.Abandon();
                Response.Write("<script>alert('Your Vote Submitted SuccesFully.');window.location='login.aspx'</script>");
            }
            
        }
            
        

    }
}