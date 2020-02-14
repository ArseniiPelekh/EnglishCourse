using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;


namespace YoungDeveloperEnglish.Email
{
    public class EmailService
    {
        string _email { get; set; }
        string _password { get; set; }

        string _host { get; set; }
        int _port { get; set; }

        public EmailService(string email, string password, string host, int port)
        {
            _email = email;
            _password = password;
            _host = host;
            _port = port;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Young Developer English", _email));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_host, _port, false);
                await client.AuthenticateAsync(_email, _password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}

