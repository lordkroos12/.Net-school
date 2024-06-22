using Task8.Enitites;

namespace Task8.Interfaces
{
    public interface IBook
    {
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        string GetKey();

        const int limit= 200;
    }
}
