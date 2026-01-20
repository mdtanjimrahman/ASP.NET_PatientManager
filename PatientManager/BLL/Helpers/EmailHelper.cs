using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;

namespace BLL.Helpers
{
    public class EmailHelper
    {
        private static string senderEmail = "tanjimpromise252000@gmail.com"; 
        private static string senderPassword = "evse uwib dkrl pyur"; 
        public static void SendEmail(string recipientEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Hospital Appointment System", senderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(senderEmail, senderPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}