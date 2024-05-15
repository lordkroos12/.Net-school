using Microsoft.VisualBasic;

namespace Task2._3
{
	internal class Training
	{
		BaseLesson[] Lessons;
		private int count;

		public Training(int capacity)
		{
			Lessons = new BaseLesson[capacity];
			count = 0;
		}

		public void Add(BaseLesson content)
		{
			if (count < Lessons.Length)
			{
				Lessons[count++] = content;
			}
			else
			{
				throw new InvalidOperationException("Training is full");
			}
		}
		public bool isPractical()
		{
			foreach (var practical in Lessons)
			{
				if (practical is PracticalLesson)
					return true;
			}
			return false;
		}
		public Training Clone()
		{
			Training training = new Training(5);
			foreach (var lesson in Lessons)
			{
				training.Add((BaseLesson)lesson.Clone());
			}
			return training;
		}
	}
}
