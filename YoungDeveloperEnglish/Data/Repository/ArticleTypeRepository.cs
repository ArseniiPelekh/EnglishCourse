using Data.Inteface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class ArticleTypeRepository : IArticleTypeRepository
    {
        private readonly AppDBContent _appDBContent;

        public ArticleTypeRepository(AppDBContent appDB)
        {
            this._appDBContent = appDB;
        }

        public IQueryable<ArticleType> ArticleTypes()
        {
            return _appDBContent.ArticleTypes;
        }
    }
}
