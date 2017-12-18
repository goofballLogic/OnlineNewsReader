using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnlineNewsReader.Core.DomainModels;
using OnlineNewsReader.Core.Helpers;
using OnlineNewsReader.Data.Interfaces;
using OnlineNewsReader.Data.PersistenceModels;

namespace OnlineNewsReader.Data.Repositories
{
	public class NewsArticleRepository : INewsArticleRepository
	{
		#region Fields

		private Uri uri = new Uri("https://newsapi.org/v2/everything?apiKey=8d6e94cf25f3476e91025debe7966683&sources=bbc-news");

		#endregion

		#region Methods

		public NewsArticles GetNewsArticles()
		{
			return GetNewsArticles(null);
		}

		public NewsArticles GetNewsArticles(IEnumerable<KeyValuePair<string, string>> parameters)
		{
			NewsArticles newsArticles = null;
			NewsArticle newsArticle = null;

			if (parameters != null)
			{
				foreach (var keyValuePair in parameters)
				{
					if (!string.IsNullOrWhiteSpace(keyValuePair.Key) && !string.IsNullOrWhiteSpace(keyValuePair.Value))
					{
						uri = UriHelper.AddParameter(uri, keyValuePair.Key, keyValuePair.Value);
					}
				}
			}

			var rootobject = WebRequestHelper.JsonToObject<Rootobject>(uri);

			if (rootobject != null && rootobject.articles != null && rootobject.articles.Length > 0)
			{
				foreach (var article in rootobject.articles)
				{
					if (newsArticles == null)
					{
						newsArticles = new NewsArticles()
						{
							TotalNewsArticles = rootobject.totalResults
						};
					}

					if (newsArticles.SelectedNewsArticles == null)
					{
						newsArticles.SelectedNewsArticles = new Collection<NewsArticle>();
					}

					newsArticle = new NewsArticle
					{
						Author = article.author,
						DatePublished = article.publishedAt,
						Description = article.description,
						Image = article.urlToImage,
						Name = article.title,
						SourceOrganisation = article.source?.name,
						Url = article.url
					};

					newsArticles.SelectedNewsArticles.Add(newsArticle);
				}
			}

			return newsArticles;
		}

		#endregion
	}
}
