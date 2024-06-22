using HtmlAgilityPack;
using System.Net;
using System.Xml;
using Task8.Interfaces;

namespace Task8.Services
{
	internal class RetrievePageService : IRetrievePagesService
	{
		public async Task<int> LoadPages(string identifier)
		{
			string url = $"https://archive.org/details/{identifier}";
			string htmlContent = await DownloadContentAsync(url);
			string numberOfPages = "";
			if (!String.IsNullOrEmpty(htmlContent))
			{
				numberOfPages = ExtractNumberOfPages(htmlContent);

			}
			return int.Parse(numberOfPages);
			
		}

		private async Task<string> DownloadContentAsync(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					HttpResponseMessage responseMessage = await client.GetAsync(url);
					responseMessage.EnsureSuccessStatusCode();
					return await responseMessage.Content.ReadAsStringAsync();
				}
				catch (Exception ex)
				{
					throw new ArgumentException("Cannot download content");
				}
			}
		}
		private string ExtractNumberOfPages(string htmlContent)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(htmlContent);
			HtmlNode node = doc.DocumentNode.SelectSingleNode("//span[@itemprop='numberOfPages']");
			return node?.InnerText ?? "Not found";
		}
	}
}
