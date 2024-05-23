namespace AlgoVisuFS.WebApi.Dtos
{
    public class CellGetDto
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public double Weight { get; set; }
        public int State { get; set; }
        public bool IsGoal { get; set; }
        public bool IsStart { get; set; }
    }

    public class MazeModelDto
    {
        public bool Solvable { get; set; }
        public List<List<CellGetDto>>? Maze { get; set; }
    }
}
