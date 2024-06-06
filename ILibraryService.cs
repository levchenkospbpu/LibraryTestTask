namespace LibraryTestTask
{
	internal interface ILibraryService
	{
		Library GetLibrary();
		Book CreateBook(string title, string author);
		User CreateUser(string name);
		bool DeleteBook(int id);
		bool DeleteUser(int id);
		Book GetBook(int id);
		Book[] GetAllBooks();
		Book[] GetBooksByTitle(string title);
		Book[] GetBooksByAuthor(string author);
		Book[] GetBooksByTitleAndAuthor(string title, string author);
		void GiveBook(int bookId, int userId);
		void ReceiveBook(int id);
		
	}
}
