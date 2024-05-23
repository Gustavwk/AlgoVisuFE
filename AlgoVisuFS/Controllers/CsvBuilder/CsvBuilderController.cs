using Microsoft.AspNetCore.Mvc;

namespace HvorFuckedErJeg2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CsvBuilderController : ControllerBase
    {

        private readonly ILogger<CsvBuilderController> _logger;

        public CsvBuilderController(ILogger<CsvBuilderController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBudgetCsv")]
        public Task Get() => Task.FromResult(0);
    }
}