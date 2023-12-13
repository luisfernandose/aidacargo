using BufaloCargo.Areas.Identity.Pages.Account;
using BufaloCargo.Utils.Models;
using System.Net.Mail;
using static BufaloCargo.Areas.Identity.Pages.Account.RegisterModel;

namespace BufaloCargo.Utils.Helper
{
    public class MailHelper
    {
        readonly IWebHostEnvironment contentRoot_;

        public MailHelper(IWebHostEnvironment contentRoot_)
        {
            this.contentRoot_ = contentRoot_;
        }

        public async Task SendInvitation(InputModel registerModel, string userName)
        {
            var EmailSubjec = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["EmailSubjec"];
            await SendMail(registerModel.Email, SetEmailBody(registerModel, userName), EmailSubjec);
        }

        private async Task<bool> SendMail(string toAddress, AlternateView emailbody, string Subject)
        {
            try
            {
                EmailSettings settings = getEmailSettings();
                var userCredentials = new System.Net.NetworkCredential(settings.SMTPUserName, settings.SMTPPassword);
                SmtpClient smtp = new SmtpClient
                {
                    Host = settings.Host,
                    Port = Convert.ToInt32(settings.Port),
                    EnableSsl = Convert.ToBoolean(settings.EnableSsl),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = Convert.ToInt32(settings.Timeout)
                };
                smtp.Credentials = userCredentials;
                //smtp.UseDefaultCredentials = false;
                MailMessage message = new MailMessage();
                message.From = new MailAddress(settings.SenderEmailAddress, settings.SenderDisplayName);
                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.AlternateViews.Add(emailbody);
                message.IsBodyHtml = true;

                foreach (var m in toAddress.Split(','))
                {
                    message.To.Add(m);
                };

                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private EmailSettings getEmailSettings()
        {
            EmailSettings settings = new EmailSettings();
            settings.SMTPUserName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SMTPUserName"];
            settings.SMTPPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SMTPPassword"];
            settings.Host = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SMTPHost"];
            settings.Port = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SMTPPort"];
            settings.EnableSsl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SMTPEnableSsl"];
            settings.Timeout = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SMTPTimeout"];
            settings.SenderDisplayName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SenderDisplayName"];
            settings.SenderEmailAddress = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SenderEmailAddress"];
            return settings;
        }

        private AlternateView SetEmailBody(InputModel registerModel, string userName)
        {
            try
            {
                //se arma el correo que se envia para el ambio de clave
                var ruta = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["WelcomeTemplate"];
                var url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["WelcomeTemplateUrl"];
                string plantilla = Path.Combine(contentRoot_.WebRootPath, ruta);
                var html = System.IO.File.ReadAllText(plantilla);
                html = html.Replace("%FIRSTNAME|%", registerModel.Names);
                html = html.Replace("%LASTNAME|%", registerModel.SurNames);
                html = html.Replace("%USUARIO|%", registerModel.Email + " / " + userName);
                html = html.Replace("%CLAVE|%", registerModel.Password);
                html = html.Replace("%URL|%", url);
                AlternateView av = AlternateView.CreateAlternateViewFromString(html, null, "text/html");
                return av;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
