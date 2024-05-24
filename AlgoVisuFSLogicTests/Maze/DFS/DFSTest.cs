using AlgoVisuFSLogic.MazeSolver;
using AlgoVisuFSLogic.Model;
using AlgoVisuFSLogic.Model.Enums;
using AlgoVisuFSLogic.Model.Generics;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AlgoVisuFSLogicTests.Maze
{
    public class DFSSolverTests
    {
        [Test]
        public void TestSolveMaze()
        {
            int[][] mazeArray = new int[][]
            {
                new int[] { 7, 2, 1, 1, 1 },
                new int[] { 1, 2, 2, 2, 1 },
                new int[] { 1, 1, 1, 2, 9 }
            };

            MazeModel mazeModel = MazeParser.Parse(mazeArray);
            Cell startCell = mazeModel.Maze[0][0]; // assuming start cell is marked with 7

            var solver = new DFSSolver();
            List<OperationChrono<Cell>> operations = solver.Solve(mazeModel, startCell);

            Assert.IsNotNull(operations);
            Assert.IsTrue(operations.Any(op => op.To.isGoal));

            foreach (var operation in operations)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(operation.From, Is.Not.Null);
                    Assert.That(operation.To, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(operation.To.PosX, Is.EqualTo(operation.From.PosX));
                    Assert.That(operation.To.PosY, Is.EqualTo(operation.From.PosY));
                    Assert.That(operation.To.State, Is.Not.EqualTo(operation.From.State));
                });
            }
        }

        [Test]
        public void TestUnsolvableMaze()
        {
            int[][] mazeArray = new int[][]
            {
                new int[] { 7, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 1 },
                new int[] { 1, 1, 1, 1, 9 }
            };

            MazeModel mazeModel = MazeParser.Parse(mazeArray);
            Cell startCell = mazeModel.Maze[0][0]; // assuming start cell is marked with 7

            var solver = new DFSSolver();
            List<OperationChrono<Cell>> operations = solver.Solve(mazeModel, startCell);

            Assert.That(operations, Is.Not.Null);
            Assert.That(operations.Any(op => op.To.isGoal), Is.False);
        }
    }
}
