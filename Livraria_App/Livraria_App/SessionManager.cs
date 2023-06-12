using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria_App
{
    public class SessionManager
    {
        private static SessionManager instance;
        public static SessionManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SessionManager();
                return instance;
            }
        }

        public bool IsUserLoggedIn { get; set; }

        private SessionManager()
        {
            IsUserLoggedIn = false;
        }
    }
}
