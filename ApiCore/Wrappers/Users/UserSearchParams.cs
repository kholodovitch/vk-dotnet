namespace ApiCore.Wrappers.Users
{
	public class UserSearchParams
	{
		public int? Count { get; set; }

		public int? Offset { get; set; }

		public UserSearchField[] Fields { get; set; }

		public int Sex { get; set; }

		public int? Status { get; set; }

		public int? AgeFrom { get; set; }

		public int? AgeTo { get; set; }

		public bool HasPhoto { get; set; }

		public int BirthDay { get; set; }

		public int BirthMonth { get; set; }

		public int BirthYear { get; set; }
	}
}