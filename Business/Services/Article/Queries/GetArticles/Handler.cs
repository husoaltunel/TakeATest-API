using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Dtos;
using HtmlAgilityPack;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Services.Article.Queries.GetArticles
{
    public class Handler : IRequestHandler<GetArticlesQuery, IDataResult<IEnumerable<ArticleDto>>>
    {
        private readonly IConfiguration _configuration;
        public Handler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IDataResult<IEnumerable<ArticleDto>>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {

            string url = _configuration.GetSection("SiteUrl").Value;
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            
            List<ArticleDto> articles = new List<ArticleDto>();

            try
            {
                var headers = document.DocumentNode.SelectNodes("//li[contains(@class,'card-component__description')]//h2");
                var liElementsHasATag = document.DocumentNode.SelectNodes("//li[contains(@class,'card-component__description')]");

                for (int i = 0; i < 5; i++)
                {

                    html = client.DownloadString(string.Concat(url, liElementsHasATag[i + 1].FirstChild.GetAttributeValue("href", "")));
                    document = new HtmlDocument();
                    document.LoadHtml(html);

                    StringBuilder articleTexts = new StringBuilder();
                    var texts = document.DocumentNode.SelectNodes("//div[contains(@class,'grid-layout__content')]//p");
                    for (int j = 0; j < texts.Count; j++)
                    {
                        articleTexts.AppendFormat(texts[j].InnerText);
                    }

                    articles.Add(new ArticleDto()
                    {
                        Title = headers[i + 1].InnerText,
                        Text = articleTexts.ToString()
                    });
                }

                return new SuccessDataResult<IEnumerable<ArticleDto>>(articles);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ArticleDto>>(message: ArticleMessages.ErrorGet);

            }
            finally
            {
                client.Dispose();
            }



        }
    }
}
