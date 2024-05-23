namespace Task5._2
{
	internal class Book
	{
		private string title;

		public string Title
		{
			get { return title; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Invalid Title");
				title = value;
			}
		}
        public DateTime? PublicationDate { get; set; }
        public List<string> Authors { get; set; }
        public Book(string title, DateTime pubDate, IEnumerable<string> authors)
        {
            this.title = title; 
			this.PublicationDate = pubDate;
			this.Authors = (authors ?? new List<string>()).Distinct().ToList();
        }

    }
}
