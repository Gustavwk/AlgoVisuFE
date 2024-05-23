using AlgoVisuFSLogic.Model;
using System;

namespace AlgoVisuFSLogic.BudgetCalculatorService
{
    public interface IBudgetCalculatorService
    {
        BudgetResponseModel CalculateBudget(double RemainingCapital);
        CompleteBudgetModel CalculateCompleteBudget(double RemainingCapital, double minimumDailySpending);
    }
}
