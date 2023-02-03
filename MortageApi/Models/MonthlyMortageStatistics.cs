using System;
namespace mortageCalculator.Models
{
	public class MonthlyMortageStatistics
	{
        public int Month { get; set; }
		public double TotalMortage { get; set; }
        public double Interest { get; set; }
        public double DownPayment { get; set; }

        public MonthlyMortageStatistics(int month, double totalMortage, double interst, double downPayment)
        {
            Month = month;
            TotalMortage = totalMortage;
            Interest = interst;
            DownPayment = downPayment;
        }
    }
}
