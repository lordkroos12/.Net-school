

namespace QueueImplementation
{
	internal class Queue<T> : IQueue<T>,ICloneable
	{
		private LinkedList<T> _queue = new LinkedList<T>();
		public T Dequeue()
		{
			T firstItem = default(T);
			if (IsEmpty())
			{
				throw new InvalidOperationException("The queue is empty!");
			}
			else
			{
				firstItem = _queue.First();
				_queue.RemoveFirst();
			}
			return firstItem;
		}

		public void Enqueue(T item)
		{
			_queue.AddLast(item);
		}
		public bool IsEmpty()
		{
			return _queue.Count == 0;
		}

		public object Clone()
		{
			Queue<T> clonedQueue = new Queue<T>();
			foreach (var item in _queue)
			{
				clonedQueue.Enqueue(item);
			}
			return clonedQueue;
		}
	}
}
