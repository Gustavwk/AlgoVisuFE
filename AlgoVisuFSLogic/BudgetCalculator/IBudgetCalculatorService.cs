using HvorFuckedErJeg2Logic.Model;
using System;

namespace HvorFuckedErJeg2Logic.BudgetCalculatorService
{
    public interface IBudgetCalculatorService
    {
        BudgetResponseModel CalculateBudget(double RemainingCapital);
        CompleteBudgetModel CalculateCompleteBudget(double RemainingCapital, double minimumDailySpending);
    }
}
