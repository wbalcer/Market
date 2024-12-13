using Models;
using Simulation;
using Factories;
using Operations;

var profitCalculator = new ProfitCalculator();

var centralBank = new CentralBank();

var customerFactory = new CustomerFactory(centralBank);
var customers = customerFactory.CreateCustomers(50);

var storage = new MarketStorage(customers.Count);

var seller1 = new Salesman("Wholesaler", profitCalculator);
centralBank.Subscribe(seller1);
var seller2 = new Salesman("Everyday Specialist", profitCalculator);
centralBank.Subscribe(seller2);
var seller3 = new Salesman("Luxurious", profitCalculator);
centralBank.Subscribe(seller3);
var seller4 = new Salesman("Local", profitCalculator);
centralBank.Subscribe(seller4);
var seller5 = new Salesman("Supermarket", profitCalculator);
centralBank.Subscribe(seller5);
var seller6 = new Salesman("Optional Goods", profitCalculator);
centralBank.Subscribe(seller6);
var seller7 = new Salesman("Wholesaler Premium", profitCalculator);
centralBank.Subscribe(seller7);



var factory = new ProductFactory();
factory.AddProduct(2.0, ProductCategory.Crucial, 1.0, seller1, storage);
factory.AddProduct(5.0, ProductCategory.Essential, 3.0, seller1, storage);
factory.AddProduct(7.0, ProductCategory.Standard, 4.0, seller1, storage);
factory.AddProduct(7.0, ProductCategory.Optional, 4.0, seller1, storage);
factory.AddProduct(15.0, ProductCategory.Luxury, 8.0, seller1, storage);
factory.AddProduct(25.0, ProductCategory.SuperLuxury, 20.0, seller1, storage);
factory.AddProduct(4.0, ProductCategory.Essential, 4.0, seller2, storage);
factory.AddProduct(6.5, ProductCategory.Standard, 5.0, seller2, storage);
factory.AddProduct(13.0, ProductCategory.Luxury, 10.0, seller3, storage);
factory.AddProduct(20.0, ProductCategory.SuperLuxury, 25.0, seller3, storage);
factory.AddProduct(1.5, ProductCategory.Crucial, 1.0, seller4, storage);
factory.AddProduct(2.2, ProductCategory.Crucial, 1.0, seller5, storage);
factory.AddProduct(4.8, ProductCategory.Essential, 3.1, seller5, storage);
factory.AddProduct(7.0, ProductCategory.Standard, 4.4, seller5, storage);
factory.AddProduct(7.1, ProductCategory.Optional, 3.8, seller5, storage);
factory.AddProduct(14.5, ProductCategory.Luxury, 9.0, seller5, storage);
factory.AddProduct(25.0, ProductCategory.SuperLuxury, 23.0, seller5, storage);
factory.AddProduct(5.0, ProductCategory.Optional, 4.0, seller6, storage);
factory.AddProduct(14.0, ProductCategory.Luxury, 9.0, seller6, storage);
factory.AddProduct(21.0, ProductCategory.SuperLuxury, 17.0, seller6, storage);
factory.AddProduct(2.5, ProductCategory.Crucial, 1.5, seller7, storage);
factory.AddProduct(5.5, ProductCategory.Essential, 3.5, seller7, storage);
factory.AddProduct(7.5, ProductCategory.Standard, 4.5, seller7, storage);
factory.AddProduct(7.5, ProductCategory.Optional, 4.5, seller7, storage);
factory.AddProduct(15.5, ProductCategory.Luxury, 10.5, seller7, storage);
factory.AddProduct(22.5, ProductCategory.SuperLuxury, 20.5, seller7, storage);

;



var market = new Market(
    new List<Salesman> { seller1, seller2, seller3, seller4, seller5, seller6, seller7 },
    customers,
    centralBank,
    storage
);

for (int i = 0; i < 100; i++)
{
    market.SimulateRound();
}