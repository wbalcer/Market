namespace Models;

using Operations;

public class CentralBank : IObservable<double>
{
    private readonly List<IObserver<double>> observers = new();
    private readonly InflationCalculator inflationCalculator;

    public double Inflation { get; private set; }

    public CentralBank()
    {
        this.inflationCalculator = new InflationCalculator();
    }

    public IDisposable Subscribe(IObserver<double> observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
        return new UnSubscriber(observers, observer);
    }

    public void UpdateInflation(double totalSales, double expectedSales)
    {
        Inflation = inflationCalculator.CalculateInflation(totalSales, expectedSales, Inflation);
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnNext(Inflation);
        }
    }

    private class UnSubscriber : IDisposable
    {
        private readonly List<IObserver<double>> _observers;
        private readonly IObserver<double> _observer;

        public UnSubscriber(List<IObserver<double>> observers, IObserver<double> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
