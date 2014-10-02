using System.Web.Mvc;
using BeerFlix.Web.Common.MVC;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BeerFlix.Web.Common.Installers
{
    public class ControllerFactoryInstaller : IWindsorInstaller
    {
        public void Install(
            IWindsorContainer container,
            IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IControllerFactory>()
                    .ImplementedBy<WindsorControllerFactory>()
                    .LifestyleSingleton()
                );
        }
    }
}