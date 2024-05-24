using AlgoVisuFSLogic.Model;
using AlgoVisuFSLogic.Model.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisuFSLogic.MazeSolver
{
    public interface IDFSSolver
    {
        List<OperationChrono<Cell>> Solve(MazeModel maze, Cell startCell);
    }
}
