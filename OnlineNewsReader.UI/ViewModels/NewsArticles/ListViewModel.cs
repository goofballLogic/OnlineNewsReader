using System.Collections.Generic;
using OnlineNewsReader.Core.DomainModels;

namespace OnlineNewsReader.UI.ViewModels.NewsArticles
{
	public class ListViewModel
	{
		public string Query { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public string SortBy { get; set; }
		public int? Page { get; set; }
		public int? TotalResults { get; set; }
		public IList<NewsArticle> NewsArticles { get; set; }
		public string PreviousPageUrl { get; set; }
		public string NextPageUrl { get; set; }
	}
}
