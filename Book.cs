namespace LibraryTestTask
{
	internal class Book
	{
		public uint Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public bool IsAvailable { get; set; }
		public uint? UserId { get; set; }
	}
}
