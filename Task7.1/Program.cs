using Task7.Enitites;
using Task7.Interfaces;
using Task7.Repositories;

namespace Task7
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string csvFilePath = "books_info.csv";

			// Create libraries using factories
			ILibrary paperBookFactory = new PaperBookLibraryFactory(csvFilePath);
			Library paperBookLibrary = paperBookFactory.CreateLibrary();
            ILibrary eBookFactory = new EBookLibraryFactory(csvFilePath);
			Library eBookLibrary = eBookFactory.CreateLibrary();

			//var xmlRepository = new XMLPaperBook();
			//xmlRepository.SaveCatalog(paperBookLibrary.Catalog, "paperBookCatalog.xml");
			//var loadedPaperBookCatalog = xmlRepository.LoadCatalog("paperBookCatalog.xml");
			
			var jsonRepository = new JSONEBookRepository();
			jsonRepository.SaveCatalog(eBookLibrary.Catalog, "JsonCatalog.json");
			var loadedEBookCatalog = jsonRepository.LoadCatalog("JsonCatalog.json");
            Console.WriteLine();
        }
	}
}
