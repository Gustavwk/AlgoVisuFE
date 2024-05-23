using AlgoVisuFS.WebApi.Dtos;

namespace AlgoVisuFS.WebApi.Utils
{
    public static class MazeParser
    {
        public static MazeModelDto Parse(int[][] mazeArr)
        {
            var maze = new List<List<CellGetDto>>();

            for (int i = 0; i < mazeArr.Length; i++)
            {
                var row = new List<CellGetDto>();
                for (int j = 0; j < mazeArr[i].Length; j++)
                {
                    var cell = new CellGetDto
                    {
                        PosX = i,
                        PosY = j,
                        Weight = 1,
                        State = mazeArr[i][j],
                        IsStart = mazeArr[i][j] == 7,
                        IsGoal = mazeArr[i][j] == 9
                    };

                    row.Add(cell);
                }
                maze.Add(row);
            }

            return new MazeModelDto
            {
                Solvable = false, 
                Maze = maze
            };
        }
    }
}
