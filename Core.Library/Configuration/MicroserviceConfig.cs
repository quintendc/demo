using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarp.ReverseProxy.Configuration;

namespace Core.Library.Configuration
{
    public abstract class MicroserviceConfig
    {
        public List<RouteConfig> Routes { get; set; } = new List<RouteConfig>();
        public List<ClusterConfig> Clusters { get; set; } = new List<ClusterConfig>();
    }
}
