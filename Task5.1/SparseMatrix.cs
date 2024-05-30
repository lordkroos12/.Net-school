using System.Collections;
using System.Text;

namespace Task5._1
{
	internal class SparseMatrix : IEnumerable<long>
	{
		private readonly int rows;
		private readonly int columns;
		private Dictionary<(int, int), long> elements;
		public SparseMatrix(int rows, int columns)
		{
			if (rows <= 0 || columns <= 0)
			{
				throw new ArgumentException("Inavlid rows or columns!");
			}
			this.rows = rows;
			this.columns = columns;
			elements = null;
		}
		public int GetCount(long x)
		{
			int count = 0;
			if (x == 0)
			{
				count = rows * columns - (elements?.Count ?? 0);
			}
			else
			{
				if (elements != null)
				{
					foreach (var value in elements.Values)
					{
						if (value == x)
							count++;
					}
				}
			}
			return count;
		}

		public long this[int row, int col]
		{
			get
			{
				ValidateIndices(row, col);
				return elements != null && elements.TryGetValue((row, col), out long value) ? value : 0;
			}
			set
			{
				ValidateIndices(row, col);
				if (value != 0)
				{
					if (elements == null)
					{
						elements = new Dictionary<(int, int), long>();
					}
					elements[(row, col)] = value;
				}
				else
				{
					elements?.Remove((row, col));
				}
			}
		}
		public IEnumerable<(int, int, long)> GetNonzeroElements()
		{
			if (elements != null)
			{
				foreach (var element in elements.OrderBy(x=>x.Key.Item2).ThenBy(x=>x.Key.Item1))
				{
					yield return (element.Key.Item1, element.Key.Item2, element.Value);
				}
			}
		}
		private void ValidateIndices(int row, int col)
		{
			if (row < 0 || row >= rows || col < 0 || col >= columns)
				throw new IndexOutOfRangeException("Inavlid rows or columns!.");
		}
		public IEnumerator<long> GetEnumerator()
		{
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					yield return this[i, j];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					sb.Append(this[i, j]).Append("\t");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}
