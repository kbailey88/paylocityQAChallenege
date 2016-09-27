using System;
using paylocityQAChallenge.Common.Interface;

namespace paylocityQAChallenge.Common.Implementation
{
    class BenefitsCalculator : IBenefitsCalculator
    {
        public decimal GetBenefitCost(decimal salary, decimal costPerYear, decimal dependentCostPerYear, int dependents)
        {
            return Math.Round((costPerYear / 26) + (dependents * (dependentCostPerYear / 26)), 2);
        }

        public decimal GetNetPay(decimal salary, decimal benefitsCost, int dependents, decimal costPerDependent)
        {
            decimal biweeklySalary = Decimal.Round(salary / 26);
            return biweeklySalary - GetBenefitCost(salary, benefitsCost, costPerDependent, dependents);
        }
    }
}