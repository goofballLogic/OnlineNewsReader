using System;

namespace OnlineNewsReader.Data.PersistenceModels
{
	#region Classes

	public class Article
	{
		public string author { get; set; }
		public string description { get; set; }
		public DateTime? publishedAt { get; set; }
		public Source source { get; set; }
		public string title { get; set; }
		public string url { get; set; }
		public string urlToImage { get; set; }
	}

	#endregion
}
