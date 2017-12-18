using System.Collections.Generic;
using OnlineNewsReader.Business.Interfaces;
using OnlineNewsReader.Core.DomainModels;
using OnlineNewsReader.Data.Interfaces;
using OnlineNewsReader.Data.Repositories;

namespace OnlineNewsReader.Business
{
	public class NewsArticle : INewsArticle
	{
		#region Fields

		private readonly INewsArticleRepository _newsArticles = new NewsArticleRepository();

		#endregion

		#region Methods

		public NewsArticles GetNewsArticles()
		{
			NewsArticles newsArticles = null;

			if (_newsArticles != null)
			{
				newsArticles = _newsArticles.GetNewsArticles();
			}

			return newsArticles;
		}

		public NewsArticles GetNewsArticles(IEnumerable<KeyValuePair<string, string>> parameters)
		{
			NewsArticles newsArticles = null;

			if (_newsArticles != null)
			{
				newsArticles = _newsArticles.GetNewsArticles(parameters);
			}

			return newsArticles;
		}

		#endregion
	}
}
