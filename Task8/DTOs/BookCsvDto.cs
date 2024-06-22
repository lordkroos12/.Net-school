using CsvHelper.Configuration.Attributes;

namespace Task8.DTOs
{
	[Serializable]
	public class BookCsvDto
	{
		public string creator { get; set; }
		public string format { get; set; }
		public string identifier { get; set; }
		public string publicdate { get; set; }
		[Name("related-external-id")]
		public string related { get; set; }
		public string publisher { get; set; }
		public string title { get; set; }		
	}
}
