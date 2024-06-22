using Task7.Enitites;

namespace Task7.Interfaces
{
    internal interface IRepository
    {
        void SaveCatalog(Catalog catalog, string filePath);
        Catalog LoadCatalog(string filePath);
    }
}
