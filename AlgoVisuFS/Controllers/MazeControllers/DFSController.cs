using AlgoVisuFS.WebApi.Dtos;
using AlgoVisuFS.WebApi.Mappers;
using AlgoVisuFS.WebApi.Utils;
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

        [HttpPost("convert")]
        public ActionResult<MazeModelDto> ConvertMaze([FromBody] int[][] mazeArr)
        {
            var mazeModelDto = MazeParser.Parse(mazeArr);

            return Ok(mazeModelDto);
        }

        [HttpPost("solve")]
        public ActionResult<MazeModelDto> SolveMaze([FromBody] MazeInputDto mazeInput)
        {
            var mazeModel = mazeInput.MazeModel.MapToMazeModel();

            var startCell = mazeModel.Maze[mazeInput.starCell.PosX][mazeInput.starCell.PosY];

            var solvedMaze = _dfsSolver.Solve(mazeModel, startCell);

            var solvedMazeDto = solvedMaze.Map();

            return Ok(solvedMazeDto);
        }

    }
    }

