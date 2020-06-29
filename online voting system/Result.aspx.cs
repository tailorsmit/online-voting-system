using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing
{
    public partial class Result : System.Web.UI.Page
    {
        SqlConnection cn;
        String connection_string;

        protected void Page_Load(object sender, EventArgs e)
        {

            String time = DateTime.Now.ToString("HH:mm");
            time = time.Substring(0, 2);

            if (Convert.ToInt32(time) < 17)
            {
                progress.Text = "Live";
            }
            else
            {
                progress.Text = "Final";

            }

            connection_string = "Data Source=localhost;Initial Catalog=election;Integrated Security=True";
            cn = new SqlConnection(connection_string);
            string query = "SELECT * FROM result";
            SqlCommand cmd = new SqlCommand(query, cn);
            cn.Open();
            BJP_Gujarat.Text = "Hello";
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 1;
            while (reader.Read())
            {
                if(count==1)
                {
                    BJP_Gujarat.Text = reader[1].ToString();
                    BJP_Maharashtra.Text = reader[2].ToString();
                    BJP_Rajasthan.Text = reader[3].ToString();
                    BJP_total.Text= (Convert.ToInt32(reader[1]) + Convert.ToInt32(reader[2]) + Convert.ToInt32(reader[3])).ToString();
                }
                else if (count==2)
                {
                    Congress_Gujarat.Text = reader[1].ToString();
                    Congress_Maharashtra.Text = reader[2].ToString();
                    Congress_Rajasthan.Text = reader[3].ToString();
                    Congress_total.Text = (Convert.ToInt32(reader[1]) + Convert.ToInt32(reader[2]) + Convert.ToInt32(reader[3])).ToString();
                }
                else if(count==3)
                {
                    Shivsena_Gujarat.Text = reader[1].ToString();
                    Shivsena_Maharashtra.Text = reader[2].ToString();
                    Shivsena_Rajasthan.Text = reader[3].ToString();
                    Shivsena_total.Text =( Convert.ToInt32(reader[1]) + Convert.ToInt32(reader[2]) + Convert.ToInt32(reader[3])).ToString();
                }
                count++;
                
            }
            if (progress.Text == "Final")
            {
                String result_string = "";
                string temp;
                int bjp_gujarat = Convert.ToInt32(BJP_Gujarat.Text);
                int bjp_rajasthan = Convert.ToInt32(BJP_Rajasthan.Text);
                int bjp_maharashtra = Convert.ToInt32(BJP_Maharashtra.Text);
                int congress_gujarat = Convert.ToInt32(Congress_Gujarat.Text);
                int congress_rajasthan = Convert.ToInt32(Congress_Rajasthan.Text);
                int congress_maharashtra = Convert.ToInt32(Congress_Maharashtra.Text);
                int shivsena_gujarat = Convert.ToInt32(Shivsena_Gujarat.Text);
                int shivsena_rajasthan = Convert.ToInt32(Shivsena_Rajasthan.Text);
                int shivsena_maharashtra = Convert.ToInt32(Shivsena_Maharashtra.Text);
                temp = Won_Check(bjp_gujarat, congress_gujarat, shivsena_gujarat);
                result_string += "Won " + temp + " in Gujarat, ";
                temp = Won_Check(bjp_rajasthan, congress_rajasthan, shivsena_rajasthan);
                result_string += temp + " in Rajsthan, ";
                temp = Won_Check(bjp_maharashtra, congress_maharashtra, shivsena_maharashtra);
                result_string += temp + " in Maharashta.";
                Win.Text = result_string;

            }
        }
        private string Won_Check(int a, int b, int c)
        {

            if (a > b && a > c)
            {
                return "Bhartiya Janata Party";
            }
            else if (b > a && b > c)
            {
                return "National Congress Party";
            }
            else if (c > a && c > b)
            {
                return "Shivsena";
            }
            if (a == b && b == c)
            {
                return "Bhartiya Janata Party and National Congress Party and Shivsena";
            }
            if (a == b)
            {
                return "Bhartiya Janata Party and National Congress Party";
            }
            if (a == c)
            {
                return "Bhartiya Janata Party and Shivsena";
            }
            if (b == c)
            {
                return "Shivsena and National Congress Party";
            }
            return "";
        }

    }
}