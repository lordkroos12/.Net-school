using Newtonsoft.Json;
using Task7.Enitites;
using Task7.Interfaces;

namespace Task7.Repositories
{
	internal class JSONEBookRepository : IRepository
	{
		public Catalog LoadCatalog(string filePath)
		{
			var catalog = new Catalog();

			if (Directory.Exists(filePath))
			{
				var files = Directory.GetFiles(filePath, "*.json");

				foreach (var file in files)
				{
					var json = File.ReadAllText(file);
					var bookDtos = JsonConvert.DeserializeObject<List<EBook>>(json);

					foreach (var bookdto in bookDtos)
					{
						var authors = bookdto.Authors.Select(a => new Author(a.FirstName, a.LastName, a.DateOfBirth)).ToList();
						var book = new EBook(bookdto.Title, bookdto.InternetResourceIdentifier, bookdto.ElectronicFormats, authors);
						if (catalog.GetBook(book.GetKey()) == null)
						{
							catalog.AddBook(book);
						}
					}
				}
			}
			return catalog;
		}

		public void SaveCatalog(Catalog catalog, string filePath)
		{
			if (!Directory.Exists(filePath))
			{
				Directory.CreateDirectory(filePath);
			}
			List<Author> authors = catalog.catalog.Values.SelectMany(x => x.Authors).Distinct().ToList();
			foreach (Author author in authors)
			{
				var books = catalog.GetBooksByAuthor(author).Distinct().ToList();
				string fileName = $"{author.FirstName}_{author.LastName}.json";
				string directory = Path.Combine(filePath, fileName);
				File.WriteAllText(directory, JsonConvert.SerializeObject(books));
			}

		}
	}
}
