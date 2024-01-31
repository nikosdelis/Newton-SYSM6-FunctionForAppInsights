using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionForAppInsights
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {

            return new OkObjectResult("Welcome to Azure Functions!");
        }

        private void ChainFunc1()
        {
            try
            {
                ChainFunc2();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ChainFunc2()
        {
            try
            {
                ChainFunc3();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ChainFunc3()
        {
            try
            {
                throw new Exception("This is where things started going wrong!");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
