using System;
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
				Author = author,
				IsAvailable = true
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
			try
			{
				var data = _bookRepository.Select(x => x.Id == id).FirstOrDefault();

				if (data == default)
				{
					throw new ArgumentException();
				}

				return data;
			}

			catch (ArgumentException)
			{
				Console.WriteLine($"Book with id={id} was not found");
				return default;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return default;
			}
		}

		public void GiveBook(uint bookId, uint userId)
		{
			try
			{
				var book = GetBook(bookId);

				if (book == default)
				{
					throw new ArgumentException();
				}

				if (!book.IsAvailable)
				{
					throw new ArgumentException($"Book with id={bookId} is unavailable");
				}

				var user = GetUser(userId);

				if (user == default)
				{
					throw new ArgumentException();
				}

				book.UserId = userId;
				book.IsAvailable = false;

				UpdateBook(book);
			}

			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return;
			}
		}

		public void ReceiveBook(uint id)
		{
			try
			{
				var book = GetBook(id);

				if (book == default)
				{
					throw new ArgumentException();
				}

				if (book.IsAvailable == true)
				{
					throw new ArgumentException($"Book with id={id} is not in use");
				}

				book.UserId = null;
				book.IsAvailable = true;

				UpdateBook(book);
			}

			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return;
			}
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
			try
			{
				var data = _userRepository.Select(x => x.Id == id).FirstOrDefault();

				if (data == default)
				{
					throw new ArgumentException();
				}

				return data;
			}

			catch (ArgumentException)
			{
				Console.WriteLine($"User with id={id} was not found");
				return default;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return default;
			}
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
