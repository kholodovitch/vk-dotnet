using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using ApiCore.Friends;

namespace ApiCore.Wrappers.Users
{
	public class UsersFactory : BaseFactory
	{
		public UsersFactory(ApiManager manager)
			: base(manager)
		{
		}

		public List<UserEntry> Search(string query, UserSortOrder order, UserSearchParams searchParams = null)
		{
			Manager.Method("users.search");

			if (!string.IsNullOrEmpty(query))
				Manager.Params("q", query);

			Manager.Params("sort", (int)order);

			if (searchParams != null)
			{
				if (searchParams.Count != null)
					Manager.Params("count", searchParams.Count.Value);

				if (searchParams.Offset != null)
					Manager.Params("offset", searchParams.Offset.Value);

				UserSearchField[] fields = searchParams.Fields;
				if (fields != null && fields.Length > 0)
				{
					string fieldsStr = "";
					for (int i = 0; i < fields.Length; i++)
					{
						if (i != 0)
							fieldsStr += ",";
						fieldsStr += fields[i].ToString();
					}
					Manager.Params("fields", fieldsStr);
				}

				Manager.Params("sex", searchParams.Sex);

				if (searchParams.Status != null)
					Manager.Params("status", searchParams.Status.Value);

				if (searchParams.AgeFrom != null)
					Manager.Params("age_from", searchParams.AgeFrom.Value);

				if (searchParams.AgeTo != null)
					Manager.Params("age_to", searchParams.AgeTo.Value);

				if (searchParams.HasPhoto)
					Manager.Params("has_photo", 1);
			}

			XmlNode result = Manager.Execute().GetResponseXml();

			return buildList(result);
		}

		private UserEntry buildAudioEntry(XmlNode node)
		{
			if (node == null)
				return null;

			var u = new UserEntry
				{
					Id = XmlUtils.GetInt("uid", node),
					FirstName = XmlUtils.GetString("first_name", node),
					LastName = XmlUtils.GetString("last_name", node),
					Sex = (FriendSex)XmlUtils.GetInt("sex", node),
					NickName = XmlUtils.GetString("nickname", node),
					ScreenName = XmlUtils.GetString("screen_name", node),
					Birthday = XmlUtils.GetString("bdate", node),
					CityId = XmlUtils.GetInt("city", node),
					CountryId = XmlUtils.GetInt("country", node),
					Photo50 = XmlUtils.GetString("photo_50", node),
					Photo100 = XmlUtils.GetString("photo_100", node),
					Photo200Orig = XmlUtils.GetString("photo_200_orig", node),
					HasMobile = XmlUtils.GetBool("has_mobile", node),
					Online = XmlUtils.GetBool("online", node),
					CanPost = XmlUtils.GetBool("can_post", node),
					CanSeeAllPosts = XmlUtils.GetBool("can_see_all_posts", node),
					CanWritePrivateMessage = XmlUtils.GetBool("can_write_private_message", node),
					Status = XmlUtils.GetString("status", node),
					//LastSeen = XmlUtils.GetString("last_seen", node),
				};
			return u;
		}

		private List<UserEntry> buildList(XmlNode data)
		{
			XmlNodeList nodes = data.SelectNodes("/response/user");
			Debug.Assert(nodes != null);

			var audios = new List<UserEntry>();
			foreach (XmlNode n in nodes)
				audios.Add(buildAudioEntry(n));
			return audios;
		}
	}
}
