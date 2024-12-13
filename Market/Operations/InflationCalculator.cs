using Models;

namespace Operations;

public class InflationCalculator
{
    public double CalculateInflation(double totalSales, double expectedSales, double inflation)
    {
        if (totalSales == 0)
        {
            return inflation * 2;
        }
        return inflation + (expectedSales / totalSales) - 1;
    }
}