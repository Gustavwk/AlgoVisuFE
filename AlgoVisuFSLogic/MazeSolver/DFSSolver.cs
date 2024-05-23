using AlgoVisuFSLogic.Model;
using AlgoVisuFSLogic.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HvorFuckedErJeg2Logic.MazeSolver
{
    internal class DFSSolver : IMazeSolver
    {

        public DFSSolver() 
        { }

        public MazeModel Solve(MazeModel maze, Cell startCell)
        {
            var stack = new Stack<Cell>();
            stack.Push(startCell);
            startCell.State = CellState.visited; 

            while (stack.Count > 0)
            {
                var pos = stack.Peek();

                if (pos.isGoal)
                {
                    return GetPath(stack, maze);
                }

                var nextCell = GetUnvisitedNeighbor(maze, pos);

                if (nextCell != null)
                {
                    nextCell.State = CellState.visited;
                    stack.Push(nextCell);
                }
                else
                {
                    stack.Pop();
                }
            }
            return maze;
        }

        private Cell GetUnvisitedNeighbor(MazeModel maze, Cell cell)
        {
            foreach (var neighbor in MazeUtils.GetNeighborsFromCell(maze, cell))
            {
                if (IsNotVisited(neighbor) && IsNotWall(neighbor))
                {
                    return neighbor;
                }
            }
            return null;
        }

        private static bool IsNotVisited(Cell cell)
        { 
            return cell.State != CellState.visited;
        }

        private static bool IsNotWall(Cell cell)
        { 
             return cell.State != CellState.wall;
        }

        private MazeModel GetPath(Stack<Cell> path, MazeModel mazeModel) 
        { 
            while (path.Count > 0) 
            { 
                var curr = path.Pop();
                mazeModel.Maze[curr.PosX][curr.PosY].State = CellState.path;
            }
            return mazeModel;
        }
    }
}
