namespace Models;
using Operations;

public class MarketStorage
{
    private readonly ProductStorage _productStorage;
    private readonly SalesLogger _salesLogger;
    private readonly ExpectedSalesCalculator _expectedSalesCalculator;

    public int CustomerCount { get; set; }

    public MarketStorage(int customerCount)
    {
        CustomerCount = customerCount;
        _productStorage = new ProductStorage();
        _salesLogger = new SalesLogger();
        _expectedSalesCalculator = new ExpectedSalesCalculator();
    }

    public IReadOnlyList<Product> Products => _productStorage.Products;

    public void AddProduct(Product product) => _productStorage.AddProduct(product);

    public List<Product> GetProductsByCategory(ProductCategory category) =>
        _productStorage.GetProductsByCategory(category);

    public void LogSale(double price, ProductCategory category)
    {
        _salesLogger.LogSale(price, category);
    }

    public double GetTotalSales() => _salesLogger.GetTotalSales();

    public void ClearSalesLog() => _salesLogger.ClearLog();

    public Dictionary<ProductCategory, int> GetSalesRecord() => _salesLogger.GetSalesRecord();

    public double GetExpectedSales() =>
        _expectedSalesCalculator.CalculateExpectedSales(_productStorage.Products, CustomerCount);

    public Product FindCheapestProduct(ProductCategory category) =>
        _productStorage.FindCheapestProduct(category);
}
