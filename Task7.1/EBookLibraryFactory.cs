using Task7.Enitites;
using Task7.Interfaces;

namespace Task7
{
	internal class EBookLibraryFactory : ILibrary
	{
		public string Path { get; }

        public EBookLibraryFactory(string path)
        {
            this.Path = path;
        }
        public Library CreateLibrary()
		{
			var  (_,EBookLibrary) =  GetCSVData.LoadLibrary(Path);
			return EBookLibrary;

		}
	}
}
