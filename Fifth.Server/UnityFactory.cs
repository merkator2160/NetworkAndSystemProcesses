using Fifth.Server.Interfaces;
using Microsoft.Practices.Unity;
using System;

namespace Fifth.Server
{
    public static class UnityFactory
    {
        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////
        public static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IRemoteServiceManager, RemoteServiceManager>();
            container.RegisterInstance(AutoMapperConfig.GetConfiguredMapper());
        }
    }
}