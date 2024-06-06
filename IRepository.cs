using System.Linq.Expressions;
using System;

namespace LibraryTestTask
{
	internal interface IRepository<T>
	{
		T[] Select();
		T[] Select(Expression<Func<T, bool>> predicate);
		T Create(T item);
		bool Delete(T item);
		void Update(T item);
	}
}
