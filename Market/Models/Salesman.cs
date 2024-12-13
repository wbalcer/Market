namespace Models;

using Models.Interfaces;
using Operations;

public class Salesman : IVisitable, IObserver<double>
{
    private readonly ProfitCalculator profitCalculator;
    public List<Product> Products { get; } = new();
    public double Money { get; private set; }
    public string Name { get; }

    public Salesman(string name, ProfitCalculator profitCalculator)
    {
        Name = name;
        this.profitCalculator = profitCalculator;
    }

    public void OnCompleted() { }
    public void OnError(Exception error) { }
    public void OnNext(double inflation) => Update(inflation);

    private void Update(double inflation)
    {
        foreach (var product in Products)
        {
            product.UpdatePrice(inflation);
        }
    }

    public void AddProfit(ProductCategory category, double profit)
    {
        Money = Math.Round(Money + profit, 2, MidpointRounding.AwayFromZero);
        profitCalculator.AddProfit(category, profit);
    }

    public void ResetProfit() => profitCalculator.ResetProfit();

    public double GetProfit(ProductCategory category) =>
        profitCalculator.GetProfit(category);

    public double GetExpectedProfit(int customerCount, ProductCategory category) =>
        profitCalculator.CalculateExpectedProfit(customerCount, Products, category);

    public void Accept(IVisitor visitor) => visitor.Visit(this);
}