using AlgoVisuFS.WebApi.Dtos;
using AlgoVisuFSLogic.MazeSolver;
using Microsoft.AspNetCore.Mvc;

namespace AlgoVisuFS.WebApi.Controllers.MazeController

    {
        [ApiController]
        [Route("[controller]")]
        public class DFSController : ControllerBase
        {

            private readonly ILogger<DFSController> _logger;
            private readonly IDFSSolver _dfsSolver;

            public DFSController(ILogger<DFSController> logger, IDFSSolver dfsSolver)
            {
                _logger = logger;
                _dfsSolver = dfsSolver ?? throw new ArgumentNullException(nameof(dfsSolver));
            }

            

        }
    }

