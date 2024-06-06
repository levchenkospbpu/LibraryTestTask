using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTestTask
{
	internal class LibraryService : ILibraryService
	{
		private IBookRepository _bookRepository;
		private IUserRepository _userRepository;

		public Book CreateBook(string title, string author)
		{
			var book = new Book
			{
				Title = title,
				Author = author
			};
			return _bookRepository.Add(book);
		}

		public User CreateUser(string name)
		{
			var user = new User
			{
				Name = name
			};
			return _userRepository.Add(user);
		}

		public Book[] GetAllBooks()
		{
			return _bookRepository.Select();
		}

		public Book[] GetBooksByAuthor(string author)
		{
			return _bookRepository.Select().Where(x => x.Author == author).ToArray();
		}

		public Book[] GetBooksByTitle(string title)
		{
			return _bookRepository.Select().Where(x => x.Title == title).ToArray();
		}

		public Book[] GetBooksByTitleAndAuthor(string title, string author)
		{
			return _bookRepository.Select().Where(x => x.Title == title && x.Author == author).ToArray();
		}

		public Library GetLibrary()
		{
			var library = new Library();
			library.Books = _bookRepository.Select();
			library.Users = _userRepository.Select();
			return library;
		}

		public bool DeleteBook(int id)
		{
			var book = _bookRepository.Select().Where(x => x.Id == id).FirstOrDefault();
			return _bookRepository.Remove(book);
		}

		public bool DeleteUser(int id)
		{
			var user = _userRepository.Select().Where(x => x.Id == id).FirstOrDefault();
			return _userRepository.Remove(user);
		}

		public Book GetBook(int id)
		{
			return _bookRepository.Select().Where(x => x.Id == id).FirstOrDefault();
		}

		public void GiveBook(int bookId, int userId)
		{
			var book = GetBook(bookId);

			book.UserId = userId;
			book.IsAvailable = false;
		}

		public void ReceiveBook(int id)
		{
			var book = GetBook(id);
			book.UserId = null;
			book.IsAvailable = true;
		}
	}
}
