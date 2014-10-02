using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BeerFlix.Data.Beers.Common
{
    public class BeerRepositoryInstaller : IWindsorInstaller
    {
        public void Install(
            IWindsorContainer container,
            IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IBeerRepository>()
                    .ImplementedBy<BeerRepository>()
                    .LifestyleSingleton()
                );
        }
    }
}