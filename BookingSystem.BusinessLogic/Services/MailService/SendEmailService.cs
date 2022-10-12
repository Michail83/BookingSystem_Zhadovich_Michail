using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;

using System.Threading.Tasks;


namespace BookingSystem.BusinessLogic.Services.MailService
{
    public class SendEmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public SendEmailService(IOptions<MailSettings> mailsetting)
        {
            _mailSettings = mailsetting.Value;
        }

        public async Task<bool> SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage();

                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;

                var builder = new BodyBuilder();
                builder.TextBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();


                using var smtp = new SmtpClient();
                smtp.ServerCertificateValidationCallback = (sender, certificate, chain, sslpolisyError) => true;
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public async Task<bool> SendEmailAsync(MailRequest mailRequest, bool isHtmlBody)
        {

            try
            {
                var email = new MimeMessage();

                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();


                using var smtp = new SmtpClient();
                smtp.ServerCertificateValidationCallback = (sender, certificate, chain, sslpolisyError) => true;
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }



    }
}
