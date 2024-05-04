namespace Task2._2
{
	internal static class DiagonalMatrixExtension
	{
		public static DiagonalMatrix Add(this DiagonalMatrix matrix1, DiagonalMatrix matrix2)
		{
			int maxSize = Math.Max(matrix1.Size, matrix2.Size);
			int[] resultElements = new int[maxSize];
			for (int i = 0; i < maxSize; i++)
			{
				int element1 = (i < matrix1.Size) ? matrix1[i, i] : 0;
				int element2 = (i < matrix2.Size) ? matrix2[i, i] : 0;
				resultElements[i] = element1 + element2;
			}
			return new DiagonalMatrix(resultElements);
		}
	}
}
