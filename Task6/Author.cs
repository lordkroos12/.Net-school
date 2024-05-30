namespace Task6
{
	public class Author
	{
		private string firstName;

		public string FirstName
		{
			get { return firstName; }
			set
			{
				if (value.Length > 200)
				{
					throw new ArgumentException("Length must be less than 200 symbols!");
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
				if (value.Length > 200)
				{
					throw new ArgumentException("Length must be less than 200 symbols!");
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

    }
}
