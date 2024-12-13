namespace Models;

public class Product
{
    public double StartingPrice { get; }
    public double Price { get; set; }
    public double ProductionCost { get; set; }
    public ProductCategory Category { get; set; }
    public double Markup { get; set; }
    public Salesman Salesman { get; }

    public Product(double productionCost, ProductCategory category, double markup, Salesman salesman)
    {
        Category = category;
        StartingPrice = markup + productionCost;
        Price = StartingPrice;
        ProductionCost = productionCost;
        Markup = markup;
        Salesman = salesman;
    }

    public void UpdatePrice(double inflation)
    {
        Price = (1 + inflation) * (Markup + ProductionCost);
        Price = Math.Round(Price, 2, MidpointRounding.AwayFromZero);
    }
}