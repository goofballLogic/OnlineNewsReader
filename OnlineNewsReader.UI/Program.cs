using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace OnlineNewsReader.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
			.UseKestrel()
			.UseStartup<Startup>()
			.UseContentRoot(Directory.GetCurrentDirectory())
			.UseIISIntegration()
			.Build();
	}
}
