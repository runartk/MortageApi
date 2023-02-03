using System;
using mortageCalculator.Models;

namespace mortageCalculator.Services
{
	public class MortageService : IMortageService
	{
		private HouseMortageService _houseMortageService;

		public MortageService(HouseMortageService houseMortageService)
		{
			_houseMortageService = houseMortageService;
		}

		public List<MonthlyMortageStatistics> GenerateMonthlyHouseMortagePlan(double amount, int years)
		{
			double fixedPayment = _houseMortageService.GetFixedPaymentEachMonth(amount, years);
            return _houseMortageService.GeneratePaymentPlan(amount, years, fixedPayment);
		}
    }
}
