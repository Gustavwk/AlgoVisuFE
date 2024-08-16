import React from 'react';
import logo from './logo.svg';
import './App.css';
import { OpenAPI } from './api';
import Cell from './Components/MazeComponents/Cell';
import Maze from './Components/MazeComponents/ClickMazeComponent';

function App() {
  console.log('Environment Variables:', process.env);
  console.log('API Base URL:', process.env.REACT_APP_API_BASE_URL);
  OpenAPI.BASE = process.env.REACT_APP_API_BASE_URL || "";
  return (
      <main>
        <Maze width={15} height={15} start={{x: 0, y: 0}} goal={{x: 14, y: 14}
        }/>
      </main>
  );
}

export default App;
