using Task7.Enitites;

namespace Task7.Interfaces
{
    public interface IBook
    {
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        string GetKey();
    }
}
