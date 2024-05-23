﻿using HvorFuckedErJeg2.WebApi.Dtos;
using HvorFuckedErJeg2Logic.Model;

namespace HvorFuckedErJeg2.WebApi.Mappers
{
    public static class BudgetMapper
    {
        public static NaivBudgetGetResponseDto Map(this BudgetResponseModel model) => new()
        {
            DailySpending = model.DailySpending
        };

        public static CompleteBudgetGetResponseDto Map(this CompleteBudgetModel model) => new()
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
