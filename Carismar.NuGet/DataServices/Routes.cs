using System.Data.Services;
using System.ServiceModel.Activation;
using System.Web.Routing;
using Ninject;
using NuGet.Server;
using NuGet.Server.DataServices;
using NuGet.Server.Infrastructure;
using NuGetRoutes = Carismar.NuGet.DataServices.NuGetRoutes;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NuGetRoutes), "Start")]

namespace Carismar.NuGet.DataServices {
    public static class NuGetRoutes {
        public static void Start() {
            MapRoutes(RouteTable.Routes);
        }

        private static void MapRoutes(RouteCollection routes) {
            // The default route is http://{root}/nuget/Packages
            var factory = new DataServiceHostFactory();
            var serviceRoute = new ServiceRoute("nuget", factory, typeof (Packages))
            {
                Defaults = new RouteValueDictionary {{"serviceType", "odata"}},
                Constraints = new RouteValueDictionary {{"serviceType", "odata"}}
            };
            routes.Add("nuget", serviceRoute);
        }

        private static PackageService CreatePackageService() {
            return NinjectBootstrapper.Kernel.Get<PackageService>();
        }
    }
}
