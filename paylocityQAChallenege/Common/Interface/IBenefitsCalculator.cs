namespace paylocityQAChallenge.Common.Interface
{
    public interface IBenefitsCalculator
    {
        decimal GetNetPay(decimal salary, decimal benefitsCost, int dependents, decimal costPerDependent);

        decimal GetBenefitCost(decimal salary, decimal costPerYear, decimal dependentCostPerYear, int dependents);
    }
}
