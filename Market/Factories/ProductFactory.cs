namespace Factories;

using System.Data.SqlTypes;
using Models;

public class ProductFactory
{
    public Product CreateProduct(double productionCost, ProductCategory category, double markup, Salesman salesman)
    {
        return new Product(productionCost, category, markup, salesman);
    }

    public void AddProduct(double productionCost, ProductCategory category, double markup, Salesman salesman, MarketStorage storage)
    {
        var product = CreateProduct(productionCost, category, markup, salesman);
        salesman.Products.Add(product);
        storage.AddProduct(product);
    }
}
