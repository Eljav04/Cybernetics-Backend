using System;
using Microsoft.Extensions.Configuration;
namespace Lesson_60_HT.Services
{
	public class DbService
	{
		public static IConfiguration Configuration;

		public static void Bulid()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange:true );

			Configuration = builder.Build();
		}
	}
}

