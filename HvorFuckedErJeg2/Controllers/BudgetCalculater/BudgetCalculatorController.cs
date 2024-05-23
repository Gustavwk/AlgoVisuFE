using Microsoft.AspNetCore.Mvc;
using HvorFuckedErJeg2Logic.BudgetCalculatorService;
using HvorFuckedErJeg2.WebApi.Mappers;
using HvorFuckedErJeg2.WebApi.Dtos;

namespace HvorFuckedErJeg2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetCalculatorController : ControllerBase
    {

        private readonly ILogger<BudgetCalculatorController> _logger;
        private readonly IBudgetCalculatorService _budgetCalculater;

        public BudgetCalculatorController(ILogger<BudgetCalculatorController> logger, IBudgetCalculatorService budgetCalculatorService)
        {
            _logger = logger;
            _budgetCalculater = budgetCalculatorService;
        }

        [HttpGet("NaivBudget", Name = "GetNaivBudget")]
        public Task<NaivBudgetGetResponseDto> GetNaivBudget(double RemainingCapital) 
        { 
            var result = _budgetCalculater.CalculateBudget(RemainingCapital).Map();
            return Task.FromResult(result);
        }

        [HttpGet("CompleteBudget", Name = "GetCompleteBudget")]
        public Task<CompleteBudgetGetResponseDto> GetCompleteBudget(double RemainingCapital, double MinimumPossibleSpending)
        {
            var result = _budgetCalculater.CalculateCompleteBudget(RemainingCapital, MinimumPossibleSpending).Map();
            return Task.FromResult(result);
        }
    }
}