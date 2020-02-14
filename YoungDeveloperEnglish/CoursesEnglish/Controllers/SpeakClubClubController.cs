using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Inteface;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using YoungDeveloperEnglish.ViewModels;

namespace YoungDeveloperEnglish.Controllers
{
    public class SpeakClubController : Controller
    {
        IArticleRepository _article;
        public SpeakClubController(IArticleRepository article)
        {
            _article = article;
        }

        [Route("ListClub/{typeArtical}")]
        public IActionResult ListClub(int typeArtical)
        {
            var articles = _article.Articles().Where(i => i.ArticleType.Id == typeArtical).OrderBy(i => i.Id);

            var obj = new ClubListModel
            {
                Articles = articles,
                Title = articles.First().ArticleType.Name
            };

            return View("SpeakClub", obj);
        }
    }
}