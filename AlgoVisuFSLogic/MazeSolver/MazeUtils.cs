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
            if (cell.PosX < maze.Maze.Length - 1)
                neighbors.Add(maze.Maze[cell.PosX + 1][cell.PosY]);
            if (cell.PosY < maze.Maze[0].Length - 1)
                neighbors.Add(maze.Maze[cell.PosX][cell.PosY + 1]);
            if (cell.PosX > 0)
                neighbors.Add(maze.Maze[cell.PosX - 1][cell.PosY]);
            if (cell.PosY > 0)
                neighbors.Add(maze.Maze[cell.PosX][cell.PosY - 1]);

            return neighbors;
        }

        public static List<Cell> GetWeightSortedCells(List<Cell> cells)
        {
            return cells.OrderBy(cell => cell.Weight).ToList();
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

        public static void CalculateWeight(Cell goal, Cell cell)
        {
            cell.Weight = Math.Sqrt(cell.PosX * goal.PosX + cell.PosY * goal.PosY);
        }

        public static bool IsNotVisited(Cell cell)
        {
            return cell.State != CellState.visited;
        }

        public static bool IsNotWall(Cell cell)
        {
            return cell.State != CellState.wall;
        }

        public static List<OperationChrono<Cell>> GetPathFromStack(Stack<Cell> path, MazeModel mazeModel, int sequence)
        {
            var operations = new List<OperationChrono<Cell>>();

            while (path.Count > 0)
            {
                var curr = path.Pop();
                var original = CloneCell(curr);
                mazeModel.Maze[curr.PosX][curr.PosY].State = CellState.path;
                operations.Add(new OperationChrono<Cell>(original, mazeModel.Maze[curr.PosX][curr.PosY], sequence++));
            }

            return operations;
        }

        public static bool WeightMaze(MazeModel mazeModel, Cell goal)
        {
            for (int i = 0; i < mazeModel.Maze.Length; i++)
            {
                for (int j = 0; j < mazeModel.Maze[i].Length; j++)
                {
                    CalculateWeight(goal, mazeModel.Maze[i][j]);
                }
            }

            return true;
        }

    }
}
