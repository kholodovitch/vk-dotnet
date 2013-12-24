using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCore.Utils.Authorization
{
	class OAuthHidden
	{
		public void Authenticate(string email, string pass)
		{
			throw new NotImplementedException();
		}

		public SessionInfo SessionData { get; private set; }
	}
}
