
namespace QueueImplementation
{
	internal interface IQueue<T>
	{
		void Enqueue(T item);
		T Dequeue();
		bool IsEmpty();
	}
}
