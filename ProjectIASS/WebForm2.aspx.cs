using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String nume = Request.QueryString["utilizator"];
            labelLogare.Text = "User logat: " + (string)Application["numeUser"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url;
            url = "WebForm3.aspx";
            Response.Redirect(url);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string url;
            url = "WebForm4.aspx";
            Response.Redirect(url);
        }

    }
}