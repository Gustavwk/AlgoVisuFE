namespace AlgoVisuFSLogic.Model
{
    public class CompleteBudgetModel
    {
        public int RemainingDays { get; set; }
        public double DailyBudget { get; set; }
        public double DailyBudgetAfterSpendingDailyBudget { get; set; }
        public double DailyBudgetAfterSpendingThousand { get; set; }
        public double DailyBudgetTomorrow { get; set; }
        public double PossibleMonthlySavings { get; set; }
    }
}
