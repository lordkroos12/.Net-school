using Task7.Enitites;
using Task7.Interfaces;
using Task7.Enitites;

namespace Task7.Factories
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
            var (_, EBookLibrary, _, _) = GetCSVData.LoadLibrary(Path);
            return EBookLibrary;
        }

        public override List<string> CreatePressItems()
        {
            var (_, _, _, formats) = GetCSVData.LoadLibrary(Path);
            return formats;
        }
    }
}
