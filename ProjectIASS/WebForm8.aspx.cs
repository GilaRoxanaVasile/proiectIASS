using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6T63NK4;Initial Catalog=master;Integrated Security=True");
        int aparitii = 0;
        int id;
        bool flag = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            labelLogare.Text = "User logat: " + (string)Application["numeUser"];

            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT IdMedicament as [Nr.Crt], Denumire as [Denumire], Stoc as [Numar bucati] FROM Medicamente ORDER BY IdMedicament", con);

                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            aparitii = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.Cells[1].Text != null && row.Cells[1].Text.Trim() == TextBox1.Text.Trim())
                {
                    GridView1.SelectedIndex = row.RowIndex;
                    Button3.Visible = true;
                    Button4.Visible = true;
                    Application["idMed"] = Convert.ToInt32(row.Cells[0].Text);
                    aparitii++;
                    row.BackColor = Color.FromArgb(6, Color.Aqua);
                }
            }
            if (aparitii > 0)
            {
                LabelCautare.Text = "";
            }
            else
            {
                LabelCautare.Text = "Medicamentul nu exista in baza de date";
                Button3.Visible = false;
                Button4.Visible = false;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //modificare stoc

            string url;
             url = "WebForm9.aspx";
             Response.Redirect(url);
        }

        protected void Button3_Click(object sender, EventArgs e)
        { 
            //logica stergere

            int id = Convert.ToInt32(Application["idMed"]); ;
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Medicamente where IdMedicament=" + id, con);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0)
            {
                    string url;
                    url = "WebForm8.aspx";
                    Response.Redirect(url);
            }
            else
            {
                    LabelCautare.Text = "Stergerea a esuat";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //adaugare medicament
            string url;
            url = "WebForm10.aspx";
            Response.Redirect(url);
        }
    }
}