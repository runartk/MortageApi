using System;
using mortageCalculator.Models;

namespace mortageCalculator.Services
{
	public interface IMortageService
	{
        public List<MonthlyMortageStatistics> GenerateMonthlyHouseMortagePlan(double amount, int years);
    }
}
