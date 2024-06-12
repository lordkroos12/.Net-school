namespace Task6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var author1 = new Author("Nick", "Phenom", new DateTime(1984, 6, 22));
			var author2 = new Author("Jada", "Olderson", new DateTime(1979, 7, 16));

			// Create books
			var book1 = new Book("C# Programming", "123-4-56-789012-2", new DateTime(2022, 11, 21), new List<Author> { author1 });
			var book2 = new Book("Advanced C#", "1234567890122", new DateTime(2009, 2, 11), new List<Author> { author1, author2 });
			var book3 = new Book("Learning XML", "987-6-54-321098-7", new DateTime(2014, 6, 6), new List<Author> { author2 });
			var book4 = new Book("JSON for Beginners", "9876543210977", new DateTime(2011, 5, 3), new List<Author> { author1 });

			// Create catalog
			var catalog = new Catalog();
			catalog.AddBook(book1);
			catalog.AddBook(book2);
			catalog.AddBook(book3);
			catalog.AddBook(book4);

			// Save XML
			var xmlRepository = new XMLRepository();
			xmlRepository.SaveCatalog(catalog, "catalog.xml");

			// Load XML
			var loadedCatalogFromXml = xmlRepository.LoadCatalog("catalog.xml");

			//Save JSON

			var jsonRepository = new JSONRepository();
			jsonRepository.SaveCatalog(catalog, "JsonCatalog");

            // Load JSON
            var loadedCatalogFromJson = jsonRepository.LoadCatalog("JsonCatalog");
            Console.WriteLine(	);
        }
	}
}
