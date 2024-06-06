namespace LibraryTestTask
{
	internal class CollectionUserRepository : IUserRepository
	{
		private DataSource _dataSource;

		public User Add(User item)
		{
			_dataSource.Users.Add(item);
			return item;
		}

		public bool Remove(User item)
		{
			return _dataSource.Users.Remove(item);
		}

		public User[] Select()
		{
			return _dataSource.Users.ToArray();
		}
	}
}
