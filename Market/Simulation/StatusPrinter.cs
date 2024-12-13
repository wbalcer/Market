using Models;

namespace Simulation;

public class StatusPrinter
{
    public void PrintMarketState(MarketStorage marketStorage, double inflation, List<Salesman> salesmen)
    {
        string filePath = "ioutput.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(inflation);
        }
        filePath = "poutput.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (ProductCategory category in Enum.GetValues(typeof(ProductCategory)))
            {
                writer.Write($"{marketStorage.FindCheapestProduct(category).Price} ");
            }
            writer.WriteLine();
        }
        filePath = "moutput.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (ProductCategory category in Enum.GetValues(typeof(ProductCategory)))
            {
                writer.Write($"{marketStorage.FindCheapestProduct(category).Markup} ");
            }
            writer.WriteLine();
        }
        filePath = "soutput.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (var category in marketStorage.GetSalesRecord())
            {
                writer.Write($"{category.Value} ");
            }
            writer.WriteLine();
        }
        filePath = "Soutput.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (var salesman in salesmen)
            {
                writer.Write($"{salesman.Money} ");
            }
            writer.WriteLine();
        }
        
    }
}