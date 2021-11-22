using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Article.Queries.GetArticles
{
    public class GetArticlesQuery : IRequest<IDataResult<IEnumerable<ArticleDto>>>
    {
    }
}
