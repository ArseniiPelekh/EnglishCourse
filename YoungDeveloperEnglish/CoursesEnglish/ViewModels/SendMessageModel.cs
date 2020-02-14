using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YoungDeveloperEnglish.ViewModels
{
    public class SendMessageModel
    {
        [Required(ErrorMessage = "Заповніть поле")]
        [Display(Name = "Імя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заповніть поле")]
        [Display(Name = "Електронна адреса")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Заповніть поле")]
        [Display(Name = "Номер телефону")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string TypeForm{ get; set; }
    }
}
