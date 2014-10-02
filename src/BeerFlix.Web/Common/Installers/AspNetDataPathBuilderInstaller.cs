using BeerFlix.Data.Beers;
using BeerFlix.Web.Common.MVC;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BeerFlix.Web.Common.Installers
{
    public class AspNetDataPathBuilderInstaller : IWindsorInstaller
    {
        public void Install(
            IWindsorContainer container,
            IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IFilePathBuilder>()
                    .ImplementedBy<AspNetDataPathBuilder>()
                    .LifestylePerWebRequest()
                );
        }
    }
}