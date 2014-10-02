using BeerFlix.Web.Common.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BeerFlix.Web.Common.Installers
{
    public class HttpContextDependenciesInstaller : IWindsorInstaller
    {
        public void Install(
            IWindsorContainer container,
            IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IHtmlDecoder>()
                    .ImplementedBy<HttpContextHtmlDecoder>()
                    .LifestylePerWebRequest()
                );
        }
    }
}