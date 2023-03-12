using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm7 : System.Web.UI.Page
    {   
        
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6T63NK4;Initial Catalog=master;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            labelLogare.Text = "User logat: " + (string)Application["numeUser"];
            string cnp = (string)Application["cnpPacient"];

            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT Medicamente as [Medicament], Indicatii as [Indicatii] FROM Retete WHERE CnpPacient = '" + cnp + "' ORDER BY Medicamente", con);

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


        protected void Button2_Click(object sender, EventArgs e)
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string directory = new Uri(System.IO.Path.GetDirectoryName(exePath)).LocalPath;
            var cnp_pacient = (string)Application["cnpPacient"];
            string numar = "2";
            string medicament = "2";
            string indicatii = "2";
            string email = "2";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 5, 5);
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6T63NK4;Initial Catalog=master;Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd = new SqlCommand("select NumarReteta, Medicamente, Indicatii from Retete where CnpPacient='" + cnp_pacient + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numar = dr[0].ToString();
                    medicament = dr[1].ToString();
                    indicatii = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                Label1.Text = cnp_pacient + "Conexiune esuata" + ex;
            }
            finally
            {
                con.Close();
            }

            try
            {
                con.Open();
                cmd = new SqlCommand("select Email from Pacienti where CNP='" + cnp_pacient + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    email = dr[0].ToString();
                }

                Label1.Text = email;
            }
            catch (Exception ex)
            {
                Label1.Text = "nu se poate obtine mail-ul pacientului" + ex;
            }
            finally
            {
                con.Close();
            }

            Label1.Text = "Generarea a avut loc cu succes";

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(directory + cnp_pacient + ".pdf", FileMode.Create));
            doc.Open();
            Paragraph para = new Paragraph("Numar reteta: " + numar + "\nMedicament: " + medicament + "\nIndicatii: " + indicatii);
            doc.Add(para);
            doc.Close();

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("iassissa3@gmail.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Reteta dumneavoastra";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "In urma achizitie din reteaua noastra de farmacii va trimitem atasat si reteta cu modul de administrare si indicatiile medicamentelor.";
                message.Attachments.Add(new Attachment(directory + cnp_pacient + ".pdf"));
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("iassissa3@gmail.com", "iasstest1!");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception r)
            {

                Label1.Text = "nu s-a trimis mail " + r;
            }

        }
    }
}