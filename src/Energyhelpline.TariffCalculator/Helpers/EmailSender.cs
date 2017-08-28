using System;
using Energyhelpline.TariffCalculator.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace Energyhelpline.TariffCalculator.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfigModel _emailConfigModel;

        public EmailSender(EmailConfigModel emailConfigModel)
        {
            _emailConfigModel = emailConfigModel;
        }

        public void SendEmail(string emailMessage)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_emailConfigModel.Username, _emailConfigModel.FromAddress));
                message.To.Add(new MailboxAddress(_emailConfigModel.Username, _emailConfigModel.ToAddress));
                message.Subject = _emailConfigModel.Subject;

                message.Body = new TextPart("plain")
                {
                    Text = emailMessage
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(_emailConfigModel.SmtpServer, _emailConfigModel.Port, false);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    client.Authenticate(_emailConfigModel.Username, _emailConfigModel.Password);

                    client.Send(message);

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}