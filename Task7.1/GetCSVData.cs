using CsvHelper;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Task7.DTOs;
using Task7.Enitites;
using Task7.Interfaces;

namespace Task7
{
	internal class GetCSVData
	{

		public static (Library PaperBook, Library Ebook) LoadLibrary(string path)
		{
			var paperBooks = new List<PaperBook>();
			var eBooks = new List<EBook>();
			var publishers = new List<string>();
			var formats = new List<string>();

			using (StreamReader sr = new StreamReader(path))
			{
				using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
				{
					var rows = csv.GetRecords<BookCsvDto>();
					foreach (var record in rows)
					{
						if (record.related.Contains("urn:isbn"))
						{
							string pattern = @"^\d{4}-";
							string title = record.title;
							List<string> isbns = new List<string>();
							var relatedIds = record.related.Split(",").ToList();
							foreach (var item in relatedIds)
							{
								var id = item.Split(":").ToList();
								isbns.Add(id[2]);
							}
							DateTime date = DateTime.Parse(record.publicdate);
							string publisher = record.publisher;
							List<Author> authors = GetAuthorsFromCsv(record.creator);
							PaperBook pb = new PaperBook(title, isbns, publisher, date, authors);
							paperBooks.Add(pb);
						}
						else
						{
							List<Author> authors = GetAuthorsFromCsv(record.creator);
							string title = record.title;
							var format = record.format.Split(",").ToList();
							string identifier = record.identifier;
							EBook book = new EBook(title, identifier, formats, authors);
							eBooks.Add(book);
						}

					}
				}
				var paperBookCatalog = new Catalog();
				foreach (var book in paperBooks)
				{
					paperBookCatalog.AddBook(book);
				}

				var eBookCatalog = new Catalog();
				foreach (var book in eBooks)
				{
					eBookCatalog.AddBook(book);
				}

				var paperBook = new Library(paperBookCatalog, publishers);
				var eBook = new Library(eBookCatalog, formats);

				return (paperBook, eBook);
			}
		}
		private static List<Author> GetAuthorsFromCsv(string authorsString)
		{
			var authorsList = new List<Author>();

			if (!string.IsNullOrEmpty(authorsString))
			{
				var authors = authorsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

				for (int i = 0; i < authors.Length; i++)
				{
					var fullName = authors[i].Trim();
					DateOnly? birthDate = null;

					if (i + 1 < authors.Length && authors[i + 1].Any(char.IsDigit))
					{
						var datePart = authors[i + 1].Trim();
						var dateSegments = datePart.Split('-');

						if (dateSegments.Length > 0 && int.TryParse(dateSegments[0], out int year))
						{
							birthDate = new DateOnly(year, 1, 1);
						}

						i++;
					}

					var nameParts = fullName.Split(' ');

					if (nameParts.Length >= 1)
					{
						var firstName = nameParts[0];
						var lastName = nameParts.Length >= 2 ? nameParts[nameParts.Length - 1] : "";

						authorsList.Add(new Author(firstName, lastName, birthDate));

					}
				}
			}
			return authorsList;
		}

	}
}
