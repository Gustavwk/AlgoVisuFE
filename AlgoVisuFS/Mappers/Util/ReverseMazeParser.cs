using AlgoVisuFS.WebApi.Dtos;
using System.Collections.Generic;

namespace AlgoVisuFS.WebApi.Utils
{
    public static class ReverseMazeParser
    {
        public static int[][] Parse(MazeModelDto mazeModelDto)
        {
            int rowCount = mazeModelDto.Maze.Count;
            int colCount = mazeModelDto.Maze[0].Count;
            int[][] mazeArr = new int[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                mazeArr[i] = new int[colCount];
                for (int j = 0; j < colCount; j++)
                {
                    var cell = mazeModelDto.Maze[i][j];
                    mazeArr[i][j] = ConvertCellStateToInt(cell);
                }
            }

            return mazeArr;
        }

        private static int ConvertCellStateToInt(CellGetDto cell)
        {
            if (cell.IsStart) return 5;
            if (cell.IsGoal) return 6;
            return cell.State;
        }
    }
}
