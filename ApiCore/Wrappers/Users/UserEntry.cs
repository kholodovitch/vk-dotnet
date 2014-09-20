using ApiCore.Friends;

namespace ApiCore.Wrappers.Users
{
	public class UserEntry
	{
		public int Id { get; set; }

		public string FisrtName { get; set; }

		public string LastName { get; set; }

		public string NickName { get; set; }

		public string ScreenName { get; set; }

		public FriendSex Sex { get; set; }

		public string Birthday { get; set; }

		public int CityId { get; set; }

		public int CountryId { get; set; }

		public string Timezone { get; set; }

		public string Photo50 { get; set; }

		public string Photo100 { get; set; }

		public string Photo200Orig { get; set; }

		public bool HasMobile { get; set; }

		//public string Contacts { get; set; }

		//public string Education { get; set; }

		public bool Online { get; set; }

		public int Relation { get; set; }

		public long LastSeen { get; set; }

		public string Status { get; set; }

		public bool CanWritePrivateMessage { get; set; }

		public bool CanSeeAllPosts { get; set; }

		public bool CanPost { get; set; }

		//public string universities { get; set; }
	}
}