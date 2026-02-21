namespace DesignPatternChallenge.Interfaces;

public interface IObserver
{
    void Update(string symbol, decimal price, decimal changePercent);
}
