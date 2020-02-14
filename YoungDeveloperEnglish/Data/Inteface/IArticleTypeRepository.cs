using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Inteface
{
    // Неправильное название
    public interface IArticleTypeRepository
    {
        IQueryable<ArticleType> ArticleTypes();
    }
}
