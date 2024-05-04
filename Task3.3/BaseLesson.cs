namespace Task2._3
{
	public  abstract class BaseLesson : ICloneable
	{
        public  string Description { get; set; }
        public abstract object Clone();

        public BaseLesson(string description)
        {
            Description = description;
        }

    }
}
