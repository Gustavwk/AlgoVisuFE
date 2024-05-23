// src/components/NaivBudgetComponent.tsx
import React, { useEffect, useState } from 'react';
import { NaivBudgetGetResponseDto } from '../api/models/NaivBudgetGetResponseDto';
import { BudgetCalculatorService } from '../api/services/BudgetCalculatorService';

interface NaivBudgetComponentProps {
  initialRemainingCapital: number;
}

const NaivBudgetComponent: React.FC<NaivBudgetComponentProps> = ({ initialRemainingCapital }) => {
  const [naivBudget, setNaivBudget] = useState<NaivBudgetGetResponseDto | null>(null);
  const [remainingCapital, setRemainingCapital] = useState<number>(initialRemainingCapital);

  useEffect(() => {
    const fetchNaivBudget = async () => {
      try {
        const response = await BudgetCalculatorService.getNaivBudget(remainingCapital);
        setNaivBudget(response);
        console.log(response)
      } catch (error) {
        console.error('Error fetching naiv budget:', error);
      }
    };

    fetchNaivBudget();
  }, [remainingCapital]);

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const newValue = parseFloat(event.target.value);
      setRemainingCapital(newValue);
  };

  return (
    <div>
    <div>
      <label>
        Indtast din resterende saldo: 
        <input type="number" value={remainingCapital} onChange={handleInputChange} />
      </label>
    </div>
    {naivBudget ? (
      <div>
        <p>Dagligt budget: {naivBudget.dailySpending.toFixed(2)}</p>
      </div>
    ) : (
      <p>Loading...</p>
    )}
  </div>
);
};

export default NaivBudgetComponent;