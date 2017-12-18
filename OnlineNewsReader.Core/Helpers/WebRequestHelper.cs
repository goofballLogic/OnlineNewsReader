using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace OnlineNewsReader.Core.Helpers
{
	public static class WebRequestHelper
	{
		#region Methods

		public static T JsonToObject<T>(Uri uri)
		{
			T value = default(T);
			var webRequest = WebRequest.Create(uri);

			using (var webResponse = webRequest.GetResponse())
			{
				var stream = webResponse.GetResponseStream();

				if (stream != null)
				{
					var streamReader = new StreamReader(stream);

					value = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
				}
			}

			return value;
		}

		#endregion
	}
}
