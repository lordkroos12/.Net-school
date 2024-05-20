namespace Task4._1
{
	public class ElementChangedEventArgs<T>
	{
		public int Row { get; }
		public int Column { get; }
		public T OldValue { get; }
		public T NewValue { get; }

		public ElementChangedEventArgs(int row, int column, T oldValue, T newValue)
		{
			Row = row;
			Column = column;
			OldValue = oldValue;
			NewValue = newValue;
		}
	}
}