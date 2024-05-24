namespace AlgoVisuFS.WebApi.Dtos
{
    public class SolveMazeResultDto
    {
        public required int[][] MazeModel { get; set; }
        public required List<OperationChronoDto<CellGetDto>> Operations { get; set; }
    }
}
