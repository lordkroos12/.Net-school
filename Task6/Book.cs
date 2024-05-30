using System.Text.RegularExpressions;

namespace Task6
{
	public class Book
	{
		private static readonly Regex IsbnRegex = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$|^\d{13}$");

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
		public List<Author> Authors { get; set; }

		private string isbn;

		public string Isbn
		{
			get { return isbn; }
			set {
                if (!IsbnRegex.IsMatch(value))
                {
					throw new ArgumentException("The format of the isbn is not valid");
                }
                isbn = value; 
			}
		}

		public Book(string title,string isbn, DateTime pubDate, IEnumerable<Author> authors)
		{
			this.title = title;
			this.Isbn = isbn;
			this.PublicationDate = pubDate;
			this.Authors = (authors ?? new List<Author>()).Distinct().ToList();
		}
        private Book()
        {
            
        }
    }
}
