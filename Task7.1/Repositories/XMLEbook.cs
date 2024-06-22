using System.Xml.Serialization;
using Task7.Enitites;
using Task7.Interfaces;

namespace Task7.Repositories
{
	internal class XMLEbook : IRepository
	{
		public void SaveCatalog(Catalog catalog, string filePath)
		{
			var serializer = new XmlSerializer(typeof(List<EBook>));
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				var ebooks = catalog.GetAllEBooks();
				serializer.Serialize(stream, ebooks);
			}
		}
		public  Catalog LoadCatalog(string filePath)
		{
			var serializer = new XmlSerializer(typeof(List<EBook>));
			using (var stream = new FileStream(filePath, FileMode.Open))
			{
				var books = (List<EBook>)serializer.Deserialize(stream);
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
