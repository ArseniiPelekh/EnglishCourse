using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ArticleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ArticleType()
        {
            Articles = new List<Article>();
        }
    }
}
