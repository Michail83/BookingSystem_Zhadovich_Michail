using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using Google.Apis.Auth.OAuth2;


using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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

        public async Task SendEmailAsync(MailRequest mailRequest)
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
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
                //smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
                //smtp.AuthenticationMechanisms.Remove("XOAUTH2");
                
                
                //var credential = await GetAccessTokenServiceAccountAsync();

                //var oauth2 = new SaslMechanismOAuth2("mymail@gmail.com", credential.Token.AccessToken);

                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private async Task<ServiceAccountCredential> GetAccessTokenServiceAccountAsync() 
        {
            var certificate = new X509Certificate2(@"D:\миша_документы\cf0b3290d478.p12", "notasecret", X509KeyStorageFlags.Exportable);
            var credential = new ServiceAccountCredential(new ServiceAccountCredential
                .Initializer("107197600399076436760")
            {
                Scopes = new[] { "https://mail.google.com/" },
                User = "zhadovichmichail@gmail.com", 
              //User = "zhadovich-book-system@my-stady-booking-project.iam.gserviceaccount.com"
            }.FromCertificate(certificate));
            
            var cancel = new System.Threading.CancellationToken();
            bool result = await credential.RequestAccessTokenAsync(cancel);
                       

            return credential;
        }



    }
}
