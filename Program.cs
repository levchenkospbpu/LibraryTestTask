using Microsoft.Extensions.DependencyInjection;
using System;

namespace LibraryTestTask
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddSingleton<DataSource>();
			serviceCollection.AddSingleton<IBookRepository, CollectionBookRepository>();
			serviceCollection.AddSingleton<IUserRepository, CollectionUserRepository>();
			serviceCollection.AddSingleton<ILibraryService, LibraryService>();

			var serviceProvider = serviceCollection.BuildServiceProvider();

			var libraryService = serviceProvider.GetRequiredService<ILibraryService>();

			var pasha = libraryService.CreateUser("ПАША");

			var library = libraryService.GetLibrary();

			Console.WriteLine("Users:");
			foreach (var user in library.Users)
			{
				Console.WriteLine(user.Name);
				user.Name += " EDITED";
			}

			Console.WriteLine("Books:");
			foreach (var book in library.Books)
			{
				Console.WriteLine($"{book.Title} by {book.Author}");
				book.Title += " EDITED";
			}

			Console.WriteLine("Users:");
			foreach (var user in library.Users)
			{
				Console.WriteLine(user.Name);
			}

			Console.WriteLine("Books:");
			foreach (var book in library.Books)
			{
				Console.WriteLine($"{book.Title} by {book.Author}");
			}

			Console.ReadLine();
		}
	}
}
