using AlgoVisuFSLogic.Model;
using AlgoVisuFSLogic.Model.Enums;
using AlgoVisuFSLogic.Model.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisuFSLogic.MazeSolver
{
    internal static class MazeUtils
    {
        public static List<Cell> GetNeighborsFromCell(MazeModel maze, Cell cell)
        {
            var neighbors = new List<Cell>();

            if (cell.PosX > 0)
                neighbors.Add(maze.Maze[cell.PosX - 1][cell.PosY]);
            if (cell.PosX < maze.Maze.Length - 1)
                neighbors.Add(maze.Maze[cell.PosX + 1][cell.PosY]);
            if (cell.PosY > 0)
                neighbors.Add(maze.Maze[cell.PosX][cell.PosY - 1]);
            if (cell.PosY < maze.Maze[0].Length - 1)
                neighbors.Add(maze.Maze[cell.PosX][cell.PosY + 1]);

            return neighbors;
        }

        public static Cell GetWestCell(MazeModel maze, Cell cell) { return maze.Maze[cell.PosX - 1][cell.PosY]; }
        public static Cell GetEastCell(MazeModel maze, Cell cell) { return maze.Maze[cell.PosX + 1][cell.PosY]; }
        public static Cell GetNorthCell(MazeModel maze, Cell cell) { return maze.Maze[cell.PosX][cell.PosY - 1]; }
        public static Cell GetSouthCell(MazeModel maze, Cell cell) { return maze.Maze[cell.PosX][cell.PosY + 1]; }

        public static Cell CloneCell(Cell cell)
        {
            return new Cell
            {
                PosX = cell.PosX,
                PosY = cell.PosY,
                Weight = cell.Weight,
                State = cell.State,
                isGoal = cell.isGoal,
                isStart = cell.isStart
            };
        }

    }
}
