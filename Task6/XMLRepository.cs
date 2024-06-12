using System.Xml.Serialization;

namespace Task6
{
	internal class XMLRepository : IRepository
	{
		public void SaveCatalog(Catalog catalog,string filePath)
		{
			var serializer = new XmlSerializer(typeof(List<Book>));
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				serializer.Serialize(stream, catalog.GetAllBooks());
			}
		}

		public Catalog LoadCatalog(string filePath)
		{
			var serializer = new XmlSerializer(typeof(List<Book>));
			using (var stream = new FileStream(filePath, FileMode.Open))
			{
				var books = (List<Book>)serializer.Deserialize(stream);
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
