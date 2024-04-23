namespace Task2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter the first 9 digits of the ISBN: ");
			string isbnPrefix = Console.ReadLine();
			char checkDigit = CalculateCheckDigit(isbnPrefix);
			string isbn = isbnPrefix + checkDigit;
			Console.WriteLine("The complete ISBN is: " + isbn);
		}
		static char CalculateCheckDigit(string isbn)
		{
			int total = 0;
			for (int i = 0; i < 9; i++)
			{
				total += int.Parse(isbn[i].ToString()) * (10 - i);
			}
<<<<<<< Updated upstream
			int checkDigit = (total) % 11;
=======
			int checkDigit = (11 - (total) % 11) % 11;
>>>>>>> Stashed changes
			return checkDigit == 10 ? 'X' : (char)(checkDigit + '0');
		}
	}
}
