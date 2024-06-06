namespace LibraryTestTask
{
	internal interface IRepository<T>
	{
		T[] Select();
		T Add(T item);
		bool Remove(T item);
	}
}
