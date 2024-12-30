namespace Ambev.DeveloperEvaluation.Application.Sales.DiscountStrategies
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal value)
        {
            return 0;
        }
    }
}