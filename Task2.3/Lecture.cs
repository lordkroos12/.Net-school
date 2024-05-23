namespace Task2._3
{
	internal class Lecture : BaseLesson
	{
		public string Topic { get; set; }
        public Lecture(string description,string topic): base(description)
        {
            this.Topic = topic;
        }
        public override object Clone()
		{
			return new Lecture(Description,Topic);
		}
		public override string ToString()
		{
			return $"Lecture: {Topic}";
		}
	}
}
