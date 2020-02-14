using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Inteface;
using Data.Models;
using Data.Models.EmailModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using YoungDeveloperEnglish.Email;
using YoungDeveloperEnglish.ViewModels;

namespace YoungDeveloperEnglish.Controllers
{
    [Authorize]
    public class SendEmailController : Controller
    {
        private readonly AppIdentitySettings _appIdentitySettings;
        private SendMessageToEmail _sendMessageToEmail;
        private IPersonRequestRepository _personRequest;

        public SendEmailController(IOptions<AppIdentitySettings> appIdentitySettingsAccessor, IPersonRequestRepository personRequest)
        {
            _appIdentitySettings = appIdentitySettingsAccessor.Value;
            _sendMessageToEmail = new SendMessageToEmail(_appIdentitySettings);
            _personRequest = personRequest;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SendEmail(SendMessageModel messageModel)
        {
            string textMass = $"Имя: {messageModel.Name} \nЕлектрона адреса: {messageModel.Email} \nНомер телефону: {messageModel.PhoneNumber} \nТап звертання: {messageModel.TypeForm}";
            // _sendMassageToEmail.SendMessage("Заявка на " + massageModel.TypeForm, textMass);

            await _personRequest.AddPersonRequest(new PersonRequest
            {
                Name = messageModel.Name,
                Email = messageModel.Email,
                Number = messageModel.PhoneNumber,
                DateTime = DateTime.Now,
                TypeForm = messageModel.TypeForm
            });

            return PartialView("SendMessInfo", messageModel);
        }

        [HttpGet]
        public IActionResult ShowAllPersonRequest()
        {
            var personRequests  = _personRequest.PersonRequests().OrderBy(t => t.DateTime);

            return View(personRequests);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePersonRequest(int personRequestId)
        {
            await _personRequest.DeletePersonRequest(personRequestId);
            
            return RedirectToAction("ShowAllPersonRequest");
        }

    }
}