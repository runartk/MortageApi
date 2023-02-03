using System;
using MortageApi.Models;
using mortageCalculator.Models;

namespace mortageCalculator.Services
{
	public class HouseMortageService
	{
        public const double Interest = LoanTypes.Standard;

		public HouseMortageService(){}

        public double GetFixedPaymentEachMonth(double amount, int years)
        {
            double interestInDecimal = Interest / 100;
            double months = years * 12;
            
            double ratePerMonth = interestInDecimal / 12;
            double numerator = amount * ratePerMonth;
            double denominator = 1 - Math.Pow((1 + ratePerMonth), - months);
            return numerator / denominator;
        }

        public List<MonthlyMortageStatistics> GeneratePaymentPlan(double amount, int years, double monthlyPayment)
        {
            var paymentPlan = new List<MonthlyMortageStatistics>();
            double interestInDecimal = Interest / 100;
            int months = years * 12;
            double restAmount = amount;
            double monthlyInterest;
            double monthlyDownPayment;

            for (int i = 1; i <= months; i++)
            {
                monthlyInterest = restAmount * interestInDecimal / 12;
                monthlyDownPayment = monthlyPayment - monthlyInterest;
                paymentPlan.Add(new MonthlyMortageStatistics(i, monthlyPayment, monthlyInterest, monthlyDownPayment));
                restAmount -= monthlyDownPayment;
            }
            return paymentPlan;
        }
    }
}
