using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
namespace follow
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fromAddress = new MailAddress("bet.frankfurt.newsletter@gmail.com", "בית פרנקפורט");
            const string fromPassword = "1wJxMrhhBGwKxk2HNkk_xQ";
            SmtpClient c = new SmtpClient
            {
                Host = "smtp.mandrillapp.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            }; 
            var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = "ip",
                            Body =(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                        };
                        c.Send(message);
                    }
            
        }
    }
}