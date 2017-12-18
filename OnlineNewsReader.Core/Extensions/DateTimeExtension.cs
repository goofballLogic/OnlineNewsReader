using System;

namespace OnlineNewsReader.Core.Extensions
{
	#region Methods

	public static class DateTimeExtension
	{
		public static string ToHumanReadable(this DateTime value)
		{
			TimeSpan timeSpan = DateTime.UtcNow.Subtract(value);

			if (timeSpan >= TimeSpan.MinValue && timeSpan <= TimeSpan.MaxValue)
			{
				if ((long)timeSpan.TotalSeconds >= 0)
				{
					if ((long)timeSpan.TotalSeconds < 60)
					{
						return "just now";
					}
					else if ((long)timeSpan.TotalSeconds < 120)
					{
						return "1 minute ago";
					}
					else if ((long)timeSpan.TotalSeconds < 3600)
					{
						return string.Format("{0} minutes ago", Math.Floor((double)(long)timeSpan.TotalMinutes).ToString());
					}
					else if ((long)timeSpan.TotalSeconds < 7200)
					{
						return "1 hour ago";
					}
					else if ((long)timeSpan.TotalSeconds < 86400)
					{
						return string.Format("{0} hours ago", Math.Floor((double)(long)timeSpan.TotalHours).ToString());
					}
					else if ((long)timeSpan.TotalSeconds < 172800)
					{
						return "yesterday";
					}
					else if ((long)timeSpan.TotalSeconds < 604800)
					{
						return string.Format("{0} days ago", ((long)timeSpan.TotalDays).ToString());
					}
					else if ((long)timeSpan.TotalSeconds < 1209600)
					{
						return "1 week ago";
					}
					else
					{
						return string.Format("{0} weeks ago", Math.Ceiling((double)(long)(timeSpan.TotalDays) / 7).ToString());
					}
				}
			}

			return timeSpan.ToString();
		}
	}

	#endregion
}
