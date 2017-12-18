using System.Collections.Generic;
using OnlineNewsReader.Core.DomainModels;

namespace OnlineNewsReader.Business.Interfaces
{
	#region Interfaces

	public interface INewsArticle
	{
		NewsArticles GetNewsArticles();
		NewsArticles GetNewsArticles(IEnumerable<KeyValuePair<string, string>> parameters);
	}

	#endregion
}
