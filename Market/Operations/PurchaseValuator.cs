    namespace Operations;
    using Models;

    public class PurchaseValuator
    {
        private readonly MarketStorage marketStorage;
        public PurchaseValuator(MarketStorage marketStorage)
        {
            this.marketStorage = marketStorage;
        }
        public void ValuatePurchase(ProductCategory productCategory, double willingness, Customer customer)
        {
            var product = marketStorage.FindCheapestProduct(productCategory);
            if (customer.Money >= product.Price)
            {
                var random = new Random();
                double odds = random.NextDouble();
                if (odds <= willingness)
                {
                    var validator = new PurchaseValidator(marketStorage);
                    validator.ValidatePurchase(product, customer);
                }
            }
        }
    }