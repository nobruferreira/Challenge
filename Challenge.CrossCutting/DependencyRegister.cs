using Challenge.ApplicationService.Services.MarvelApi;
using Challenge.Domain.Contracts.External_Services.MarvelApi;
using Challenge.Domain.Contracts.Services.MarvelApi;
using Challenge.ExternalService.MarvelApi;
using Challenge.SharedKernel;
using Microsoft.Practices.Unity;

namespace Challenge.CrossCutting
{
    public static class DependencyRegister
    {
        /// <summary>
        /// TransientLifetimeManager - Cada Resolve(RegisterType) gera uma nova instância.
        /// HierarchicalLifetimeManager - Utiliza Singleton
        /// </summary>
        /// <param name="container"></param>
        public static void Register(UnityContainer container)
        {
            // Application Service
            container.RegisterType<ICharacterAppService, CharacterAppService>(new HierarchicalLifetimeManager());

            // External Service
            container.RegisterType<ICharacterExternalService, CharacterExternalService>(new HierarchicalLifetimeManager());
            
            // Shared Kernel
            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
        }
    }
}
