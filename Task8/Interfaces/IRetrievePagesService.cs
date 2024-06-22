namespace Task8.Interfaces
{
	internal interface IRetrievePagesService
	{
		 Task<int> LoadPages(string identifier);
	}
}
