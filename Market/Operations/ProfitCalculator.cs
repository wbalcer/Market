namespace Operations;

using Models;


public class ProfitCalculator
{
    private readonly Dictionary<ProductCategory, double> _actualProfit = new();

    public void AddProfit(ProductCategory category, double profit)
    {
        if (_actualProfit.ContainsKey(category))
        {
            _actualProfit[category] += profit;
        }
        else
        {
            _actualProfit[category] = profit;
        }
    }

    public void ResetProfit() => _actualProfit.Clear();

    public double GetProfit(ProductCategory category) =>
        _actualProfit.TryGetValue(category, out var profit) && profit != 0 ? profit : 0;

    public double CalculateExpectedProfit(int customerCount, List<Product> products, ProductCategory category)
    {
        var markup = products.FirstOrDefault(p => p.Category == category)?.Markup ?? 0;
        var profitFactor = WeightProvider.GetWeight(category);
        return markup * profitFactor * customerCount;
    }
}