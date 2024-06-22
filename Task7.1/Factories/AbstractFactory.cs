using Task7.Enitites;
using Task7.Interfaces;

namespace Task7.Factories
{
    internal abstract class AbstractFactory
    {
        public abstract Catalog CreateCatalog();
        public abstract List<string> CreatePressItems();
    }
}
