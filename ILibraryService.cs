namespace LibraryTestTask
{
	internal interface ILibraryService
	{
		Library GetLibrary();
		Book CreateBook(string title, string author);
		User CreateUser(string name);
		bool DeleteBook(uint id);
		bool DeleteUser(uint id);
		Book GetBook(uint id);
		Book[] GetAllBooks();
		Book[] GetBooksByTitle(string title);
		Book[] GetBooksByAuthor(string author);
		Book[] GetBooksByTitleAndAuthor(string title, string author);
		User GetUser(uint id);
		User[] GetAllUsers();
		User[] GetUsersByName(string name);
		void GiveBook(uint bookId, uint userId);
		void ReceiveBook(uint id);
		void UpdateBook(Book book);
		void UpdateUser(User user);
		
	}
}
