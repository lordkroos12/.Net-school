namespace Task6
{
	public class Author
	{
		const int limit = 200;
		private string firstName;

		public string FirstName
		{
			get { return firstName; }
			set
			{
				if (value.Length > limit)
				{
					throw new ArgumentException($"Length must be less than {limit} symbols!");
				}
				firstName = value;
			}
		}
		private string lastName;

		public string LastName
		{
			get { return lastName; }
			set
			{
				if (value.Length > limit)
				{
					throw new ArgumentException($"Length must be less than {limit} symbols!");
				}
				lastName = value;
			}
		}
		public DateTime DateOfBirth { get; set; }
		public Author(string firstName, string lastName, DateTime dateOfBirth)
		{
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
		}
        private Author()
        {
            
        }
		public override bool Equals(object? obj)
		{
			return base.Equals(obj);
		}
		public override bool Equals(object obj)
		{
			if (obj is Author otherAuthor)
			{
				return this.FirstName == otherAuthor.FirstName &&
					   this.LastName == otherAuthor.LastName &&
					   this.DateOfBirth == otherAuthor.DateOfBirth;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return FirstName.GetHashCode() ^
				   LastName.GetHashCode() ^
				   DateOfBirth.GetHashCode();
		}
	}
}
