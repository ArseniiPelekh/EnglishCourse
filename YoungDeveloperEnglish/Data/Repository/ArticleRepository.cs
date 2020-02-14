using Data.Inteface;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDBContent _appDBContent;

        public ArticleRepository(AppDBContent appDB)
        {
            _appDBContent = appDB;
        }

        public async Task AddArticle(Article article)
        {
            await _appDBContent.Articles.AddAsync(article);
            await _appDBContent.SaveChangesAsync();
        }

        public async Task DeleteArticle(int id)
        {
            var _article = await _appDBContent.Articles.FirstOrDefaultAsync(a => a.Id == id);
            if (_article != null) {
                _appDBContent.Articles.Remove(_article);
                await _appDBContent.SaveChangesAsync();
            }
        }

        public async Task ChangeArticle(Article article)
        {
            _appDBContent.Articles.Update(article);
            await _appDBContent.SaveChangesAsync();
        }

        public IQueryable<Article> Articles()
        {
            return _appDBContent.Articles.Include(a => a.ArticleType);
        }
    }
}
