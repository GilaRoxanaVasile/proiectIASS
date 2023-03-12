﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelLogare.Text = "User logat: " + (string)Application["numeUser"];
        }

        protected void Buton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6T63NK4;Initial Catalog=master;Integrated Security=True");
            SqlCommand cmd;
            if (TextBox1.Text.Trim().Length == 0)
            {
                Label1.Text = "Stocul trebuie introdus";
            }
            else if(!TextBox1.Text.Trim().Any(c => char.IsNumber(c)))
            {
                Label1.Text = "Valoarea nu este corecta";
            }
            else
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("update Medicamente set Stoc = @stoc where IdMedicament = @id", conn);

                    int id = (int)Application["idMed"];
                    int stoc = int.Parse(TextBox1.Text.Trim());

                    cmd.Parameters.AddWithValue("@stoc", stoc);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        string url = "WebForm8.aspx";
                        Response.Redirect(url);
                    }
                    else
                        LabelEroare.Text = "Eroare la modificare!";
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
}