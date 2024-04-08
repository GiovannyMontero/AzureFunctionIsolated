using AzureFunctionApp.Demos.CosmosDB.IsolatedWorkerModel.Middleware;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    //private static void Main(string[] args)
    //{
    //    var host = new HostBuilder()
    //.ConfigureFunctionsWebApplication()
    //.ConfigureFunctionsWorkerDefaults(workerApplication =>
    // {
    //     workerApplication.UseMiddleware<ExceptionHandlingMiddleware>();
    // })
    ////.ConfigureServices(services =>
    ////{

    ////    services.AddApplicationInsightsTelemetryWorkerService();
    ////    services.ConfigureFunctionsApplicationInsights();
    ////})

    //.Build();

    //    host.Run();
    //}

    public static void Main()
    {
        //<docsnippet_middleware_register>

        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults(workerApplication =>
            {
                // Register our custom middlewares with the worker
                workerApplication.UseMiddleware<ExceptionHandlingMiddleware>();

            })
            .ConfigureServices(services =>
            {

                services.AddApplicationInsightsTelemetryWorkerService();
                services.ConfigureFunctionsApplicationInsights();
            })
            .Build();
        host.Run();
    }
}