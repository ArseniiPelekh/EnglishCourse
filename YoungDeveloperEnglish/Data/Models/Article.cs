using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string TextHtml { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("ArticleType")]
        public int? FKArticleType { get; set; }
        public ArticleType ArticleType { get; set; }

    }
}
