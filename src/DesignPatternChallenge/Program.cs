using DesignPatternChallenge.Models;
using DesignPatternChallenge.Observer;

Console.WriteLine("=== Sistema de Monitoramento de Ações (Observer) ===");

var petr4 = new Stock("PETR4", 35.50m);

var investor1 = new Investor("João Silva", 3.0m);
var investor2 = new Investor("Maria Santos", 5.0m);
var mobileApp = new MobileApp("user123");
var tradingBot = new TradingBot("AlgoTrader", 2.0m, 2.5m);

// Registrando observadores
petr4.Attach(investor1);
petr4.Attach(investor2);
petr4.Attach(mobileApp);
petr4.Attach(tradingBot);

// Simulando mudanças de preço
Console.WriteLine("\n=== Movimentações do Mercado ===");
petr4.UpdatePrice(36.20m); // +1.97%
Thread.Sleep(500);

petr4.UpdatePrice(37.50m); // +3.59%
Thread.Sleep(500);

petr4.UpdatePrice(35.00m); // -6.67%
Thread.Sleep(500);

// Removendo observador dinamicamente
Console.WriteLine("\n=== Removendo um investidor do alerta ===");
petr4.Detach(investor2);

petr4.UpdatePrice(34.00m); // -2.86%