using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoungDeveloperEnglish.ViewModels
{
    public class ClubListModel
    {
        public IEnumerable<Article> Articles { get; set; }

        public SendMessageModel SendMassageModel { get; set; }

        public string Title { get; set; }
    }
}
