using AlgoVisuFSLogic.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisuFSLogic.Model
{
    public class Cell 
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public double Weight { get; set; }
        public CellState State { get; set; }
        public bool isGoal { get; set; }
        public bool isStart { get; set; }

    }

    public class MazeModel
    {
        public bool Solvable { get; set; }
        public Cell[][] Maze { get; set; }
    }   
}
