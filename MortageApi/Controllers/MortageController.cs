using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mortageCalculator.Models;
using mortageCalculator.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mortageCalculator.Controllers
{
    [ApiController]
    public class MortageController : ControllerBase
    {
        private IMortageService _service;

        public MortageController(IMortageService service)
        {
            _service = service;
        }

        [HttpPost("mortages/calculate")]
        public async Task<List<MonthlyMortageStatistics>> Calculate([FromBody] MortageRequest request)
        {
            List<MonthlyMortageStatistics> mortagePlan = null;
            try
            {
                mortagePlan = _service.GenerateMonthlyHouseMortagePlan(request.Amount, request.PaybackTime);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(mortagePlan);
            }
            return await Task.FromResult(mortagePlan);
        }
    }
}
