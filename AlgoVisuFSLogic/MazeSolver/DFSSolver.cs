using AlgoVisuFSLogic.Model;
using AlgoVisuFSLogic.Model.Enums;
using AlgoVisuFSLogic.Model.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisuFSLogic.MazeSolver
{
    public class DFSSolver : IDFSSolver
    {

        public DFSSolver()
        { }

        public List<OperationChrono<Cell>> Solve(MazeModel maze, Cell startCell)
        {
            var stack = new Stack<Cell>();
            stack.Push(startCell);
            startCell.State = CellState.visited;
            var operations = new List<OperationChrono<Cell>>();
            var sequence = 0;
            while (stack.Count > 0)
            {
                var pos = stack.Peek();

                if (pos.isGoal)
                {
                    operations.AddRange(GetPath(stack, maze, sequence));
                    return operations;
                }

                var nextCell = GetUnvisitedNeighbor(maze, pos);

                if (nextCell != null)
                {
                    sequence++;
                    var original = MazeUtils.CloneCell(nextCell);
                    nextCell.State = CellState.visited;
                    operations.Add(new OperationChrono<Cell>(original, nextCell, sequence));
                    stack.Push(nextCell);
                }
                else
                {
                    stack.Pop();
                }
            }
            return operations;
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

        private List<OperationChrono<Cell>> GetPath(Stack<Cell> path, MazeModel mazeModel, int sequence)
        {
            var operations = new List<OperationChrono<Cell>>();

            while (path.Count > 0)
            {
                var curr = path.Pop();
                var original = MazeUtils.CloneCell(curr);
                mazeModel.Maze[curr.PosX][curr.PosY].State = CellState.path;
                operations.Add(new OperationChrono<Cell>(original, mazeModel.Maze[curr.PosX][curr.PosY], sequence++));
            }

            return operations;
        }
    }
}
