using AlgoVisuFS.WebApi.Dtos;
using AlgoVisuFS.WebApi.Mappers;
using AlgoVisuFS.WebApi.Utils;
using AlgoVisuFSLogic.MazeSolver;
using Microsoft.AspNetCore.Mvc;

namespace AlgoVisuFS.WebApi.Controllers.MazeControllers
{
    public class GreedyController : Controller
    {
        private readonly ILogger<DFSController> _logger;
        private readonly IGreedyDFSSolver _greedySolver;

        public GreedyController(ILogger<DFSController> logger, IGreedyDFSSolver greedySolver)
        {
            _logger = logger;
            _greedySolver = greedySolver ?? throw new ArgumentNullException(nameof(greedySolver));
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
            var goal = MazeParser.GetGoalFromMaze(mazeInput.MazeModel);
            var mazeModel = mazeInput.MazeModel.MapToMazeModel();
            var startCell = mazeModel.Maze[mazeInput.starCell.PosX][mazeInput.starCell.PosY];

            var operations = _greedySolver.Solve(mazeModel, startCell, goal.Map());

            var solvedMazeDto = mazeModel.Map();
            var operationsDto = operations.Select(op => op.Map()).ToList();

            var result = new SolveMazeResultDto
            {
                MazeModel = ReverseMazeParser.Parse(solvedMazeDto),
                Operations = operationsDto
            };

            return Ok(result);
        }
    }
}
