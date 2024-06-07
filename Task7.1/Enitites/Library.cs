using Task7.Interfaces;

namespace Task7.Enitites
{
    internal class Library
    {
        public Catalog Catalog { get; }
        public List<string> PressReleaseItems { get; }

        public Library(Catalog catalog, List<string> pressReleaseItems)
        {
            Catalog = catalog ?? throw new ArgumentNullException("Catalog is null");
            PressReleaseItems = pressReleaseItems ?? throw new ArgumentNullException("PressReleaseItems is null");
        }
    }
}
