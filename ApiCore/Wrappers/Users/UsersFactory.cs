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

			XmlUtils.UseNode(result);
			return buildList(result);
		}

		private UserEntry buildAudioEntry(XmlNode node)
		{
			if (node == null)
				return null;

			XmlUtils.UseNode(node);

			var u = new UserEntry
				{
					Id = XmlUtils.Int("uid"),
					FisrtName = XmlUtils.String("first_name"),
					LastName = XmlUtils.String("last_name"),
					Sex = (FriendSex) XmlUtils.Int("sex"),
					NickName = XmlUtils.String("nickname"),
					ScreenName = XmlUtils.String("screen_name"),
					Birthday = XmlUtils.String("bdate"),
					CityId = XmlUtils.Int("city"),
					CountryId = XmlUtils.Int("country"),
					Photo50 = XmlUtils.String("photo_50"),
					Photo100 = XmlUtils.String("photo_100"),
					Photo200Orig = XmlUtils.String("photo_200_orig"),
					HasMobile = XmlUtils.Bool("has_mobile"),
					Online = XmlUtils.Bool("online"),
					CanPost = XmlUtils.Bool("can_post"),
					CanSeeAllPosts = XmlUtils.Bool("can_see_all_posts"),
					CanWritePrivateMessage = XmlUtils.Bool("can_write_private_message"),
					Status = XmlUtils.String("status"),
					//LastSeen = XmlUtils.String("last_seen"),
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
