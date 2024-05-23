using AlgoVisuFS.WebApi.Dtos;
using AlgoVisuFSLogic.Model;

namespace AlgoVisuFS.WebApi.Mappers
{
    public static class BudgetMapper
    {
        public static NaivBudgetDto Map(this BudgetResponseModel model) => new()
        {
            DailySpending = model.DailySpending
        };

        public static CompleteBudgetDto Map(this CompleteBudgetModel model) => new()
        {
            DailyBudget = model.DailyBudget,
            DailyBudgetAfterSpendingDailyBudget = model.DailyBudgetAfterSpendingDailyBudget,
            DailyBudgetAfterSpendingThousand = model.DailyBudgetAfterSpendingThousand,
            DailyBudgetTomorrow = model.DailyBudgetTomorrow,
            PossibleMonthlySavings = model.PossibleMonthlySavings,
            RemainingDays = model.RemainingDays,
        };
    }
}
