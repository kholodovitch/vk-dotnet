﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using ApiCore.Utils.Authorization;
using ApiCore.Utils.Authorization.Exceptions;

namespace ApiCore
{
    public delegate void SessionManagerLogHandler(object sender, string msg);
    public class SessionManager
    {

        private List<SessionInfo> sessions;

        public  AuthType AuthorizationType;

        public int AppId;
        public int Permissions = 0;
        public string Scope = null;

        public SessionManager(int appId, int perms)
        {
            this.sessions = new List<SessionInfo>();
            this.AppId = appId;
            this.Permissions = perms;
            this.AuthorizationType = AuthType.VKAuth;
        }

        public SessionManager(int apiId, string scope)
        {
            this.sessions = new List<SessionInfo>();
            this.AppId = apiId;
            this.Scope = scope;
            this.AuthorizationType = AuthType.OAuth;
        }

        public event SessionManagerLogHandler Log;
        /// <summary>
        /// Logging event function
        /// </summary>
        /// <param name="msg">Message to log</param>
        protected virtual void OnLog(string msg)
        {
            if (this.Log != null)
            {
                this.Log(this, msg);
			}
		}

		public SessionInfo GetOAuthSession()
		{
			return GetOAuthSession(null, null);
		}

		public SessionInfo GetOAuthSession(string email, string pass)
		{
            this.OnLog("Creating OAuth login wnd...");
			OAuth auth = new OAuth(email, pass);
            
#if !DEBUG
            try 
#endif
			{
                this.OnLog("Authorization successed!");
                return auth.Authorize(this.AppId, this.Scope, AuthDisplay.Popup.ToString());
            }
#if !DEBUG
            catch(AuthorizationFailedException e)
            {
                this.OnLog("Authorization failed: "+e.Message);
                return null;
            }
            catch(Exception e)
            {
				this.OnLog(string.Format("Authorization failed by unknown reason! [{0}]", e.Message));
                return null;
            }
            return null;
#endif
        }
        
        public void CloseSession()
        {
        }


    }
}
