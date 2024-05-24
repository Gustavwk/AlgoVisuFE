using AlgoVisuFS.WebApi.Dtos;
using AlgoVisuFS.WebApi.Mappers;
using AlgoVisuFS.WebApi.Utils;
using AlgoVisuFSLogic.MazeSolver;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AlgoVisuFS.WebApi.Controllers
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
        public ActionResult<SolveMazeResultDto> SolveMaze([FromBody] int[][] maze)
        {
            var mazeInput = MazeParser.Parse(maze);
            var mazeModel = mazeInput.MazeModel.MapToMazeModel();
            var startCell = mazeModel.Maze[mazeInput.starCell.PosX][mazeInput.starCell.PosY];

            var operations = _dfsSolver.Solve(mazeModel, startCell);

            var solvedMazeDto = mazeModel.Map();
            var operationsDto = operations.Select(op => op.Map()).ToList();

            var result = new SolveMazeResultDto
            {
                MazeModel = solvedMazeDto,
                Operations = operationsDto
            };

            return Ok(result);
        }
    }
}
