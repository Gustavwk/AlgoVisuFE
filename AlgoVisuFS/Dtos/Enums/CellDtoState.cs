using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisuFS.WebApi.Dtos.Enums
{
    public enum CellDtoState
    {
        visited = 0,
        wall = 1,
        free = 2,
        currentPos = 3,
        path = 4,
    }
}
