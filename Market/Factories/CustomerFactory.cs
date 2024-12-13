using Models;
using System;
using System.Collections.Generic;

namespace Factories;

public class CustomerFactory
{
    private CentralBank _centralBank;
    private Random _random;

    public CustomerFactory(CentralBank centralBank)
    {
        _centralBank = centralBank;
        _random = new Random();
    }

    public List<Customer> CreateCustomers(int count)
    {
        var customers = new List<Customer>();

        for (int i = 0; i < count; i++)
        {
            string name = $"Customer{i + 1}";

            double wage = _random.NextDouble() * 3 + 8;

            var customer = new Customer(name, wage);

            customer.Needs[ProductCategory.Crucial] = Math.Round(_random.NextDouble() + 0.1, 2);
            customer.Needs[ProductCategory.Essential] = Math.Round(_random.NextDouble() + 0.05, 2);
            customer.Needs[ProductCategory.Standard] = Math.Round(_random.NextDouble() * 0.9, 2);
            customer.Needs[ProductCategory.Optional] = Math.Round(_random.NextDouble() - 0.2, 2);
            customer.Needs[ProductCategory.Luxury] = Math.Round(_random.NextDouble() * 0.2, 2);
            customer.Needs[ProductCategory.SuperLuxury] = Math.Round(_random.NextDouble() * 0.3, 2);
            _centralBank.Subscribe(customer);
            customers.Add(customer);
        }

        return customers;
    }
}
