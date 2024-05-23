namespace Task5._1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			SparseMatrix matrix = new SparseMatrix(5, 5);
			matrix[0, 0] = 10;
			matrix[4, 4] = 20;
			matrix[2, 2] = 0;
			if (matrix[1,1] != 0) throw new ArgumentException("Element should be 0!");
			matrix[0, 0] = 0;
			if (matrix[0,0] != 0) throw new ArgumentException("Element should be 0!");
			matrix[4, 3] = 22;
			matrix[4,2] = 22;
			TestGetNonzeroElements();
			Console.WriteLine(matrix.ToString());
			if (matrix.GetCount(22)!=2) throw new ArgumentException("GetCount Problem!");
        }
		public static void TestGetNonzeroElements()
		{
			SparseMatrix matrix = new SparseMatrix(3, 3);

			matrix[0, 0] = 6;
			matrix[0, 2] = 10;
			matrix[2, 0] = 11;

			var nonZeroElements = new List<(int, int, long)>(matrix.GetNonzeroElements());

			if (nonZeroElements.Count != 3) throw new Exception("GetNonZeroElements problem!");
			if (nonZeroElements[0] != (0, 0, 6)) throw new Exception("GetNonZeroElements problem!");
			if (nonZeroElements[2] != (0, 2, 10)) throw new Exception("GetNonZeroElements problem!");
			if (nonZeroElements[1] != (2, 0, 11)) throw new Exception("GetNonZeroElements problem!");
		}
		public static void TestIEnumerable()
		{
			SparseMatrix matrix = new SparseMatrix(3, 3);

			matrix[0, 0] = 1;
			matrix[1, 1] = 3;

			var elements = new List<long>(matrix);

			if (elements.Count != 6) throw new Exception("IEnumerable problem.");
			if (elements[0] != 1) throw new Exception("IEnumerable problem.");
			if (elements[1] != 0) throw new Exception("IEnumerable problem.");
			if (elements[2] != 0) throw new Exception("IEnumerable problem.");
			if (elements[3] != 2) throw new Exception("IEnumerable problem.");

		}
	}
}
