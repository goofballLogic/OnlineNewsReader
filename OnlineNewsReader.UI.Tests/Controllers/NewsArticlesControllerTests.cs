using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineNewsReader.UI.Controllers;
using OnlineNewsReader.UI.ViewModels.NewsArticles;

namespace OnlineNewsReader.UI.Tests.Controllers
{
	[TestClass]
	public class NewsArticlesControllerTests
	{
		#region Fields

		private readonly IMemoryCache _memoryCache = null;

		#endregion

		#region Methods

		[TestMethod]
		public void List()
		{
			var newsArticlesController = new NewsArticlesController(_memoryCache);
			var listViewModel = new ListViewModel();
			var viewResult = newsArticlesController.List(listViewModel) as ViewResult;

			Assert.IsNotNull(viewResult);
		}

		#endregion
	}
}
