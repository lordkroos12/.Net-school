namespace Task1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter a and b:");
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());

			Console.WriteLine($"In range [{a}, {b}] with exactly two 'A's in duodecimal representation:");

			for (int i = a; i <= b; i++)
			{
				if (CountAInDuodecimal(i) == 2)
				{
					Console.WriteLine($"{i} (in decimal)");
				}

			}

		}
		static int CountAInDuodecimal(int n)
		{
			int count = 0;
			while (n > 0)
			{
				if (n % 12 == 10)
				{
					count++;
				}
				n /= 12;
			}
			return count;
		}
	}
}
