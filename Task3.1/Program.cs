using QueueImplementation.Extensions;

namespace QueueImplementation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<int> queue = new Queue<int>();
			queue.Enqueue(1);
			queue.Enqueue(3);
			queue.Enqueue(5);
			queue.Enqueue(7);

			Console.WriteLine("Original Queue:");
			while (!queue.IsEmpty())
			{
				Console.WriteLine(queue.Dequeue());
			}

			// Test the Tail<T>() extension method
			queue.Enqueue(1);
			queue.Enqueue(3);
			queue.Enqueue(5);
			queue.Enqueue(7);

			Console.WriteLine("\nOriginal Queue after re-enqueueing:");
			while (!queue.IsEmpty())
			{
				Console.WriteLine(queue.Dequeue());
			}

			queue.Enqueue(3);
			queue.Enqueue(5);
			queue.Enqueue(7);
			Console.WriteLine("\nTail of Original Queue:");
			IQueue<int> tailQueue = queue.Tail();
			while (!tailQueue.IsEmpty())
			{
				Console.WriteLine(tailQueue.Dequeue());
			}

			Console.WriteLine("\nOriginal Queue after re-enqueueing:");
			while (!queue.IsEmpty())
			{
				Console.WriteLine(queue.Dequeue());
			}
		}
	}
}
