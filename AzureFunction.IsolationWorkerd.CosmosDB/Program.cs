using AzureFunction.IsolationWorkerd.CosmosDB.Middleware;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{

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