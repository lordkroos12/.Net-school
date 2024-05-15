namespace Task4._1
{
	public class DiagonalMatrix<T>
	{
		private T[] diagMatrix;
		private int size;
		public int Size
		{
			get { return size; }
		}
		public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

		public DiagonalMatrix(int size)
		{
			if (size <= 0)
				throw new ArgumentException("The length of the array has to be greather than zero!");

			this.size = size;
			diagMatrix = new T[size];
		}

		

		public T this[int i, int j]
		{
			get
			{
				if (i < 0 || i >= size || j < 0 || j >= size)
					throw new IndexOutOfRangeException("Index not valid.");

				return (i == j) ? diagMatrix[i] : default(T);
			}
			set
			{
				if (i < 0 || i >= size || j < 0 || j >= size)
					throw new IndexOutOfRangeException("Index not valid.");

				if (i == j && !Equals(diagMatrix[i], value))
				{
					T oldValue = diagMatrix[i];
					diagMatrix[i] = value;
					ElementChanged?.Invoke(this, new ElementChangedEventArgs<T>(i, j, oldValue, value));
				}
			}
		}
	}
}
