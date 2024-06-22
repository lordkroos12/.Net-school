using Task8.Enitites;

namespace Task8.Interfaces
{
    internal interface IRepository
    {
        void SaveCatalog(Catalog catalog, string filePath);
        Catalog LoadCatalog(string filePath);
    }
}
