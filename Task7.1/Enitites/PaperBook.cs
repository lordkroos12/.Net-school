using Newtonsoft.Json.Linq;
using Task7.Interfaces;

namespace Task7.Enitites
{
    public class PaperBook : IBook
    {
		private string title;

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentException("Length must be less than 200 symbols!");
                }
                title = value;
            }
        }
        public DateTime? PublicationDate { get; set; }
        private string publisher;

        public string Publisher
        {
            get { return publisher; }
            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentException("Length must be less than 200 symbols!");
                }
                publisher = value;
            }
        }

        public List<Author> Authors { get; set; }

        public List<string> Isbns { get; set; }

		public PaperBook(string title, List<string> isbns, string publisher, DateTime? publicationDate = null, IEnumerable<Author> authors = null)
        
        {
            Title =  title;
            Isbns = isbns.Count != 0 ? isbns : throw new ArgumentNullException("Isbns empty");
            Publisher = string.IsNullOrEmpty(publisher) ? throw new ArgumentException("Publisher empty.") : publisher;
            PublicationDate = publicationDate;
            Authors = (authors ?? new List<Author>()).Distinct().ToList();
		}
        public PaperBook()
        {

        }

        public string GetKey()
        {
            return Isbns[0];
        }
    }
}
