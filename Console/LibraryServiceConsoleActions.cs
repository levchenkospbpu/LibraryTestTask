using ConsoleTables;
using System;

namespace LibraryTestTask
{
	internal static class LibraryServiceConsoleActions
	{
		public static void CreateUser(ILibraryService libraryService)
		{
			Console.Clear();
			Console.WriteLine("Creating a new user");
			Console.Write("Name: ");
			libraryService.CreateUser(Console.ReadLine());
		}

		public static void ShowUsers(ILibraryService libraryService)
		{
			Console.Clear();
			var library = libraryService.GetLibrary();

			var table = new ConsoleTable("ID", "Name");

			foreach (var user in library.Users)
			{
				table.AddRow(user.Id, user.Name);
			}

			table.Write();
			Console.WriteLine();
		}

		public static void CreateBook(ILibraryService libraryService)
		{
			Console.Clear();
			Console.WriteLine("Creating a new book");
			Console.Write("Title: ");
			var title = Console.ReadLine();
			Console.Write("Author: ");
			var author = Console.ReadLine();
			libraryService.CreateBook(title, author);
		}

		public static void ShowBooks(ILibraryService libraryService)
		{
			Console.Clear();
			var library = libraryService.GetLibrary();

			var table = new ConsoleTable("ID", "Title", "Author", "Availability");

			foreach (var book in library.Books)
			{
				table.AddRow(book.Id, book.Title, book.Author, book.IsAvailable ? "available" : "unavailable");
			}

			table.Write();
			Console.WriteLine();
		}

		public static void GiveBook(ILibraryService libraryService)
		{
			uint bookId;
			uint userId;

			Console.Clear();
			Console.WriteLine("Giving book to user");
			Console.Write("Book ID: ");

			while (!uint.TryParse(Console.ReadLine(), out bookId))
			{
				Console.WriteLine("invalid input value, try again");
				Console.Write("Book ID: ");
			}

			Console.Write("User ID: ");

			while (!uint.TryParse(Console.ReadLine(), out userId))
			{
				Console.WriteLine("invalid input value, try again");
				Console.Write("Book ID: ");
			}

			libraryService.GiveBook(bookId, userId);
		}
	}
}
