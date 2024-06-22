
using System.Xml.Serialization;
using Task8.DTOs;
using Task8.Enitites;
using Task8.Interfaces;

namespace Task8.Repositories
{
	internal class XMLPaperBook:IRepository
	{
		public  void SaveCatalog(Catalog catalog, string filePath)
		{
			var serializer = new XmlSerializer(typeof(List<PaperBook>));
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				var paperbooks = catalog.GetAllPaperBooks();
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
