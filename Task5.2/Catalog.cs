using System.Collections;
using System.Text.RegularExpressions;

namespace Task5._2
{
	internal class Catalog : IEnumerable
	{
		private readonly Dictionary<string, Book> catalog;

		public Catalog()
		{
			catalog = new Dictionary<string, Book>();
		}

		public void AddBook(string isbn, Book book)
		{
			if (string.IsNullOrEmpty(isbn) || !Regex.IsMatch(isbn, @"^\d{3}-\d-\d{2}-\d{6}-\d$|^\d{13}$"))
			{
				throw new ArgumentException("Invalid Isbn");
			}
			string cleanIsbn = FormattedIsbn(isbn);
			catalog[cleanIsbn] = book;
		}

		private string FormattedIsbn(string isbn)
		{
			return isbn.Replace("-", "");
		}
		public Book GetBook(string isbn)
		{
			string normalizedISBN = FormattedIsbn(isbn);
			if (catalog.TryGetValue(isbn, out Book book))
			{
				return book;
			}
			return null;
		}
		public IEnumerable<string> GetTiles()
		{
			return catalog.Values.Select(x => x.Title).OrderBy(x => x);
		}
		public IEnumerable<Book> GetBooksByAuthor(string authorName)
		{
			return catalog.Values.OrderBy(x => x.PublicationDate).Where(x => x.Authors.Contains(authorName));
		}
		public IEnumerable<(string,int)> GetAuthorsBookCount()
		{
			 return catalog.Values
			.SelectMany(b => b.Authors)
			.GroupBy(author => author)
			.Select(group => (Author: group.Key, BookCount: group.Count()))
			.OrderBy(result => result.Author);
		}
		public IEnumerator<Book> GetEnumerator()
		{
			return catalog.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
