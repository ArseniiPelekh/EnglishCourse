using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YoungDeveloperEnglish.ViewModels
{
    public class ChangeArticleModel
    {

        public IEnumerable<Article> Articles { get; set; }

        public IEnumerable<ArticleType> ArticleTypes { get; set; }

    }
}

