using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FunctionAppMiddleware
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req, FunctionContext context)
        {
            if (req.Query.Contains("asdas"))
            {
                throw new Exception("App code failed");
            }

            var logger = context.GetLogger<HttpFunction>();

            // Get the item set by the middleware
            if (context.Items.TryGetValue("middlewareitem", out object value) && value is string message)
            {
                logger.LogInformation("From middleware: {message}", message);
            }

            var response = req.CreateResponse(HttpStatusCode.OK);

            // Set a context item the middleware can retrieve
            context.Items.Add("functionitem", "Hello from function!");

            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Welcome to .NET 6!!");

            return response;
        }


    }
}
