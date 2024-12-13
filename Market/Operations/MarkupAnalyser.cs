using Models;
using Models.Interfaces;

namespace Operations;

public class MarkupAnalyser : IVisitor
{
    public int CustomerCount { get; set; }
    public MarkupAnalyser(int customerCount)
    {
        CustomerCount = customerCount;
    }
    public void Visit(Salesman salesman)
    {
        foreach (var product in salesman.Products)
        {
            double expectedProfit = salesman.GetExpectedProfit(CustomerCount, product.Category);
            double currentProfit = salesman.GetProfit(product.Category);
            
            double weight = WeightProvider.GetWeight(product.Category);
            
            if (currentProfit != 0 && expectedProfit > 0)
            {
                double markupAdjustment = (currentProfit / expectedProfit - 1) * weight;
                double newMarkup = product.Markup + markupAdjustment;
                
                product.Markup = Math.Round(newMarkup, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                double reducedMarkup = product.Markup * (1 - (0.01 * weight));
                
                double dynamicLowerBound = Math.Max(0.1, 0.1 + (0.02 * weight));
                
                product.Markup = Math.Max(reducedMarkup, dynamicLowerBound);
            }

            if (product.Markup < 0.1)
            {
                product.Markup = 0.1;
            }
        }

    }
}