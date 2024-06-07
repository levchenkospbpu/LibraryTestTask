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

			ConsoleHelper.Menu(
			("Create user", () => LibraryServiceConsoleActions.CreateUser(libraryService)),
			("Show users", () => LibraryServiceConsoleActions.ShowUsers(libraryService)),
			("Create book", () => LibraryServiceConsoleActions.CreateBook(libraryService)),
			("Show books", () => LibraryServiceConsoleActions.ShowBooks(libraryService)),
			("Give book", () => LibraryServiceConsoleActions.GiveBook(libraryService)),
			("Exit", () => Environment.Exit(0)));
		}
	}
}
