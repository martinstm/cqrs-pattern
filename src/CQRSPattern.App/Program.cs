using Application.DependencyResolver;
using CQRSPattern.App;
using Infrastructure.DependencyResolver;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddApplication();
        services.AddInfrastructure();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
