using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Michle99.Function
{
    public class ProcessDataset
    {
        private readonly ILogger<ProcessDataset> _logger;

        public ProcessDataset(ILogger<ProcessDataset> logger)
        {
            _logger = logger;
        }

        [Function("ProcessDataset")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
