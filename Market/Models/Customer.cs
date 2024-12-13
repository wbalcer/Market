namespace Models;

using System.Text.RegularExpressions;
using Models.Interfaces;
using Operations;

public class Customer : IObserver<double>
{
    public Dictionary<ProductCategory, double> Needs { get; set; } = new ();
    public double Money { get; set; }
    public string Name { get; set; }
    public double Wage {get; set; }

    public Customer(string name, double wage)
    {
        Name = name;
        Wage = wage;
    }
    public void OnCompleted() {}
    public void OnError(Exception error) {}
    public void OnNext(double inflation) => Update(inflation);

    public void Update(double inflation)
    {
        Money += Wage * (inflation + 1);
        Money = Math.Round(Money, 2, MidpointRounding.AwayFromZero);
    }
    public List<KeyValuePair<ProductCategory, double>> GetNeeds()
    {
        return Needs.OrderByDescending(x => x.Value).ToList();
    }
}
