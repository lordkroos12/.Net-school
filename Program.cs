namespace Task4._1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DiagonalMatrix<int> matrix1 = new DiagonalMatrix<int>(3);
			matrix1[0, 0] = 2;
			matrix1[1, 1] = 2;
			matrix1[2, 2] = 2;

			DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(3);
			matrix2[0, 0] = 3;
			matrix2[1, 1] = 3;
			matrix2[2, 2] = 3;

			DiagonalMatrix<int> sumMatrix = matrix1.Add(matrix2, (x, y) => x + y);

			Console.WriteLine("Sum Matrix:");
			for (int i = 0; i < sumMatrix.Size; i++)
			{
				for (int j = 0; j < sumMatrix.Size; j++)
				{
					Console.Write(sumMatrix[i, j] + " ");
				}
				Console.WriteLine();
			}

			MatrixTracker<int> matrixTracker = new MatrixTracker<int>(matrix1);
			matrix1[0, 0] = 22;
			Console.WriteLine("Matrix after change:");
			for (int i = 0; i < matrix1.Size; i++)
			{
				for (int j = 0; j < matrix1.Size; j++)
				{
					Console.Write(matrix1[i, j] + " ");
				}
				Console.WriteLine();
			}

			matrixTracker.Undo();
			Console.WriteLine("Matrix after undo:");
			for (int i = 0; i < matrix1.Size; i++)
			{
				for (int j = 0; j < matrix1.Size; j++)
				{
					Console.Write(matrix1[i, j] + " ");
				}
				Console.WriteLine();
			}
		
	}
	}
}
