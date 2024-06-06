using System;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryTestTask
{
	internal class CollectionBookRepository : CollectionRepositoryBase<Book>, IBookRepository
	{
		public CollectionBookRepository(DataSource dataSource) : base(dataSource)
		{
		}
	}
}
