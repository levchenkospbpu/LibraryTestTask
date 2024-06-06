using System.Linq.Expressions;
using System.Linq;
using System;

namespace LibraryTestTask
{
	internal abstract class CollectionRepositoryBase<T> where T : EntityBase
	{
		private DataSource _dataSource;

		public CollectionRepositoryBase(DataSource dataSource)
		{
			_dataSource = dataSource;
		}

		public T Create(T item)
		{
			try
			{
				if (item == null)
				{
					throw new ArgumentNullException();
				}

				var dataSource = _dataSource.Set<T>();

				checked
				{
					if (dataSource.Count > 0)
					{
						item.Id = dataSource.Last().Id + 1;
					}
					else
					{
						item.Id = 1;
					}
				}

				dataSource.Add(item);
			}

			catch (ArgumentNullException)
			{
				Console.WriteLine($"Null argument when trying to create a {nameof(T)}");
				return null;
			}

			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}

			catch (OverflowException)
			{
				Console.WriteLine("Id value has exceeded the maximum allowed value");
				return null;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return null;
			}

			return item.GetDeepCopy();
		}

		public bool Delete(T item)
		{
			bool wasDeleted;
			try
			{
				if (item == null)
				{
					throw new ArgumentNullException();
				}

				wasDeleted = _dataSource.Set<T>().Remove(item);
			}

			catch (ArgumentNullException)
			{
				Console.WriteLine($"Null argument when trying to delete a {nameof(T)}");
				return false;
			}

			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return false;
			}

			return wasDeleted;
		}

		public T[] Select()
		{
			try
			{
				return _dataSource.Set<T>().Select(x => x.GetDeepCopy()).ToArray();
			}

			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return null;
			}
		}

		public T[] Select(Expression<Func<T, bool>> predicate)
		{
			try
			{
				return _dataSource.Set<T>().AsQueryable().Where(predicate).Select(x => x.GetDeepCopy()).ToArray();
			}

			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return null;
			}
		}

		public void Update(T item)
		{
			try
			{
				if (item == null)
				{
					throw new ArgumentNullException();
				}

				var dataSet = _dataSource.Set<T>();
				var itemOld = dataSet.FirstOrDefault(x => x.Id == item.Id);

				if (itemOld == default)
				{
					throw new ArgumentException($"Trying to update a {nameof(T)} that doesn't exist");
				}

				var itemIndex = dataSet.IndexOf(itemOld);
				dataSet[itemIndex] = item.GetDeepCopy(); ;
			}

			catch (ArgumentNullException)
			{
				Console.WriteLine($"Null argument when trying to update a {nameof(T)}");
			}

			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
			}
		}
	}
}
