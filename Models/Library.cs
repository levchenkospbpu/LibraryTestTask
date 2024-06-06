using System.Collections.Generic;

namespace LibraryTestTask
{
	internal class Library
	{
		public ICollection<User> Users { get; set; }
		public ICollection<Book> Books { get; set; }
	}
}
