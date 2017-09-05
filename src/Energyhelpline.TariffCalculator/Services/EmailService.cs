using System;
using System.Threading.Tasks;
using Energyhelpline.TariffCalculator.Helpers;
using Energyhelpline.TariffCalculator.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace Energyhelpline.TariffCalculator.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigModel _emailConfigModel;

        public EmailService(EmailConfigModel emailConfigModel)
        {
            _emailConfigModel = emailConfigModel;
        }

        public async Task SendEmail(string emailMessage)
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

                    await client.SendAsync(message);

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