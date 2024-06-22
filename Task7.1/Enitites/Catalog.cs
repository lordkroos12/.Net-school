using Task7.Interfaces;

namespace Task7.Enitites
{
    [Serializable]
    public class Catalog
    {
		public Dictionary<string, IBook> catalog;

        public Catalog()
        {
            catalog = new Dictionary<string, IBook>();
        }

        public void AddBook(IBook book)
        {
            catalog[book.GetKey()] = book;
        }
        public IBook GetBook(string isbn)
        {
            if (catalog.TryGetValue(isbn, out IBook book))
            {
                return book;
            }
            return default;
        }

        public List<IBook> GetAllBooks()
        {
            return catalog.Values.ToList();
        }
        public IEnumerable<IBook> GetBooksByAuthor(Author author)
        {
            return catalog.Values.Where(x => x.Authors.Contains(author));
        }
		public List<EBook> GetAllEBooks()
		{
			return catalog.Values.OfType<EBook>().ToList();
		}
		public List<PaperBook> GetAllPaperBooks()
		{
			return catalog.Values.OfType<PaperBook>().ToList();
		}


	}
}
