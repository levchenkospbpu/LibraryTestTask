namespace LibraryTestTask
{
	internal class CollectionBookRepository : IBookRepository
	{
		private DataSource _dataSource;

		public Book Add(Book item)
		{
			_dataSource.Books.Add(item);
			return item;
		}

		public bool Remove(Book item)
		{
			return _dataSource.Books.Remove(item);
		}

		public Book[] Select()
		{
			return _dataSource.Books.ToArray();
		}
	}
}
