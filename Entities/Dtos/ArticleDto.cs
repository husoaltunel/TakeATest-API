using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ArticleDto : IDto
    {
        public string Title { get;set;}
        public string Text { get;set;} 
    }
}
