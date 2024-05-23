using HvorFuckedErJeg2Logic.Model;
using System;

namespace HvorFuckedErJeg2Logic.BudgetCalculatorService
{
    public class BudgetCalculatorService : IBudgetCalculatorService
    {
        public BudgetCalculatorService()
        {
        }

        public BudgetResponseModel CalculateBudget(double remainingCapital)
        {
            return new BudgetResponseModel
            {
                DailySpending = CalculateDailyBudgetFromDateTime(remainingCapital, DateTime.Now)
            };
        }

        public CompleteBudgetModel CalculateCompleteBudget(double remainingCapital, double minimumDailySpending)
        {
            var today = DateTime.Now;
            var tomorrow = today.AddDays(1);
            var yesterday = today.AddDays(-1);
            var remainingDays = (int)RemainingDaysInMonth(today).TotalDays;

            var dailyBudget = CalculateDailyBudgetFromDateTime(remainingCapital, today);
            var dailyAfterSpendingAThousand = CalculateDailyBudgetFromDateTime(remainingCapital - 1000, today);
            var dailyBudgetTomorrow = CalculateDailyBudgetFromDateTime(remainingCapital, tomorrow);
            var dailyBudgetAfterDailyBudget = CalculateDailyBudgetFromDateTime(remainingCapital, yesterday);
            var possibleMonthlySavings = PossibleMonthlySavingsFromDate(dailyBudget, minimumDailySpending, today);

            return new CompleteBudgetModel
            {
                RemainingDays = remainingDays,
                DailyBudget = dailyBudget,
                DailyBudgetAfterSpendingDailyBudget = dailyBudgetAfterDailyBudget,
                DailyBudgetAfterSpendingThousand = dailyAfterSpendingAThousand,
                DailyBudgetTomorrow = dailyBudgetTomorrow,
                PossibleMonthlySavings = possibleMonthlySavings,
            };
        }

        private static double CalculateDailyBudgetFromDateTime(double remainingCapital, DateTime dateTime)
        {
            TimeSpan remaining = RemainingDaysInMonth(dateTime);
            int remainingDays = remaining.Days;

            if (remainingDays == 0)
            {
                return remainingCapital;
            }

            return remainingCapital / remainingDays;
        }

        private static TimeSpan RemainingDaysInMonth(DateTime day)
        {
            DateTime startOfNextMonth = new DateTime(day.Year, day.Month, 1).AddMonths(1);
            TimeSpan remaining = startOfNextMonth - day;
            return remaining;
        }

        private static double PossibleMonthlySavingsFromDate(double possibleDailySpending, double minimumDailySpending, DateTime dateTime)
        {
            double remainingDays = RemainingDaysInMonth(dateTime).TotalDays;
            double possibleMonthlySavings = (possibleDailySpending - minimumDailySpending) * remainingDays;

            return possibleMonthlySavings < 0 ? 0 : possibleMonthlySavings;
        }
    }
}
