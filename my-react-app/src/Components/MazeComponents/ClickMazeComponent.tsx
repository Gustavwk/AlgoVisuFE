import React, { useEffect, useState } from "react";
import Cell from "./Cell";
import '../../Styles/Maze.css';
import { CellState } from "./CellState";
import { DfsService } from "../../api";

interface MazeProps {
  width: number;
  height: number;
  goal: coordinate;
  start: coordinate;
}

type coordinate = {
  x: number;
  y: number;
}

const Maze: React.FC<MazeProps> = ({ width, height, goal, start }) => {
  const [cellStates, setCellStates] = useState<CellState[][]>(() => {
    const initialStates = Array.from({ length: height }, () =>
      Array(width).fill(CellState.free)
    );

    initialStates[start.y][start.x] = CellState.start;
    initialStates[goal.y][goal.x] = CellState.goal;
    
    return initialStates;
  });

  useEffect(() => {
    console.log('Initialized Cell States:', cellStates);
  }, [cellStates]);

  const handleCellClick = (x: number, y: number) => {
    setCellStates((prevStates) => {
      const newStates = prevStates.map((row) => [...row]);
      newStates[y][x] =
        newStates[y][x] === CellState.free ? CellState.wall : CellState.free;
      return newStates;
    });
  };

  const sendMazeToAPI = () => {
    console.log(cellStates);
    DfsService.postDfsSolve(cellStates).then((response) => {
      console.log(response);
      const mazeModel = response.mazeModel;
      setCellStates(mazeModel); // Update state with the new maze model
    });
  };

  const generateCells = () => {
    const cells = [];
  
    for (let y = 0; y < height; y++) {
      for (let x = 0; x < width; x++) {
        const isStart = x === start.x && y === start.y;
        const isGoal = x === goal.x && y === goal.y;
        
        const cellKey = `${x}-${y}-${isStart ? 'start' : isGoal ? 'goal' : 'normal'}`;
        
        cells.push(
          <Cell
            key={cellKey}
            posX={x}
            posY={y}
            weight={0}
            state={isStart ? CellState.start : isGoal ? CellState.goal : cellStates[y][x]}
            onClick={() => handleCellClick(x, y)}
          />
        );
      }
    }
    return cells;
  };
  
  return( 
    <>
      <button onClick={sendMazeToAPI}>Send maze</button>
      <div className="maze">{generateCells()}</div> 
    </>
  );
};

export default Maze;
