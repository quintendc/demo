using Core.Library.Configuration;
using Yarp.ReverseProxy.Configuration;

namespace BlazorApp1
{
    public class BlazorApp1Config : MicroserviceConfig
    {
        // change these fields
        static string appName = "BlazorApp1";
        static string routeId = "route2";
        static string AppPortNumber = "5002";


        static string clusterId = $"{appName}App";

        //static string path = $"/{appName}/{{**catch-all}}"; // will force to use /home after domain name
        static string path = $"/{appName}/{{**catch-all}}";

        public static MicroserviceConfig Configuration { get; } = new BlazorApp1Config
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
