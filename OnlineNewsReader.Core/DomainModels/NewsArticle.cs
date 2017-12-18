using System;

namespace OnlineNewsReader.Core.DomainModels
{
	#region Classes

	public class NewsArticle
	{
		public string Author { get; set; }
		public DateTime? DatePublished { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public string Name { get; set; }
		public string SourceOrganisation { get; set; }
		public string Url { get; set; }
	}

	#endregion
}
