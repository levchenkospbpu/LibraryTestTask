using System;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryTestTask
{
	internal class CollectionUserRepository : IUserRepository
	{
		private DataSource _dataSource;

		public CollectionUserRepository(DataSource dataSource)
		{
			_dataSource = dataSource;
		}

		public User Create(User user)
		{
			try
			{
				if (user == null)
				{
					throw new ArgumentNullException();
				}

				checked
				{
					if (_dataSource.Users.Count > 0)
					{
						user.Id = _dataSource.Users.Last().Id + 1;
					}
					else
					{
						user.Id = 1;
					}
				}

				_dataSource.Users.Add(user);
			}

			catch (ArgumentNullException)
			{
				Console.WriteLine("Null argument when trying to create a user");
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

			return user;
		}

		public bool Delete(User user)
		{
			bool wasDeleted;
			try
			{
				if (user == null)
				{
					throw new ArgumentNullException();
				}
				wasDeleted = _dataSource.Users.Remove(user);
			}

			catch (ArgumentNullException)
			{
				Console.WriteLine("Null argument when trying to delete a user");
				return false;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
				return false;
			}

			return wasDeleted;
		}

		public User[] Select()
		{
			return (User[])_dataSource.Users.ToArray().Clone();
		}

		public User[] Select(Expression<Func<User, bool>> predicate)
		{
			return (User[])_dataSource.Users.AsQueryable().Where(predicate).ToArray().Clone();
		}

		public void Update(User user)
		{
			try
			{
				if (user == null)
				{
					throw new ArgumentNullException();
				}

				var userOld = _dataSource.Users.Where(x => x.Id == user.Id).FirstOrDefault();

				if (userOld == default)
				{
					throw new ArgumentException();
				}

                userOld.Name = user.Name;
			}
			catch (ArgumentNullException)
			{
				Console.WriteLine("Null argument when trying to update a user");
			}
			catch (ArgumentException)
			{
				Console.WriteLine("Trying to update a user that doesn't exist");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unexpected exception: " + ex.Message);
			}
		}
	}
}
