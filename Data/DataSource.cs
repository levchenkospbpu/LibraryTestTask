using System;
using System.Collections.Generic;

namespace LibraryTestTask
{
	internal class DataSource
	{
		private List<User> _users= new List<User>
		{
			new User{ Id = 1, Name = "Иван Иванов"},
			new User{ Id = 2, Name = "Петр Петров"},
			new User{ Id = 3, Name = "Алексей Алексеев"},
		};

		private List<Book> _books = new List<Book>
		{
			new Book{Id = 1, Title = "Преступление и наказание", Author = "Фёдор Михайлович Достоевский", IsAvailable = true, UserId = null },
			new Book{Id = 2, Title = "Война и мир", Author = "Лев Николаевич Толстой", IsAvailable = false, UserId = 1 },
			new Book{Id = 3, Title = "Государство", Author = "Платон", IsAvailable = false, UserId = 2 },
		};

		public List<T> Set<T>() where T : EntityBase
		{
			if (typeof(T) == typeof(User))
			{
				return _users as List<T>;
			}
			else if (typeof(T) == typeof(Book))
			{
				return _books as List<T>;
			}
			else
			{
				throw new ArgumentException($"No data for type {nameof(T)}");
			}
		}
	}
}
