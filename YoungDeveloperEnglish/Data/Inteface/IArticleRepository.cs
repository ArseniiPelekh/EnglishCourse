using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Inteface
{
    public interface IArticleRepository
    {
        IQueryable<Article> Articles();

        Task AddArticle(Article article);

        Task DeleteArticle(int id);

        Task ChangeArticle(Article article);
    }
}
