using System;

namespace LibraryTestTask
{
	[Serializable]
	internal class Book : EntityBase
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public bool IsAvailable { get; set; }
		public uint? UserId { get; set; }
	}
}
