using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisuFSLogic.Model.Enums
{
    public enum CellState
    {
        visited = 0,
        wall = 1,
        free = 2,
        currentPos = 3,
        path = 4,
    }
}
