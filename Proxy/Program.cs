using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Proxy.Interface;
using Proxy.Model;
using Proxy.Proxy;
using Proxy.Service;
using Proxy.ViewModel;

namespace Proxy
{
    public class Program
    {
        static void Main(string[] args)
        {
            ViewModelManager.Init();

            var viewmodel = ViewModelManager.Container.Resolve<AddViewMode>();

            viewmodel.ExcuteAdd(3,9);

            ViewModelManager.Container.Resolve<UserInfo>().Auth[AuthType.Manager] = true;

            viewmodel.ExcuteAdd(3,9);

            ViewModelManager.Container.Resolve<UserInfo>().Protocol[ProtocolType.Register] = true;

            viewmodel.ExcuteAdd(3,9);

            //Console.ReadKey();
        }
    }

    public class ViewModelManager
    {
        public static IContainer Container;

        public static void Init()
        {
            ContainerBuilder builder = new Autofac.ContainerBuilder();

            //builder.RegisterType<IAdd>().EnableInterfaceInterceptors().InterceptedBy(new Type[]{ typeof(AuthProxy) ,typeof(ProtocolProxy)} );
            builder.RegisterType<AuthProxy>();
            builder.RegisterType<ProtocolProxy>();
            builder.RegisterType<Add>().As<IAdd>().EnableInterfaceInterceptors().InterceptedBy(new Type[] { typeof(AuthProxy), typeof(ProtocolProxy) }); ;
            builder.RegisterType<AddViewMode>().PropertiesAutowired();
            builder.RegisterType<Auth>().OnActivated(e => e.Instance.Init());
            builder.RegisterType<Protocol>().OnActivated(e => e.Instance.Init());
            builder.RegisterType<UserInfo>().PropertiesAutowired().SingleInstance();
            
            Container = builder.Build();
        }
    }
}