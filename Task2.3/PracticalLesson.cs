namespace Task2._3
{
	internal class PracticalLesson : BaseLesson
	{
		public string TaskLink { get; set; }
		public string SolutionLink { get; set; }

		public PracticalLesson(string description, string taskLink, string solutionLink) : base(description)
		{
			TaskLink = taskLink;
			SolutionLink = solutionLink;
		}

		public override string ToString()
		{
			return $"Practical Lesson: Task Link - {TaskLink}, Solution Link - {SolutionLink}";
		}

		public override object Clone()
		{
			return new PracticalLesson(Description, TaskLink, SolutionLink);
		}
	}
}
