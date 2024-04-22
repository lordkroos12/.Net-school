namespace Task3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter the number of elements in the array: ");
			int n = int.Parse(Console.ReadLine());

			int[] originalArray = new int[n];

			for (int i = 0; i < n; i++)
			{
				Console.Write($"Enter element {i + 1}: ");
				originalArray[i] = int.Parse(Console.ReadLine());
			}

			int[] uniqueArray = RemoveDuplicates(originalArray);

			Console.WriteLine("Array:");
			PrintArray(originalArray);

			Console.WriteLine("Array without repetitions:");
			PrintArray(uniqueArray);
		}
		static int[] RemoveDuplicates(int[] arr)
		{
			bool[] visited = new bool[arr.Length];
			int uniqueCount = 0;

			for (int i = 0; i < arr.Length; i++)
			{
				if (!visited[i])
				{
					uniqueCount++;

					for (int j = i + 1; j < arr.Length; j++)
					{
						if (arr[i] == arr[j])
						{
							visited[j] = true;
						}
					}
				}
			}

			int[] uniqueArray = new int[uniqueCount];
			int index = 0;

			for (int i = 0; i < arr.Length; i++)
			{
				if (!visited[i])
				{
					uniqueArray[index++] = arr[i];
				}
			}

			return uniqueArray;
		}

		static void PrintArray(int[] arr)
		{
			foreach (int num in arr)
			{
				Console.Write(num + " ");
			}
			Console.WriteLine();
		}
	}
}
