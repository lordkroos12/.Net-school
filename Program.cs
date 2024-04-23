namespace Task1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int a, b;
			do
			{
				Console.WriteLine("Enter two positive integers a and b:");
				a = int.Parse(Console.ReadLine());
				b = int.Parse(Console.ReadLine());

				if (a <= 0 || b <= 0)
				{
					Console.WriteLine("Both a and b must be positive integers. Please try again.");
				}
			} while (a <= 0 || b <= 0);


			int start = Math.Min(a, b);
			int end = Math.Max(a, b);
			Console.WriteLine($"In range [{start}, {end}] with exactly two 'A's in duodecimal representation:");

			for (int i = start; i <= end; i++)
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
