using Models;
using Operations;
using Factories;

namespace Simulation;

public class Market
{
    private readonly List<Salesman> salesmen;
    private readonly List<Customer> customers;
    private readonly CentralBank centralBank;
    private readonly ProductFactory productFactory;
    private readonly PurchaseValuator purchaseValuator;
    private readonly StatusPrinter statusPrinter;
    private readonly MarketStorage marketStorage;
    private readonly NeedsEvaluator needsEvaluator;
    private readonly MarkupAnalyser markupAnalyser;
    private double expectedSales = 0;

    public Market(List<Salesman> salesmen, List<Customer> customers, CentralBank centralBank, MarketStorage marketStorage)
    {
        this.salesmen = salesmen;
        this.customers = customers;
        this.centralBank = centralBank;
        this.productFactory = new ProductFactory();
        this.purchaseValuator = new PurchaseValuator(marketStorage);
        this.statusPrinter = new StatusPrinter();
        this.marketStorage = marketStorage;
        this.needsEvaluator = new NeedsEvaluator(marketStorage);
        this.markupAnalyser = new MarkupAnalyser(customers.Count);
        expectedSales = marketStorage.GetExpectedSales();
    }

    public void SimulateRound()
    {
        //CentralBank
        UpdateInflation(marketStorage.GetTotalSales(), expectedSales);
        marketStorage.ClearSalesLog();



        //Customer
        foreach (var customer in customers)
        {
            needsEvaluator.EvaluateNeeds(customer);
            foreach (var product in customer.GetNeeds())
            {
                purchaseValuator.ValuatePurchase(product.Key, product.Value, customer);
            }
        }

        //Salesman
        foreach (var salesman in salesmen)
        {
            markupAnalyser.Visit(salesman);
            salesman.ResetProfit();
        }
        statusPrinter.PrintMarketState(marketStorage, centralBank.Inflation, salesmen);

    }
    public double GetInflation()
    {
        return centralBank.Inflation;
    }
    public void UpdateInflation(double totalSales, double expectedSales)
    {
        centralBank.UpdateInflation(totalSales, expectedSales);
    }
}