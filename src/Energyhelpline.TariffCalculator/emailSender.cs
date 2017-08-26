using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace Energyhelpline.TariffCalculator
{
    public class EmailSender
    {
        private readonly EmailConfig _emailConfig;

        public EmailSender(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail()
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_emailConfig.Username, _emailConfig.FromAddress));
                message.To.Add(new MailboxAddress(_emailConfig.Username, _emailConfig.ToAddress));
                message.Subject = _emailConfig.Subject;

                message.Body = new TextPart("plain")
                {
                    Text = _emailConfig.Message
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, false);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    client.Authenticate(_emailConfig.Username, _emailConfig.Password);

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