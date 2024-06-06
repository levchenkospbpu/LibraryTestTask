namespace LibraryTestTask
{
	internal class CollectionBookRepository : CollectionRepositoryBase<Book>, IBookRepository
	{
		public CollectionBookRepository(DataSource dataSource) : base(dataSource)
		{
		}
	}
}
