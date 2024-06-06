using System.Linq;

namespace LibraryTestTask
{
	internal class LibraryService : ILibraryService
	{
		private IBookRepository _bookRepository;
		private IUserRepository _userRepository;

		public LibraryService(IBookRepository bookRepository, IUserRepository userRepository)
		{
			_bookRepository = bookRepository;
			_userRepository = userRepository;
		}

		public Book CreateBook(string title, string author)
		{
			var book = new Book
			{
				Title = title,
				Author = author
			};
			return _bookRepository.Create(book);
		}

		public User CreateUser(string name)
		{
			var user = new User
			{
				Name = name
			};
			return _userRepository.Create(user);
		}

		public Book[] GetAllBooks()
		{
			return _bookRepository.Select();
		}

		public Book[] GetBooksByAuthor(string author)
		{
			return _bookRepository.Select(x => x.Author == author);
		}

		public Book[] GetBooksByTitle(string title)
		{
			return _bookRepository.Select(x => x.Title == title);
		}

		public Book[] GetBooksByTitleAndAuthor(string title, string author)
		{
			return _bookRepository.Select(x => x.Title == title && x.Author == author);
		}

		public Library GetLibrary()
		{
			var library = new Library();
			library.Books = _bookRepository.Select();
			library.Users = _userRepository.Select();
			return library;
		}

		public bool DeleteBook(uint id)
		{
			var book = _bookRepository.Select(x => x.Id == id).FirstOrDefault();
			return _bookRepository.Delete(book);
		}

		public bool DeleteUser(uint id)
		{
			var user = _userRepository.Select(x => x.Id == id).FirstOrDefault();
			return _userRepository.Delete(user);
		}

		public Book GetBook(uint id)
		{
			return _bookRepository.Select(x => x.Id == id).FirstOrDefault();
		}

		public void GiveBook(uint bookId, uint userId)
		{
			var book = GetBook(bookId);

			book.UserId = userId;
			book.IsAvailable = false;
		}

		public void ReceiveBook(uint id)
		{
			var book = GetBook(id);
			book.UserId = null;
			book.IsAvailable = true;
		}

		public void UpdateBook(Book book)
		{
			_bookRepository.Update(book);
		}

		public void UpdateUser(User user)
		{
			_userRepository.Update(user);
		}

		public User GetUser(uint id)
		{
			return _userRepository.Select(x => x.Id == id).FirstOrDefault();
		}

		public User[] GetAllUsers()
		{
			return _userRepository.Select();
		}

		public User[] GetUsersByName(string name)
		{
			return _userRepository.Select(x => x.Name == name);
		}
	}
}
