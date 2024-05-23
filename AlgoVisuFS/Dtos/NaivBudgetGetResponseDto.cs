using System.ComponentModel.DataAnnotations;

namespace AlgoVisuFS.WebApi.Dtos
{
    public class NaivBudgetGetResponseDto
    {
        [Required]
        public double DailySpending { get; init; }
    }
}
