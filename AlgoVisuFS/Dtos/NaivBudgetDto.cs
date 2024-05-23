using System.ComponentModel.DataAnnotations;

namespace AlgoVisuFS.WebApi.Dtos
{
    public class NaivBudgetDto
    {
        [Required]
        public double DailySpending { get; init; }
    }
}
