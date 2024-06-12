using Task7.Factories;
using Task7.Interfaces;
using Task7.Repositories;

namespace Task7.Enitites
{
	internal class Library
	{
		private Catalog _catalog;
		private List<string> _pressReleaseItems;
		// Constructor
		public Library(AbstractFactory factory)
		{
			_catalog = factory.CreateCatalog();
			_pressReleaseItems = factory.CreatePressItems();
		}

		public Catalog GetCatalog()
		{
			return _catalog;
		}

	}
}
