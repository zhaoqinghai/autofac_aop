using System;
using System.Collections.Generic;
using System.Text;
using Proxy.Model;
using Proxy.Proxy;

namespace Proxy.Interface
{
    public interface IAdd
    {
        [Auth(new AuthType[] { AuthType.Manager }),Protocol(new ProtocolType[]{ProtocolType.Register})]
        
        void Add(int a, int b);
    }

    
}
