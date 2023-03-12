using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
using System.Data;
using System.Web.UI.WebControls;
using System.Drawing;

namespace ProjectIASS
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection("Data Source=LAPTOP-PF9DAIU5\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;");

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6T63NK4;Initial Catalog=master;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        int aparitii = 0;
        string cnp = "kk";
        protected void Page_Load(object sender, EventArgs e)
        {
            labelLogare.Text = "User logat: " + (string)Application["numeUser"];

            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT CNP as [CNP], Nume as [Nume], Prenume as [Prenume], Diagnostic as [Diagnostic], Email as [Email] FROM Pacienti ORDER BY Nume, Prenume", con);

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
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.Cells[1].Text != null && row.Cells[1].Text.Trim() == TextBox1.Text.Trim())
                {
                    GridView1.SelectedIndex = row.RowIndex;
                    Button2.Visible = true;
                    Button5.Visible = true;
                    Button4.Visible = true;
                    Application["cnpPacient"] = row.Cells[0].Text;
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
                LabelCautare.Text = "Pacientul nu exista in baza de date";
                Button2.Visible = false;
                Button5.Visible = false;
                Button4.Visible = false;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //adaugare pacient
            string url;
            url = "WebForm6.aspx";
            Response.Redirect(url);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //reteta
                string url;
                url = "WebForm7.aspx";
                Response.Redirect(url);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            cnp = (string)Application["cnpPacient"];
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Pacienti where CNP='"+cnp+"'", con);

            int rows = cmd.ExecuteNonQuery();
            con.Close();
            if (rows > 0)
            {
                string url;
                url = "WebForm5.aspx";
                Response.Redirect(url);
            }
            else
            {
                LabelCautare.Text = "Stergerea a esuat";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
                cnp = (string)Application["cnpPacient"];
                string exePath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                string directory = new Uri(System.IO.Path.GetDirectoryName(exePath)).LocalPath;
                string nume = "1", prenume = "2", diagnostic = "2", numar = "2", medicament = "3", indicatii = "2", email = "2";
                XDocument doc;


                try
                {
                    con.Open();
                    cmd = new SqlCommand("select Nume, Prenume, Diagnostic, Email from Pacienti where CNP='" + cnp + "'", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nume = dr[0].ToString();
                        prenume = dr[1].ToString();
                        diagnostic = dr[2].ToString();
                        email = dr[3].ToString();
                    }
                }
                catch (Exception ex)
                {
                    LabelCautare.Text = "Conexiune esuata" + ex;
                }
                finally
                {
                    con.Close();
                }

                try
                {
                    con.Open();
                    cmd = new SqlCommand("select NumarReteta, Medicamente, Indicatii from Retete where CnpPacient='" + cnp + "'", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        numar = dr[0].ToString();
                        medicament = dr[1].ToString();
                        indicatii = dr[2].ToString();
                        LabelCautare.Text = "Generarea xml-ului a reusit";

                    }
                }
                catch (Exception ex)
                {
                    LabelCautare.Text = "Conexiune esuata baza reteta" + ex;
                }
                finally
                {
                    con.Close();
                }

                doc = new XDocument(new XElement("Farmacie",
                                               new XElement("Pacienti",
                                                   new XElement("nume", nume),
                                                   new XElement("prenume", prenume),
                                                   new XElement("diagnostic", diagnostic),
                                                   new XElement("email", email)),
                                               new XElement("Reteta",
                                               new XElement("medicament", medicament),
                                               new XElement("indicatii", indicatii))));
                doc.Save(directory + cnp + ".xml");
        }

       
    }
}