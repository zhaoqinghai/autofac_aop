using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.Model
{
    public class Auth
    {
        Dictionary<AuthType,bool> dict = new Dictionary<AuthType, bool>();
        public bool this[AuthType type]
        {
            get
            {
                lock (dict)
                {
                    return dict[type];
                }
            }

            set
            {
                lock (dict)
                {
                    dict[type] = value;
                }
            }
        }

        public void Init()
        {
            lock (dict)
            {
                foreach (var item in Enum.GetValues(typeof(AuthType)))
                {
                    dict.Add((AuthType)item,false);
                }
            }
        }
    }

    public enum AuthType
    {
        Default,
        Trade,
        Pay,
        Manager,
        Sign
    }
}
