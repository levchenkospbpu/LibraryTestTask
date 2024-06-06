using System;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryTestTask
{
	internal class CollectionUserRepository : CollectionRepositoryBase<User>, IUserRepository
	{
		public CollectionUserRepository(DataSource dataSource) : base(dataSource)
		{
		}
	}
}
