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
			set
			{
				if (!IsbnRegex.IsMatch(value))
				{

					throw new ArgumentException("The format of the isbn is not valid");
				}
				value = value.Replace("-", "");
				isbn = value;
			}
		}

		public Book(string title, string isbn, DateTime pubDate, IEnumerable<Author> authors)
		{
			this.title = title;
			this.Isbn = isbn;
			this.PublicationDate = pubDate;
			this.Authors = (authors ?? new List<Author>()).Distinct().ToList();
		}
		private Book()
		{

		}
		public override bool Equals(object obj)
		{
			if (obj is Book otherBook)
			{
				return this.Title == otherBook.Title &&
					   this.Isbn == otherBook.Isbn &&
					   this.PublicationDate == otherBook.PublicationDate &&
					   this.Authors.SequenceEqual(otherBook.Authors);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int hashCode = Title.GetHashCode() ^ Isbn.GetHashCode();
			if (PublicationDate.HasValue)
			{
				hashCode ^= PublicationDate.Value.GetHashCode();
			}
			foreach (var author in Authors)
			{
				hashCode ^= author.GetHashCode();
			}
			return hashCode;
		}
	}
}
