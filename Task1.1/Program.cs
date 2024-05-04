namespace Task1
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("Enter two  integers a and b:");
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());


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
