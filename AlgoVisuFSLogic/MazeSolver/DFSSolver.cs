﻿using AlgoVisuFSLogic.Model;
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
                    operations.AddRange(MazeUtils.GetPathFromStack(stack, maze, sequence));
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
                if (MazeUtils.IsNotVisited(neighbor) && MazeUtils.IsNotWall(neighbor))
                {
                    return neighbor;
                }
            }
            return null;
        }
    }
}
