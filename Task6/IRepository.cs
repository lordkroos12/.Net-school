namespace Task6
{
	internal interface IRepository
	{
		void SaveCatalog(Catalog catalog, string filePath);
		Catalog LoadCatalog(string filePath);
	}
}
