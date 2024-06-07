using System.Xml.Serialization;
using Task7.Enitites;
using Task7.Interfaces;

namespace Task7.Repositories
{
	internal class XMLEbook
	{
		public void SaveCatalog(Catalog catalog, string filePath)
		{
			var serializer = new XmlSerializer(typeof(Catalog));
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				serializer.Serialize(stream, catalog);
			}
		}
		public static Catalog LoadCatalog<PaperBook>(string filePath)
		{
			var serializer = new XmlSerializer(typeof(List<EBook>));
			using (var stream = new FileStream(filePath, FileMode.Open))
			{
				var books = (List<IBook>)serializer.Deserialize(stream);
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
