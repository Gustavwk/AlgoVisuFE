using AlgoVisuFS.WebApi.Dtos;
using System.Collections.Generic;

namespace AlgoVisuFS.WebApi.Utils
{
    public static class MazeParser
    {
        public static MazeInputDto Parse(int[][] mazeArr)
        {
            var maze = new List<List<CellGetDto>>();
            CellGetDto startCell = null;

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

                    if (cell.IsStart)
                    {
                        startCell = cell;
                    }

                    row.Add(cell);
                }
                maze.Add(row);
            }

            if (startCell == null)
            {
                throw new InvalidOperationException("No start cell found in the maze array.");
            }

            return new MazeInputDto
            {
                MazeModel = new MazeModelDto
                {
                    Solvable = false,
                    Maze = maze
                },
                starCell = startCell
            };
        }
    }
}
