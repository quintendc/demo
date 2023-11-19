using Core.Library.Configuration;
using Yarp.ReverseProxy.Configuration;

namespace Portal.Blazor
{
    public class PortalAppConfig : MicroserviceConfig
    {
        // change these fields
        static string appName = "Portal";
        static string routeId = "route1";
        static string AppPortNumber = "5001";


        static string clusterId = $"{appName}App";

        //static string path = $"/{appName}/{{**catch-all}}"; // will force to use /home after domain name
        static string path = "{**catch-all}";

        public static MicroserviceConfig Configuration { get; } = new PortalAppConfig
        {
            Routes =
        {
            new RouteConfig
            {
                RouteId = routeId,
                ClusterId = clusterId,
                Match = new RouteMatch
                {
                    Path = path
                }
            }
        },
            Clusters =
        {
            new ClusterConfig
            {
                ClusterId = clusterId,
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    {
                        "destination1", new DestinationConfig
                        {
                            Address = $"https://localhost:{AppPortNumber}"
                        }
                    }
                }
            }
        }
        };
    }
}
