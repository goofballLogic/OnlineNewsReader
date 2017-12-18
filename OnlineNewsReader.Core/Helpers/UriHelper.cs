using System;
using System.Web;

namespace OnlineNewsReader.Core.Helpers
{
	public static class UriHelper
	{
		#region Methods

		public static Uri AddParameter(Uri uri, string parameterName, string parameterValue)
		{
			if (uri != null && !string.IsNullOrWhiteSpace(parameterName) && !string.IsNullOrWhiteSpace(parameterValue))
			{
				var uriBuilder = new UriBuilder(uri);
				var query = HttpUtility.ParseQueryString(uriBuilder.Query);
				query.Set(parameterName, parameterValue);
				uriBuilder.Query = query.ToString();
				uri = uriBuilder.Uri;
			}

			return uri;
		}

		#endregion
	}
}
