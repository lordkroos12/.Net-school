using Task7.Enitites;
using Task7.Factories;
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
			AbstractFactory ebookFactory = new EBookLibraryFactory(csvFilePath);
			AbstractFactory paperBookFactory = new PaperBookLibraryFactory(csvFilePath);
			Library paperBookLibrary = new Library(paperBookFactory);
            Library eBookLibrary = new Library(ebookFactory);

			var xmlRepository = new XMLPaperBook();
			xmlRepository.SaveCatalog(paperBookLibrary.GetCatalog(), "paperBookCatalog.xml");
			var loadedPaperBookCatalog = xmlRepository.LoadCatalog("paperBookCatalog.xml");

			var jsonRepository = new JSONEBookRepository();
			jsonRepository.SaveCatalog(eBookLibrary.GetCatalog(), "JsonCatalog.json");
			var loadedEBookCatalog = jsonRepository.LoadCatalog("JsonCatalog.json");
            Console.WriteLine();
        }
	}
}
