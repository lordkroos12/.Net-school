namespace Task4._1
{
	internal class MatrixTracker<T>
	{
		private DiagonalMatrix<T> matrix;
		private ElementChangedEventArgs<T> lastChange;

		public MatrixTracker(DiagonalMatrix<T> matrix)
		{
			this.matrix = matrix;
			matrix.ElementChanged += Matrix_ElementChanged;
		}

		public void Undo()
		{
			if (lastChange != null)
			{
				matrix[lastChange.Row, lastChange.Column] = lastChange.OldValue;
				lastChange = null;
			}
		}

		private void Matrix_ElementChanged(object sender, ElementChangedEventArgs<T> e)
		{
			lastChange = e;
		}	
	}
}
