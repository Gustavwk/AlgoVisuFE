import React, { useEffect, useState } from 'react';
import { CompleteBudgetGetResponseDto } from '../api';
import { BudgetCalculatorService } from '../api/services/BudgetCalculatorService';
import './CompleteBudgetComponent.css'; 

interface CompleteBudgetInputProps {
  initialRemainingCapital: number;
  initialMinimumDailyBudget: number;
}

const NaivBudgetComponent: React.FC<CompleteBudgetInputProps> = ({ initialRemainingCapital, initialMinimumDailyBudget }) => {
  const [completeBudget, setCompleteBudget] = useState<CompleteBudgetGetResponseDto | null>(null);
  const [remainingCapital, setRemainingCapital] = useState<string>(initialRemainingCapital.toString());
  const [minimumDailyBudget, setMinimumDailyBudget] = useState<string>(initialMinimumDailyBudget.toString());

  useEffect(() => {
    const fetchCompleteBudget = async () => {
      try {
        const remainingCapitalNumber = parseFloat(remainingCapital);
        const minimumDailyBudgetNumber = parseFloat(minimumDailyBudget);
        
        if (!isNaN(remainingCapitalNumber) && !isNaN(minimumDailyBudgetNumber)) {
          const response = await BudgetCalculatorService.getCompleteBudget(remainingCapitalNumber, minimumDailyBudgetNumber);
          setCompleteBudget(response);
          console.log(response);
        }
      } catch (error) {
        console.error('Error fetching complete budget:', error);
      }
    };

    fetchCompleteBudget();
  }, [remainingCapital, minimumDailyBudget]);

  const handleRemainingCapitalInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setRemainingCapital(event.target.value);
  };

  const handleMinimumDailyBudgetInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setMinimumDailyBudget(event.target.value);
  };

  return (
    <div className="budget-container">
      <h1>Hvor Fucked er jeg?</h1>
      <div className="input-container">
        <label>
          Enter Remaining Capital:
          <input type="number" value={remainingCapital} onChange={handleRemainingCapitalInputChange} />
        </label>
      </div>
      <div className="input-container">
        <label>
          Enter Minimum Daily Budget:
          <input type="number" value={minimumDailyBudget} onChange={handleMinimumDailyBudgetInputChange} />
        </label>
      </div>
      {completeBudget ? (
        <div className="result-container">
          <p>Daily Budget: {completeBudget.dailyBudget.toFixed(2)}</p>
          <p>Daily Budget After Spending Daily Budget: {completeBudget.dailyBudgetAfterSpendingDailyBudget.toFixed(2)}</p>
          <p>Daily Budget After Spending 1000: {completeBudget.dailyBudgetAfterSpendingThousand.toFixed(2)}</p>
          <p>Daily Budget Tomorrow if Nothing Spent Today: {completeBudget.dailyBudgetTomorrow.toFixed(2)}</p>
          <p>Possible Monthly Savings on Minimum Budget: {completeBudget.possibleMonthlySavings.toFixed(2)}</p>
          <p>Remaining Days in Month: {completeBudget.remainingDays}</p>
        </div>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
};

export default NaivBudgetComponent;
