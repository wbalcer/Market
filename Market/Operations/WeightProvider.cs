namespace Operations;
using Models;

public static class WeightProvider
{
    private static readonly Dictionary<ProductCategory, double> _weights = new()
    {
        { ProductCategory.Crucial, 0.5 },
        { ProductCategory.Essential, 0.3 },
        { ProductCategory.Standard, 0.18 },
        { ProductCategory.Optional, 0.12 },
        { ProductCategory.Luxury, 0.05 },
        { ProductCategory.SuperLuxury, 0.02 }
    };

    public static double GetWeight(ProductCategory category) =>
        _weights.ContainsKey(category) ? _weights[category] : 0.05;
}
