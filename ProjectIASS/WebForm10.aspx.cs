using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6T63NK4;Initial Catalog=master;Integrated Security=True");
        SqlCommand cmd;
        bool flag;
        protected void Page_Load(object sender, EventArgs e)
        {

            labelLogare.Text = "User logat: " + (string)Application["numeUser"];
        }

        protected void Buton1_Click(object sender, EventArgs e)
        {
            verificare();

            if (TextBox1.Text.ToString().Trim().Length == 0)
            {
                Label1.Text = "Denumirea trebuie introdusa";
            }
            else if(TextBox2.Text.ToString().Trim().Length == 0)
            {
                Label1.Text = "Stocul trebuie introdus";
            }
            else if (flag)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into Medicamente (Denumire,Stoc) values(@denumire, @stoc) ", conn);

                    cmd.Parameters.AddWithValue("@denumire", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@stoc", TextBox2.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        string url = "WebForm8.aspx";
                        Response.Redirect(url);
                    }
                    else
                        LabelEroare.Text = "Eroare la inserare!";
                }
                catch (Exception ex)
                {
                    LabelEroare.Text = "Eroare la deschidere baza date " + ex.Message;
                }
                //adaugarea datelor
                finally
                {
                    conn.Close();
                }
            }
        }

        private void verificare()
        {
            if (!TextBox1.Text.Trim().Any(c => char.IsLetter(c)))
            {
                flag = false;
                Label1.Text = "Denumirea nu este corecta";
            }
            else if (TextBox2.Text.Trim().Any(c => char.IsLetter(c)))
            {
                flag = false;
                Label1.Text = "Stocul nu este corect";
            }
            else
                flag = true;
        }
    }
}