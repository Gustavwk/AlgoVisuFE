import React from 'react';
import logo from './logo.svg';
import './App.css';
import NaivBudgetComponent from './Components/NaivBudgetComponent';
import { OpenAPI } from './api';
import CompleteBudgetComponent from './Components/CompleteBudgetComponent';

function App() {
  console.log('Environment Variables:', process.env);
  console.log('API Base URL:', process.env.REACT_APP_API_BASE_URL);
  OpenAPI.BASE = process.env.REACT_APP_API_BASE_URL || "";
  return (
      <main>
        <CompleteBudgetComponent initialRemainingCapital={1000} initialMinimumDailyBudget={1000} />
      </main>
  );
}

export default App;
