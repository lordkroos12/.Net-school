namespace Task8.DTOs
{
	[Serializable]
	public class AuthorDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? DateOfBirth { get; set; }

		public AuthorDto() { }

		public AuthorDto(string firstName, string lastName, DateTime? dateOfBirth)
		{
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
		}
	}
}