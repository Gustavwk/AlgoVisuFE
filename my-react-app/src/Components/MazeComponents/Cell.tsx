// src/Cell.tsx
import React from "react";
import '../../Styles/Cell.css'; // Importer CSS-filen
import { CellState } from "./CellState";

interface CellProps {
  posX: number;
  posY: number;
  weight: number;
  state: CellState;
  onClick: () => void;
}

const Cell: React.FC<CellProps> = ({ posX, posY, weight, state, onClick }) => {
  const getClassNames = () => {
    let classNames = "cell";
    if (state === CellState.start) classNames += " start";
    if (state === CellState.goal) classNames += " goal";
    if (state === CellState.visited) classNames += " visited";
    if (state === CellState.path) classNames += " path";
    if (state === CellState.wall) classNames += " wall";
    if (state === CellState.free) classNames += " free";
    return classNames;
  };

  return (
    <div
      className={getClassNames()}
      onClick={onClick}
      style={{ left: `${posX * 50}px`, top: `${posY * 50}px`, position: "absolute" }}
    ></div>
  );
};

export default Cell;
