using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Inteface;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YoungDeveloperEnglish.ViewModels;

namespace YoungDeveloperEnglish.Controllers
{
    [Authorize]
    public class ArticleCongiuntivoController : Controller
    {
        private IArticleRepository _article;
        private IArticleTypeRepository _articleType;

        public ArticleCongiuntivoController(IArticleRepository article, IArticleTypeRepository articleType) {
            _article = article;
            _articleType = articleType;
        }

        [HttpGet]
        public IActionResult AddNewArticle()
        {
            var articleType = _articleType.ArticleTypes().OrderBy(a => a.Name);

            var obj = new AddArticleModel
            {
                ArticleTypes = articleType
            };

            return View(obj);
        }

        [HttpGet]
        public IActionResult ShowAllArticle()
        {
            var article = _article.Articles().OrderBy(i => i.DateTime);

            var obj = new ChangeArticleModel
            {
                Articles = article
            };

            return View(obj);
        }

        [HttpGet]
        public IActionResult ChangeArticle()
        {
            var article = _article.Articles().OrderBy(i => i.DateTime);
            var articleType = _articleType.ArticleTypes().OrderBy(a => a.Name);

            var obj = new ChangeArticleModel
            {
                Articles = article,
                ArticleTypes = articleType
            };

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewArticle(AddArticleModel articleModel)
        {
            await _article.AddArticle(new Article
            {
                TextHtml = articleModel.TextHtml,
                DateTime = DateTime.Now,
                FKArticleType = articleModel.FKArticleType,
            });

            return RedirectToAction("ShowAllArticle");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeArticle(Article article)
        {
            await _article.ChangeArticle(article);

            return RedirectToAction("ChangeArticle");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            await _article.DeleteArticle(articleId);
            
            return RedirectToAction("ChangeArticle");
        }
    }
}