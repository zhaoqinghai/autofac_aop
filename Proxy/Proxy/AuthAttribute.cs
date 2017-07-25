using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Proxy.Model;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace Proxy.Proxy
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Property)]
    public class AuthAttribute : Attribute
    {
        public AuthType[] AuthList;
        public AuthAttribute(AuthType[] auths)
        {
            AuthList = auths;
        }
    }

    public class AuthProxy : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var attr = invocation.Method.GetCustomAttribute(typeof(AuthAttribute), true) as AuthAttribute;
            
            if (attr != null)
            {
                var user = ViewModelManager.Container.Resolve<UserInfo>();
                foreach (var item in attr.AuthList)
                {
                    if (!user.Auth[item])
                    {
                        Console.WriteLine("have no auth");
                        return;
                    }
                }
            }
            invocation.Proceed();
        }
    }
}
