#pragma warning disable CS8602

using Models;

namespace Operations;

public class NeedsEvaluator
{
    private readonly MarketStorage marketStorage;
    private readonly Random _random;
    public NeedsEvaluator(MarketStorage marketStorage)
    {
        this.marketStorage = marketStorage;
        _random = new Random();
    }
    public void EvaluateNeeds(Customer customer)
    {
        customer.Needs[ProductCategory.Crucial] += Math.Round(_random.NextDouble(), 2);
        customer.Needs[ProductCategory.Essential] += Math.Round(_random.NextDouble(), 2);
        customer.Needs[ProductCategory.Standard] += Math.Round(_random.NextDouble() * 0.8, 2);
        customer.Needs[ProductCategory.Optional] += Math.Round(_random.NextDouble() * 0.4, 2);
        customer.Needs[ProductCategory.Luxury] += Math.Round(_random.NextDouble() * 0.2, 2);
        customer.Needs[ProductCategory.SuperLuxury] += Math.Round(_random.NextDouble() * 0.1, 2);
        foreach (var need in customer.Needs)
        {
            var oldCheapest = marketStorage.GetProductsByCategory(need.Key).OrderBy(p => p.StartingPrice).FirstOrDefault().Price;
            var newCheapest = marketStorage.GetProductsByCategory(need.Key).OrderBy(p => p.Price).FirstOrDefault().Price;
            customer.Needs[need.Key] *= oldCheapest / newCheapest;
        }
    }
}