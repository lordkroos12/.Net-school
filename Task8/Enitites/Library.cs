using Task8.Factories;

namespace Task8.Enitites
{
	internal class Library
	{
		private Catalog _catalog;
		private List<string> _pressReleaseItems;
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
