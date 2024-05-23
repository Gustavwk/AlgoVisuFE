using AlgoVisuFSLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisuFSLogic.MazeSolver
{
    public interface IDFSSolver
    {
        MazeModel Solve(MazeModel maze, Cell startCell);
    }
}
