using System;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryTestTask
{
	internal class CollectionBookRepository : IBookRepository
	{
		private DataSource _dataSource;

		public CollectionBookRepository(DataSource dataSource)
		{
			_dataSource = dataSource;
		}

		public Book Create(Book book)
		{
			try
			{
				if (book == null)
				{
					throw new ArgumentNullException();
				}

				checked
				{
					if (_dataSource.Books.Count > 0)
					{
						book.Id = _dataSource.Users.Last().Id + 1;
					}
					else
					{
						book.Id = 1;
					}
				}

				_dataSource.Books.Add(book);
			}

			catch (ArgumentNullException)
			{
				Console.WriteLine("Null argument when trying to create a book");
				return null;
			}

			catch (OverflowException)
			{
				Console.WriteLine("Id value has exceeded the maximum allowed value");
				return null;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return null;
			}

			return book;
		}

		public bool Delete(Book item)
		{
			bool wasDeleted;
			try
			{
				if (item == null)
				{
					throw new ArgumentNullException();
				}
				wasDeleted = _dataSource.Books.Remove(item);
			}

			catch (ArgumentNullException)
			{
				Console.WriteLine("Null argument when trying to delete a book");
				return false;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return false;
			}

			return wasDeleted;
		}

		public Book[] Select()
		{
			return (Book[])_dataSource.Books.ToArray().Clone();
		}

		public Book[] Select(Expression<Func<Book, bool>> predicate)
		{
			return (Book[])_dataSource.Books.AsQueryable().Where(predicate).ToArray().Clone();
		}

		public void Update(Book book)
		{
			try
			{
				if (book == null)
				{
					throw new ArgumentNullException();
				}

				var bookOld = _dataSource.Books.Where(x => x.Id == book.Id).FirstOrDefault();

				if (bookOld == default)
				{
					throw new ArgumentException();
				}

				bookOld.Title = book.Title;
				bookOld.Author = book.Author;
				bookOld.UserId = book.UserId;
				bookOld.IsAvailable = book.IsAvailable;
			}
			catch (ArgumentNullException)
			{
				Console.WriteLine("Null argument when trying to update a book");
			}
			catch (ArgumentException)
			{
				Console.WriteLine("Trying to update a book that doesn't exist");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
			}
		}
	}
}
