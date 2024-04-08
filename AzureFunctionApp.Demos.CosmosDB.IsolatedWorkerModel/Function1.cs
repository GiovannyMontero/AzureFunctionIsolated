using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionApp.Demos.CosmosDB.IsolatedWorkerModel
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public void Run([CosmosDBTrigger(
            databaseName: "emx-orian-heritage",
            containerName: "stg_cards",
            Connection = "CosmosConnectionStringChangeFeed",
            LeaseContainerName = "leases",
            CreateLeaseContainerIfNotExists = true)] IReadOnlyList<CardInfo> input, FunctionContext context)
        {
            if (input != null && input.Count > 0)
            {
                _logger.LogInformation("Documents modified: " + input.Count);
                _logger.LogInformation("First document Id: " + input[0].Id);

                throw new NotImplementedException();
            }
        }
    }
}
