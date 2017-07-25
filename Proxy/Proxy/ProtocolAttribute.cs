using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Castle.DynamicProxy;
using Proxy.Model;

namespace Proxy.Proxy
{
    public class ProtocolAttribute : Attribute
    {
        public ProtocolType[] ProtocolList;
        public ProtocolAttribute(ProtocolType[] protocols)
        {
            ProtocolList = protocols;
        }
    }

    public class ProtocolProxy : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var attr = invocation.Method.GetCustomAttribute(typeof(ProtocolAttribute), true) as ProtocolAttribute;

            if (attr != null)
            {
                var user = ViewModelManager.Container.Resolve<UserInfo>();
                foreach (var item in attr.ProtocolList)
                {
                    if (!user.Protocol[item])
                    {
                        Console.WriteLine("have no protocol");
                        return;
                    }
                }
            }
            invocation.Proceed();
        }
    }
}
