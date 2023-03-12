using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        bool flag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            labelLogare.Text = "User logat: " + (string)Application["numeUser"];
        }

        protected void Buton1_Click(object sender, EventArgs e)
        {
            verificare();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6T63NK4;Initial Catalog=master;Integrated Security=True");
            SqlCommand cmd;
            if (TextBox1.Text.Length == 0)
            {
                Label1.Text = "CNP-ul este obligatoriu";
            }
            else if (TextBox2.Text.Length == 0)
            {
                Label1.Text = "Numele este obligatiu";
            }
            else if (TextBox3.Text.Length == 0)
            {
                Label1.Text = "Prenume este obligatiu";
            }
            else if (TextBox4.Text.Length == 0)
            {
                Label1.Text = "Diagnosticul este obligatiu";
            }
            else if (TextBox5.Text.Length == 0)
            {
                Label1.Text = "Emailul este obligatiu";
            }
            else
            {
                if (flag)
                {
                    try
                    {
                        conn.Open();
                        cmd = new SqlCommand("insert into Pacienti (CNP,Nume,Prenume,Email,Diagnostic) values(@cnp, @nume, @prenume, @email, @diagnostic) ", conn);

                        cmd.Parameters.AddWithValue("@cnp", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@nume", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@prenume", TextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@diagnostic", TextBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", TextBox5.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            string url = "WebForm5.aspx";
                            Response.Redirect(url);
                        }
                        else
                            LabelEroare.Text = "Eroare inserare!";
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
        }

        private bool verificare()
        {
            if (TextBox1.Text.Length != 13)
            {
                Label1.Text = "CNP incorect";
                flag = false;
            }
            else if (TextBox1.Text.Any(c => char.IsLetter(c)))
            {
                Label1.Text = "CNP incorect";
                flag = false;
            }
            else if (TextBox2.Text.Any(c => char.IsNumber(c)))
            {
                Label1.Text = "Numele nu este corect!";
                flag = false;
            }
            else if (TextBox3.Text.Any(c => char.IsNumber(c)))
            {
                Label1.Text = "Prenumele nu este corect!";
                flag = false;
            }
            else if (!TextBox5.Text.Contains("@"))
            {
                Label1.Text = "Emailul nu este corect!";
                flag = false;
            }
            else
                flag = true;
            return flag;
        }
    }
}