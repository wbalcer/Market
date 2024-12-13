using Models;

namespace Operations;

public class ExpectedSalesCalculator
{

    public double CalculateExpectedSales(IReadOnlyList<Product> products, int customerCount)
    {
        double expectedSales = 0;

        foreach (ProductCategory category in  Enum.GetValues(typeof(ProductCategory)))
        {
            var product = products.FirstOrDefault(p => p.Category == category);
            if (product != null)
            {
                expectedSales += product.Price * customerCount * WeightProvider.GetWeight(category);
            }
        }

        return expectedSales;
    }
}
