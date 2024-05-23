using System.ComponentModel.DataAnnotations;

namespace AlgoVisuFS.WebApi.Dtos
{
    public class CompleteBudgetGetResponseDto
    {
        [Required]
        public double DailyBudget { get; init; }
        [Required]
        public double DailyBudgetAfterSpendingDailyBudget { get; init; }
        [Required]
        public double DailyBudgetAfterSpendingThousand { get; init; }
        [Required]
        public double DailyBudgetTomorrow { get; init; }
        [Required]
        public double PossibleMonthlySavings { get; init; }
        [Required]
        public int RemainingDays { get; init; }
    }
}
