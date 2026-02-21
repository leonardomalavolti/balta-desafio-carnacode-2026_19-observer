using DesignPatternChallenge.Interfaces;

namespace DesignPatternChallenge.Observer;

public class Investor : IObserver
{
    public string Name { get; set; }
    public decimal AlertThreshold { get; set; }

    public Investor(string name, decimal alertThreshold)
    {
        Name = name;
        AlertThreshold = alertThreshold;
    }

    public void Update(string symbol, decimal price, decimal changePercent)
    {
        Console.WriteLine($"  → [Investidor {Name}] Notificado sobre {symbol}");
        if (Math.Abs(changePercent) >= AlertThreshold)
        {
            Console.WriteLine($"  → [Investidor {Name}] ⚠️ ALERTA! Mudança de {changePercent:+0.00;-0.00}% excedeu limite de {AlertThreshold}%");
        }
    }
}
