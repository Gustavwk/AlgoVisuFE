using AlgoVisuFSLogic.Model.Enums;
using AlgoVisuFSLogic.MazeSolver;
using AlgoVisuFSLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoVisuFSLogicTests.Maze;

namespace DFSSolverTests
{
    [TestFixture]
    public class DFSSolverTests
    {
        private DFSSolver solver;

        [SetUp]
        public void Setup()
        {
            solver = new DFSSolver();
        }

        [Test]
        public void Solve_SolvableMaze_ReturnsCorrectPath()
        {
            int[][] mazeArr = new int[][]
            {
                new int[] { 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 7, 2, 1, 2, 2, 2, 1 },
                new int[] { 1, 2, 1, 2, 1, 2, 1 },
                new int[] { 1, 2, 2, 2, 1, 2, 1 },
                new int[] { 1, 1, 1, 2, 1, 2, 9 },
                new int[] { 1, 1, 1, 2, 2, 2, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1 }
            };

            var maze = MazeTestUtils.MazeParser(mazeArr);

            var startCell = maze.Maze.First(row => row.Any(cell => cell.isStart)).First(cell => cell.isStart);

            var result = solver.Solve(maze, startCell);

            Assert.That(result.Maze.Any(row => row.Any(cell => cell.isGoal && cell.State == CellState.path)), Is.True);
        }

        [Test]
        public void Solve_UnsolvableMaze_ReturnsNoPath()
        {
            int[][] mazeArr = new int[][]
            {
                new int[] { 1, 1, 1, 1, 1, 1, 1 },
                new int[] { 7, 2, 1, 2, 2, 2, 1 },
                new int[] { 1, 1, 1, 2, 1, 2, 1 },
                new int[] { 1, 2, 1, 1, 1, 2, 1 },
                new int[] { 1, 1, 1, 2, 1, 2, 9 },
                new int[] { 1, 1, 1, 2, 2, 2, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1 }
            };

            var maze = MazeTestUtils.MazeParser(mazeArr);

            var startCell = maze.Maze.First(row => row.Any(cell => cell.isStart)).First(cell => cell.isStart);

            var result = solver.Solve(maze, startCell);

            Assert.That(result.Maze.Any(row => row.Any(cell => cell.isGoal && cell.State == CellState.path)), Is.False);
        }

        
    }
}
