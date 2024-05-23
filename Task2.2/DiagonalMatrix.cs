using System.Drawing;

namespace Task2._2
{
	internal class DiagonalMatrix
	{
		private int[] diagMatrix;
		public readonly int Size;
		public DiagonalMatrix(params int[] elements)
		{
			if (elements == null)
			{
				Size = 0;
				diagMatrix = new int[Size];
			}
			else
			{
				Size = elements.Length;
				diagMatrix = new int[Size];
				Array.Copy(elements, diagMatrix, Size);
			}
		}
		public int this[int i, int j]
		{
			get
			{
				if (i == j && i >= 0 && i < Size)
				{
					return diagMatrix[i];
				}
				return 0;
			}
			
		}
		
		public int Track()
		{
			int sum = 0;
			foreach (var element in diagMatrix)
			{
				sum += element;
			}

			return sum;
		}
		public override bool Equals(object? obj)
		{
			if (obj is DiagonalMatrix matrix)
			{
				if (matrix.diagMatrix.Length != Size) return false;
				for (int i = 0; i < Size; i++)
				{
					if (diagMatrix[i] != matrix.diagMatrix[i])
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		public override string ToString()
		{
			string result = "[";
			for (int i = 0; i < diagMatrix.Length; i++)
			{
				result += diagMatrix[i];
				if (i < diagMatrix.Length - 1)
					result += ", ";
			}
			result += "]";
			return result;
		}
	}
}
