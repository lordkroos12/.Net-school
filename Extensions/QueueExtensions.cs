using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementation.Extensions
{
	internal static class QueueExtensions
	{
		public static Queue<T> Tail<T>(this Queue<T> queue)
		{
			Queue<T> tailQueue = (Queue<T>)queue.Clone();
			tailQueue.Dequeue();
			return tailQueue;

		}
	}
}
