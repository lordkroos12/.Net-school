namespace Task7.Enitites
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
				if (value.Contains(":"))
				{
					value = value.Replace(":", "");
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
				if (value.Contains(":"))
				{
					value.Replace(":", " ");
				}
				lastName = value;
            }
        }
        public DateOnly? DateOfBirth { get; set; }
        public Author(string firstName, string lastName, DateOnly? dateOfBirth = null)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
        private Author()
        {

        }
		public override bool Equals(object obj)
		{
			if (obj is Author other)
			{
				return string.Equals(FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase) &&
					   string.Equals(LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(
				FirstName?.ToLowerInvariant(),
				LastName?.ToLowerInvariant()
			);
		}
	}
}
