using AlgoVisuFSLogic.Model.Enums;
using AlgoVisuFSLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisuFSLogicTests.Maze
{
    public static class MazeParser
    {
        public static MazeModel Parse(int[][] mazeArr)
        {
            var result = new MazeModel
            {
                Maze = new Cell[mazeArr.Length][]
            };

            for (int i = 0; i < mazeArr.Length; i++)
            {
                result.Maze[i] = new Cell[mazeArr[i].Length];
                for (int j = 0; j < mazeArr[i].Length; j++)
                {
                    var cell = new Cell
                    {
                        PosX = i,
                        PosY = j,
                        State = ConvertIntToCellState(mazeArr[i][j]),
                        Weight = 1,
                        isStart = mazeArr[i][j] == 7,
                        isGoal = mazeArr[i][j] == 9
                    };

                    result.Maze[i][j] = cell;
                }
            }

            result.Solvable = false;
            return result;
        }

        private static CellState ConvertIntToCellState(int value)
        {
            return value switch
            {
                1 => CellState.wall,
                2 => CellState.free,
                7 => CellState.currentPos,
                9 => CellState.free,
                _ => CellState.free
            };
        }
    }
}
