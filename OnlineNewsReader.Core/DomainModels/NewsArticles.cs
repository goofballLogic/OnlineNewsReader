using System.Collections.Generic;

namespace OnlineNewsReader.Core.DomainModels
{
	public class NewsArticles
	{
		public ICollection<NewsArticle> SelectedNewsArticles { get; set; }
		public int TotalNewsArticles { get; set; }
	}
}
