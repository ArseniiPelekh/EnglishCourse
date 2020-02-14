using Data.Models.EmailModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoungDeveloperEnglish.Email
{
    public class SendMessageToEmail
    {

        private readonly AppIdentitySettings _appIdentitySettings;

        public SendMessageToEmail(AppIdentitySettings appIdentitySettings)
        {
            _appIdentitySettings = appIdentitySettings;
        }

        public async void SendMessage(string subjectMess, string textMess)
        {
            EmailService emailService = new EmailService(_appIdentitySettings.UserEmail.FromEmail, _appIdentitySettings.UserEmail.Password, _appIdentitySettings.SettingEmail.Host, _appIdentitySettings.SettingEmail.Port);
            await emailService.SendEmailAsync(_appIdentitySettings.UserEmail.ToEmail, "Заказ " + subjectMess, textMess + "\n\n^_^");
        }

    }
}
