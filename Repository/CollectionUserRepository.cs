namespace LibraryTestTask
{
	internal class CollectionUserRepository : CollectionRepositoryBase<User>, IUserRepository
	{
		public CollectionUserRepository(DataSource dataSource) : base(dataSource)
		{
		}
	}
}
