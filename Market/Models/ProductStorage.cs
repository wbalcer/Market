#pragma warning disable CS8603
namespace Models;

public class ProductStorage
{
    private readonly List<Product> _products = new();

    public IReadOnlyList<Product> Products => _products;

    public void AddProduct(Product product) => _products.Add(product);

    public List<Product> GetProductsByCategory(ProductCategory category) =>
        _products.Where(p => p.Category == category).ToList();

    public Product FindCheapestProduct(ProductCategory category) =>
        GetProductsByCategory(category).OrderBy(p => p.Price).FirstOrDefault();
}
