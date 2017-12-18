using System.Collections.Generic;
using OnlineNewsReader.Core.DomainModels;

namespace OnlineNewsReader.Data.Interfaces
{
	#region Interfaces

	public interface INewsArticleRepository
	{
		NewsArticles GetNewsArticles();
		NewsArticles GetNewsArticles(IEnumerable<KeyValuePair<string, string>> parameters);
	}

	#endregion
}
