using Task7.Enitites;
using Task7.Interfaces;

namespace Task7.Factories
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
            var (PaperBookLibrary, _, _, _) = GetCSVData.LoadLibrary(Path);
            return PaperBookLibrary;
        }

        public override List<string> CreatePressItems()
        {
            var (_, _, publishers, _) = GetCSVData.LoadLibrary(Path);
            return publishers;
        }
    }
}
