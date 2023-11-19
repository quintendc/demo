using BlazorApp1;
using Core.Library.Configuration;
using Portal.Blazor;
using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddReverseProxy()
//    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

//builder.Services.AddReverseProxy().LoadFromMemory(HomeAppConfig.Configuration.Routes, HomeAppConfig.Configuration.Clusters);
//builder.Services.AddReverseProxy().LoadFromMemory(CustomersAppConfig.Configuration.Routes, CustomersAppConfig.Configuration.Clusters);

var microserviceConfigs = new List<MicroserviceConfig>
{
    PortalAppConfig.Configuration,
    BlazorApp1Config.Configuration,
};


var allRoutes = microserviceConfigs.SelectMany(config => config.Routes).ToList();
var allClusters = microserviceConfigs.SelectMany(config => config.Clusters).ToList();

builder.Services.AddReverseProxy().LoadFromMemory(allRoutes, allClusters);



var app = builder.Build();

app.MapReverseProxy();

app.Run();