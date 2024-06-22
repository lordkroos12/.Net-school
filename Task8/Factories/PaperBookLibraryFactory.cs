using Task8.Enitites;

namespace Task8.Factories
{
    internal class PaperBookLibraryFactory : AbstractFactory
    {
        public string Path { get; }

        public PaperBookLibraryFactory(string path)
        {
            Path = path;
        }
        public override Catalog CreateCatalog()
        {
            var PaperBookLibrary = GetCSVData.LoadPaperBookLibrary(Path);
            return PaperBookLibrary;
        }

        public override List<string> CreatePressItems()
        {
            var publishers = GetCSVData.LoadPublishers(Path);
            return publishers;
        }
    }
}
