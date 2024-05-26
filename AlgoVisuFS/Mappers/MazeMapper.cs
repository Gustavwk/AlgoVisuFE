using AlgoVisuFS.WebApi.Dtos;
using AlgoVisuFSLogic.Model;
using AlgoVisuFSLogic.Model.Enums;
using AlgoVisuFSLogic.Model.Generics;
using System.Collections.Generic;
using System.Linq;

namespace AlgoVisuFS.WebApi.Mappers
{
    public static class MazeMapper
    {
        public static CellGetDto Map(this Cell cell) => new()
        {
            PosX = cell.PosX,
            PosY = cell.PosY,
            Weight = cell.Weight,
            State = (int)cell.State,
            IsGoal = cell.isGoal,
            IsStart = cell.isStart
        };

        public static Cell Map(this CellGetDto cellDto) => new()
        {
            PosX = cellDto.PosX,
            PosY = cellDto.PosY,
            Weight = cellDto.Weight,
            State = (CellState)cellDto.State,
            isGoal = cellDto.IsGoal,
            isStart = cellDto.IsStart
        };

        public static MazeModelDto Map(this MazeModel model) => new()
        {
            Solvable = model.Solvable,
            Maze = model.Maze.Select(row => row.Select(cell => cell.Map()).ToList()).ToList()
        };

        public static MazeModel MapToMazeModel(this MazeModelDto dto)
        {
            Cell[][] maze = dto.Maze.Select(row => row.Select(cellDto => new Cell
            {
                PosX = cellDto.PosX,
                PosY = cellDto.PosY,
                Weight = cellDto.Weight,
                State = (CellState)cellDto.State,
                isGoal = cellDto.IsGoal,
                isStart = cellDto.IsStart
            }).ToArray()).ToArray();

            return new MazeModel
            {
                Solvable = dto.Solvable,
                Maze = maze
            };
        }

        public static OperationChronoDto<CellGetDto> Map(this OperationChrono<Cell> op) => new()
        {
            SequenceNumber = op.SequenceNumber,
            From = op.From.Map(),
            To = op.To.Map()
        };
    }
}
