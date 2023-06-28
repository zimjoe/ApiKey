using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ApiKeyTest
{
    public class Hello
    {
        private readonly ILogger _logger;

        public Hello(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Hello>();
        }
        /// <summary>
        /// Currently this exists to test the API key functionality on Azure Functions.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Function("Hello")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Testing API Key Renewal on deployment");

            return response;
        }
    }
}
