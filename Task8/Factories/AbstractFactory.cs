using Task8.Enitites;
using Task8.Interfaces;

namespace Task8.Factories
{
    internal abstract class AbstractFactory
    {
        public abstract Catalog CreateCatalog();
        public abstract List<string> CreatePressItems();
    }
}
