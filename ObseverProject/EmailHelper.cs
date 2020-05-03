using System;
using System.Net.Mail;

namespace ObseverProject
{
    /// <summary>
    /// A struct to hold our credentials
    /// </summary>
    public struct Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Static class to help us send the email with the notification
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// Method for sending an email
        /// </summary>
        /// <param name="smptClientAddress">The address of the smtp client</param>
        /// <param name="emailAddressFrom">The email address that we are sending from</param>
        /// <param name="emailAddressTo">The email address that we are sending to</param>
        /// <param name="subject">Email subject</param>
        /// <param name="body">Email body</param>
        /// <param name="credentials">Our email smtp credentials</param>
        /// <param name="port">Port that we are using to send, 587 by default</param>
        /// <returns>A boolean to notify true if the email was sent and false if it wasn't</returns>
        public static bool SendEmail(string smptClientAddress, string emailAddressFrom, string emailAddressTo, string subject, string body, Credentials credentials, int port = 587)
        {
            try
            {
                //Creating a mail message and a client to use for sending our email
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smptClientAddress);

                mail.From = new MailAddress(emailAddressFrom);
                mail.To.Add(emailAddressTo);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(credentials.Username, credentials.Password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
