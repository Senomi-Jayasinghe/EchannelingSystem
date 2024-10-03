using EchannelingSystem.Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace EchannelingSystem.View
{
    public partial class UpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string NewPassword = generatePassword();
            string UserName = txtEmail.Text;
            updatePassword(NewPassword, UserName); //Update DB with new Password
            string subject = "EChanneling Login New Password";
            string body = "Your new Password is " + NewPassword;
            string toEmailAddress = UserName;
            SendEmail(subject, body, toEmailAddress, null, string.Empty); //Send Email
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginUI.aspx");
        }

        protected static string generatePassword()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+[]{}|;:,.<>?";
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            return password.ToString();
        }

        protected void updatePassword(string NewPassword, string UserName)
        {
            LoginController loginController = new LoginController();
            loginController.forgotpswupdate(NewPassword, UserName);
        }

        public void SendEmail(string subject, string body, string toEmailAddress, byte[] mergeDoc, string attachementName)
        {
            try
            {
                // Define SMTP server details
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // or 25
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("senomi.jayasinghe@gmail.com", "uvbx upvx igog dkqf"),
                    EnableSsl = true, // Use SSL if required
                };
               
                // Compose the email
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("senomi.jayasinghe@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true, // Set to true if you're sending an HTML email
                };
                // Add recipient
                mail.To.Add(toEmailAddress);

                smtpClient.Send(mail);

            }
            catch (Exception ex)
            {
                Response.Write($"Failed to send email. Error: {ex.Message}");
            }

        }
    }
}
