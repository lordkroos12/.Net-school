using Task7.Enitites;
using Task7.Interfaces;

namespace Task7
{
	internal class PaperBookLibraryFactory : ILibrary
	{
		public string Path { get; }

		public PaperBookLibraryFactory(string path)
		{
			this.Path = path;
		}
		public Library CreateLibrary()
		{
			var (PaperBookLibrary, _) = GetCSVData.LoadLibrary(Path);
			return PaperBookLibrary;

		}
	}
}
