using Models;

namespace Operations;

public class SalesLogger
{
    private readonly Dictionary<ProductCategory, int> _salesRecord = new Dictionary<ProductCategory, int>();
    private double _totalSales;

    public void LogSale(double saleAmount, ProductCategory category)
    {
        _totalSales += saleAmount;
        _salesRecord[category]++;
    }

    public double GetTotalSales() => _totalSales;

    public void ClearLog() 
    {
        _totalSales = 0;
        InitializeRecord();
    }

    public void InitializeRecord()
    {
        _salesRecord.Clear();
        foreach (ProductCategory category in Enum.GetValues(typeof(ProductCategory)))
        {
            _salesRecord.Add(category, 0);
        }

    }

    public Dictionary<ProductCategory, int> GetSalesRecord() => _salesRecord;
}
