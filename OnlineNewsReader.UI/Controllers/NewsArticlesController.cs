using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineNewsReader.Business.Interfaces;
using OnlineNewsReader.Core.DomainModels;
using OnlineNewsReader.UI.Models;
using OnlineNewsReader.UI.ViewModels.NewsArticles;

namespace OnlineNewsReader.UI.Controllers
{
	public class NewsArticlesController : Controller
	{
		#region Fields

		private readonly IMemoryCache _memoryCache;
		private readonly string _memoryCacheKeyPrefix = "OnlineNewsReader_NewsArticles";
		private readonly INewsArticle _newsArticles = new Business.NewsArticle();

		#endregion

		#region Constructors

		public NewsArticlesController(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		#endregion

		#region Methods

		[HttpGet]
		public IActionResult List(ListViewModel listViewModel)
		{
			if (listViewModel == null)
			{
				listViewModel = new ListViewModel();
			}

			string memoryCacheKey = _memoryCacheKeyPrefix;
			NewsArticles newsArticles = null;

			var parameters = new List<KeyValuePair<string, string>>();

			if (!string.IsNullOrWhiteSpace(listViewModel.Query))
			{
				parameters.Add(new KeyValuePair<string, string>("q", listViewModel.Query));
				memoryCacheKey = string.Format("{0}|{1}:{2}", memoryCacheKey, "q", listViewModel.Query);
			}

			if (!string.IsNullOrWhiteSpace(listViewModel.From))
			{
				parameters.Add(new KeyValuePair<string, string>("from", listViewModel.From));
				memoryCacheKey = string.Format("{0}|{1}:{2}", memoryCacheKey, "from", listViewModel.From);
			}

			if (!string.IsNullOrWhiteSpace(listViewModel.To))
			{
				parameters.Add(new KeyValuePair<string, string>("to", listViewModel.To));
				memoryCacheKey = string.Format("{0}|{1}:{2}", memoryCacheKey, "to", listViewModel.To);
			}

			if (!string.IsNullOrWhiteSpace(listViewModel.SortBy))
			{
				parameters.Add(new KeyValuePair<string, string>("sortBy", listViewModel.SortBy));
				memoryCacheKey = string.Format("{0}|{1}:{2}", memoryCacheKey, "sortBy", listViewModel.SortBy);
			}

			if (listViewModel.Page > 0)
			{
				parameters.Add(new KeyValuePair<string, string>("page", listViewModel.Page.ToString()));
				memoryCacheKey = string.Format("{0}|{1}:{2}", memoryCacheKey, "q", listViewModel.Page.ToString());
			}

			if (_memoryCache != null)
			{
				newsArticles = _memoryCache.Get<NewsArticles>(memoryCacheKey);
			}

			if (newsArticles == null)
			{
				if (parameters.Count > 0)
				{
					newsArticles = _newsArticles.GetNewsArticles(parameters);
				}
				else
				{
					newsArticles = _newsArticles.GetNewsArticles();
				}

				if (newsArticles != null && _memoryCache != null)
				{
					_memoryCache.Set(memoryCacheKey, newsArticles);
				}
			}

			if (newsArticles != null)
			{
				if (listViewModel.Page == null)
				{
					listViewModel.Page = 1;
				}

				listViewModel.NewsArticles = newsArticles.SelectedNewsArticles as IList<NewsArticle>;
				listViewModel.TotalResults = newsArticles.TotalNewsArticles;

				if (Request != null)
				{
					var uriBuilder = new UriBuilder(UriHelper.GetDisplayUrl(Request));
					var query = HttpUtility.ParseQueryString(uriBuilder.Query);

					if (listViewModel.Page > 1)
					{
						query.Remove("page");
						query.Add("page", (listViewModel.Page - 1).ToString());
						uriBuilder.Query = query.ToString();
						listViewModel.PreviousPageUrl = uriBuilder.ToString();
					}

					if (listViewModel.TotalResults != null && listViewModel.Page <= (listViewModel.TotalResults / 20))
					{
						query.Remove("page");
						query.Add("page", (listViewModel.Page + 1).ToString());
						uriBuilder.Query = query.ToString();
						listViewModel.NextPageUrl = uriBuilder.ToString();
					}
				}
			}

			return View(listViewModel);
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		#endregion
	}
}
