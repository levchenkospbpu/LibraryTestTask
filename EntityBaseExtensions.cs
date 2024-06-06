using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

namespace LibraryTestTask
{
	internal static class EntityBaseExtensions
	{
		public static T GetDeepCopy<T>(this T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity), "The object to copy cannot be null");
			}

			using (MemoryStream memoryStream = new MemoryStream())
			{
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(memoryStream, entity);
				memoryStream.Seek(0, SeekOrigin.Begin);
				return (T)formatter.Deserialize(memoryStream);
			}
		}
	}
}
