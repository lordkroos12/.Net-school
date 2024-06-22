using Task8.Enitites;
using Task8.Interfaces;

namespace Task8.Services
{
	internal class AddPageCountService
	{
		private readonly IRetrievePagesService _retrievePagesService;

		public AddPageCountService(IRetrievePagesService retrievePagesService)
        {
			_retrievePagesService = retrievePagesService;
		}

		public async Task AddPageCount(Library lib)
		{

			foreach (var item in lib.GetCatalog().GetAllBooks())
			{
				int pageCount = await _retrievePagesService.LoadPages(item.GetKey());
				if (item is EBook eBook)
				{
					eBook.Pages = pageCount;
				}
			}
			
		}
    }
}
