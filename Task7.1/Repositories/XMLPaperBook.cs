
using System.Xml.Serialization;
using Task7.DTOs;
using Task7.Enitites;
using Task7.Interfaces;

namespace Task7.Repositories
{
	internal class XMLPaperBook:IRepository
	{
		public  void SaveCatalog(Catalog catalog, string filePath)
		{
			var serializer = new XmlSerializer(typeof(List<PaperBook>));
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				var paperbooks = catalog.GetAllPaperBooks();
				Console.WriteLine($"Number of EBooks: {paperbooks.Count}");
				foreach (var ebook in paperbooks)
				{
					Console.WriteLine($"EBook ISBN: {ebook.Publisher}, Title: {ebook.Title}");
				}

				serializer.Serialize(stream, paperbooks);
			}
		}
		public  Catalog LoadCatalog(string filePath)
		{
			var serializer = new XmlSerializer(typeof(List<PaperBook>));
			using (var stream = new FileStream(filePath, FileMode.Open))
			{
				var books = (List<PaperBook>)serializer.Deserialize(stream);
				var catalog = new Catalog();
				foreach (var book in books)
				{
					catalog.AddBook(book);
				}
				return catalog;
			}
		}
	}

}
