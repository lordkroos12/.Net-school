namespace QueueImplementation.Extensions
{
	internal static class QueueExtensions
	{
		public static Queue<T> Tail<T>(this Queue<T> queue) where T : struct
		{
			Queue<T> tailQueue = (Queue<T>)queue.Clone();
			tailQueue.Dequeue();
			return tailQueue;

		}
	}
}
