using Microsoft.AspNetCore.Mvc;
using AlgoVisuFS.WebApi.Mappers;
using AlgoVisuFS.WebApi.Dtos;
using AlgoVisuFSLogic.BudgetCalculatorService;

namespace AlgoVisuFS.Controllers
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
            _budgetCalculater = budgetCalculatorService ?? throw new ArgumentNullException(nameof(budgetCalculatorService));
        }

        [HttpGet("NaivBudget", Name = "GetNaivBudget")]
        public Task<NaivBudgetDto> GetNaivBudget(double RemainingCapital) 
        { 
            var result = _budgetCalculater.CalculateBudget(RemainingCapital).Map();
            return Task.FromResult(result);
        }

        [HttpGet("CompleteBudget", Name = "GetCompleteBudget")]
        public Task<CompleteBudgetDto> GetCompleteBudget(double RemainingCapital, double MinimumPossibleSpending)
        {
            var result = _budgetCalculater.CalculateCompleteBudget(RemainingCapital, MinimumPossibleSpending).Map();
            return Task.FromResult(result);
        }
    }
}