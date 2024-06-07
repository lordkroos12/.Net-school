using Task7.Enitites;

namespace Task7.Interfaces
{
    internal interface ILibrary
    {
        public string Path { get; }
        Library CreateLibrary();
    }
}
