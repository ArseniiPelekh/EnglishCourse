using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YoungDeveloperEnglish.ViewModels
{
    public class AddArticleModel
    {
        [Required(ErrorMessage = "Заполните поле!")]
        [Display(Name = "Html текст")]
        public string TextHtml { get; set; }
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage = "Заполните поле!")]
        [Display(Name = "Тип статті")]
        public int FKArticleType { get; set; }

        public IEnumerable<ArticleType> ArticleTypes { get; set; }
    }
}
