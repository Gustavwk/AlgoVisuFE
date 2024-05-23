using System.ComponentModel.DataAnnotations;

namespace HvorFuckedErJeg2.WebApi.Dtos
{
    public class NaivBudgetGetResponseDto
    {
        [Required]
        public double DailySpending { get; init; }
    }
}
