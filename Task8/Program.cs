using Task8.Enitites;
using Task8.Factories;
using Task8.Repositories;
using Task8.Services;

namespace Task8
{
    internal class Program
	{
		static async Task Main(string[] args)
		{
			string csvFilePath = "books_info.csv";

			// Create libraries using factories
			AbstractFactory ebookFactory = new EBookLibraryFactory(csvFilePath);
			AbstractFactory paperBookFactory = new PaperBookLibraryFactory(csvFilePath);
			Library paperBookLibrary = new Library(paperBookFactory);
            Library eBookLibrary = new Library(ebookFactory);

			AddPageCountService addPageCountService = new AddPageCountService(new RetrievePageService());
			await addPageCountService.AddPageCount(eBookLibrary);

			var xmlRepository = new XMLPaperBook();
			xmlRepository.SaveCatalog(paperBookLibrary.GetCatalog(), "paperBookCatalog.xml");
			var loadedPaperBookCatalog = xmlRepository.LoadCatalog("paperBookCatalog.xml");

			var jsonRepository = new JSONEBookRepository();
			jsonRepository.SaveCatalog(eBookLibrary.GetCatalog(), "JsonCatalog.json");
			var loadedEBookCatalog = jsonRepository.LoadCatalog("JsonCatalog.json");

			foreach (var item in eBookLibrary.GetCatalog().GetAllBooks())
			{
				if (item is EBook eBook)
				{
                    await Console.Out.WriteLineAsync($"{eBook.Pages}");
                }
			}
            Console.WriteLine();
        }
	}
}
