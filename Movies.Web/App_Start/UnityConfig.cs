using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Movies.Service;
using Movies.Data;

namespace Movies.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IMovieRepository, MovieRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IMovieService, MovieService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}