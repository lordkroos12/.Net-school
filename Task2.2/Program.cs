namespace Task2._2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DiagonalMatrix matrix1 = new DiagonalMatrix(1, 3, 2);
			DiagonalMatrix matrix2 = new DiagonalMatrix(2, 2, 3, 9);

			Console.WriteLine(matrix1.Track());
			Console.WriteLine(matrix2.Track()); 

			DiagonalMatrix result = matrix1.Add(matrix2);
			Console.WriteLine(result.Track()); 

			Console.WriteLine(matrix1.Equals(matrix2));
			Console.WriteLine(matrix1.Equals(new DiagonalMatrix(1, 3, 2)));
		}
	}
}
