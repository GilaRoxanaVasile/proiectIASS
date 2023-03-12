using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProjectIASS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection("Data Source=LAPTOP-PF9DAIU5\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;");

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6T63NK4;Initial Catalog=master;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("select NumeUser from Users", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DropDownList1.Items.Add(dr[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Label3.Text = "Conexiune esuata " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Parola from Users where NumeUser='" + DropDownList1.Text +
               "'", con);
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    Label3.Text = "Datele sunt gresite!";
                }
                else
                {
                    string url;
                    if (dr[0].ToString().Trim() == TextBox1.Text.Trim())
                    {
                        Application["NumeUser"] = DropDownList1.Text;
                        url = "WebForm2.aspx";
                        Response.Redirect(url);
                    }
                    else
                    {
                        Label3.Text = "Parola gresita!";
                    }
                }
            }
            catch (Exception ex)
            {
                Label3.Text = "Nu se poate realiza conexiunea " + ex.Message;
            }
            finally
            {
                con.Close();
            }

        }
    }
}