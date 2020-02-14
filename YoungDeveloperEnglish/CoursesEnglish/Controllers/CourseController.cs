using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using YoungDeveloperEnglish.Email;
using Data.Models.EmailModels;

namespace YoungDeveloperEnglish.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult CourseForAdults()
        {
            return View();
        }

        public IActionResult CourseForChildren()
        {
            return View();
        }
    }
}

