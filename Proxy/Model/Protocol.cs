using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.Model
{
    public class Protocol
    {
        Dictionary<ProtocolType, bool> dict = new Dictionary<ProtocolType, bool>();

        public bool this[ProtocolType type]
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
                foreach (var item in Enum.GetValues(typeof(ProtocolType)))
                {
                    dict.Add((ProtocolType)item, false);
                }
            }
        }
    }

    public enum ProtocolType
    {
        Register,
        Custom,
        WareHouse
    }
}
