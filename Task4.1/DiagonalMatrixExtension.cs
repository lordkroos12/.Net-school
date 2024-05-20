namespace Task4._1
{
	public static class DiagonalMatrixExtensions
	{
		public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> matrix1, DiagonalMatrix<T> matrix2, Func<T, T, T> additionFunction)
		{
			if (matrix1.Size != matrix2.Size)
				throw new ArgumentException("Matrices must be of the same size.");

			int size = matrix1.Size;
			DiagonalMatrix<T> result = new DiagonalMatrix<T>(size);

			for (int i = 0; i < size; i++)
			{
				result[i, i] = additionFunction(matrix1[i, i], matrix2[i, i]);
			}

			return result;
		}
	}
}
