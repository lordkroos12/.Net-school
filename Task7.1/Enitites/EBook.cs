using Task7.Interfaces;

namespace Task7.Enitites
{
	[Serializable]
	public class EBook : IBook
	{
		const int limit = 200;
		private string title;

		public string Title
		{
			get { return title; }
			set
			{
				if (value.Length > limit)
				{
					throw new ArgumentException("Length must be less than 200 symbols!");
				}
				title = value;
			}
		}
		public List<Author> Authors { get; set; }
		public string InternetResourceIdentifier { get; set; }
		public List<string> ElectronicFormats { get; set; }

		public EBook(string title, string internetResourceIdentifier, List<string> electronicFormats, List<Author> authors = null)
		{
			Title = string.IsNullOrEmpty(title) ? throw new ArgumentException("Title cannot be empty.") : title;
			InternetResourceIdentifier = string.IsNullOrEmpty(internetResourceIdentifier) ? throw new ArgumentException("Internet Resource Identifier cannot be empty.") : internetResourceIdentifier;
			ElectronicFormats = electronicFormats ?? throw new ArgumentNullException("Eformats is empty");
			Authors = authors ?? new List<Author>();
		}
		private EBook()
		{

		}

		public string GetKey() => InternetResourceIdentifier;
	}
}
