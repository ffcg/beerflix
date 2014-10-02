using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BeerFlix.Data.Movies.Common
{
    public class MovieRepositoryInstaller : IWindsorInstaller
    {
        public void Install(
            IWindsorContainer container,
            IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IMovieRepository>()
                    .ImplementedBy<MovieRepository>()
                    .LifestylePerWebRequest()
                );
        }
    }
}