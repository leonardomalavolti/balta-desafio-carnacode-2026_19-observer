using DesignPatternChallenge.Interfaces;

namespace DesignPatternChallenge.Models;

public class Stock
{
    public string Symbol { get; private set; }
    public decimal Price { get; private set; }
    public DateTime LastUpdate { get; private set; }

    private readonly List<IObserver> _observers;

    public Stock(string symbol, decimal initialPrice)
    {
        Symbol = symbol;
        Price = initialPrice;
        LastUpdate = DateTime.Now;
        _observers = new List<IObserver>();
    }

    public void Attach(IObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        if (_observers.Contains(observer))
            _observers.Remove(observer);
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (Price != newPrice)
        {
            decimal oldPrice = Price;
            Price = newPrice;
            LastUpdate = DateTime.Now;

            decimal changePercent = ((newPrice - oldPrice) / oldPrice) * 100;

            Console.WriteLine($"\n[{Symbol}] Preço atualizado: R$ {oldPrice:N2} → R$ {newPrice:N2} ({changePercent:+0.00;-0.00}%)");

            // Notifica todos os observadores dinamicamente
            foreach (var observer in _observers)
            {
                observer.Update(Symbol, newPrice, changePercent);
            }
        }
    }
}