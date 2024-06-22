using Task8.Enitites;

namespace Task8.Factories
{
    internal class EBookLibraryFactory : AbstractFactory
    {
        public string Path { get; }

        public EBookLibraryFactory(string path)
        {
            Path = path;
        }

        public override Catalog CreateCatalog()
        {
            var EBookLibrary = GetCSVData.LoadEbookLibrary(Path);
            return EBookLibrary;
        }

        public override List<string> CreatePressItems()
        {
            var  formats = GetCSVData.LoadFormats(Path);
            return formats;
        }
    }
}
