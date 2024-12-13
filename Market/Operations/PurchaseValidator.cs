using Models;

namespace Operations;

public class PurchaseValidator
{
    private readonly MarketStorage marketStorage;

    public PurchaseValidator(MarketStorage marketStorage)
    {
        this.marketStorage = marketStorage;
    }

    public void ValidatePurchase(Product product, Customer customer)
    {
        customer.Money -= product.Price;
        customer.Needs[product.Category] = 0;
        product.Salesman.AddProfit(product.Category, product.Markup);   
        marketStorage.LogSale(product.Price, product.Category); 
    }
}