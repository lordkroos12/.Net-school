namespace Task6
{
	[Serializable]
	public class Catalog 
	{
		public  Dictionary<string, Book> catalog;

		public Catalog()
		{
			catalog = new Dictionary<string, Book>();
		}

		public void AddBook(Book book)
		{
			if (catalog.ContainsKey(FormattedIsbn(book.Isbn)))
			{
				throw new ArgumentException("Book is already added!");
			}
			catalog[book.Isbn] = book;
		}

		private string FormattedIsbn(string isbn)
		{
			return $"{isbn.Substring(0, 3)}-{isbn.Substring(3, 1)}-{isbn.Substring(4, 2)}-{isbn.Substring(6, 6)}-{isbn.Substring(12, 1)}";
		}
		public Book GetBook(string isbn)
		{
			string normalizedISBN = FormattedIsbn(isbn);
			if (catalog.TryGetValue(normalizedISBN, out Book book))
			{
				return book;
			}
			return null;
		}

		public List<Book> GetAllBooks()
		{
			return catalog.Values.ToList();
		}
		public IEnumerable<Book> GetBooksByAuthor(Author author)
		{
			return catalog.Values.Where(x => x.Authors.Contains(author));
		}

	}
}
