using AzureFunction.IsolationWorkerd.CosmosDB.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureFunction.IsolationWorkerd.CosmosDB
{
    public class CardsChangeFeed
    {
        private readonly ILogger _logger;

        public CardsChangeFeed(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<CardsChangeFeed>();
        }

        [Function("CardsChangeFeed")]
        public void Run([CosmosDBTrigger(
            databaseName: "emx-orian-heritage",
            containerName: "stg_cards",
            Connection = "CosmosConnectionStringChangeFeed",
            LeaseContainerName = "leases",
            CreateLeaseContainerIfNotExists = true)] IReadOnlyList<CardInfo> input)
        {
            if (input != null && input.Count > 0)
            {
                _logger.LogInformation("Documents modified: " + input.Count);
                _logger.LogInformation("First document Id: " + input[0].Id);

                _logger.LogDebug("Log Debug");
                _logger.LogTrace("Log Trace");
                _logger.LogInformation("Log Info");
                _logger.LogWarning("Log Warn");
                _logger.LogError("Log Error");
                _logger.LogCritical("Log Critical");
                throw new NotImplementedException();
            }
        }
    }
}
