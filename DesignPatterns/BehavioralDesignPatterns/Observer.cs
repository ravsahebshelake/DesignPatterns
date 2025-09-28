/* Observer Design Pattern
    Definition: 
    Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.
    
    Problem it solves: 
    Decouples the subject (the object being observed) from its observers, allowing for dynamic relationships and reducing tight coupling.
    Keeps multiple objects in sync without tight coupling. Useful for event-driven systems.

    Real-time use cases:
    Event handling systems (e.g., UI frameworks).
    Implementing publish-subscribe systems.
    Data binding in MVVM architectures.
    
    .NET examples:
    The `IObservable<T>` and `IObserver<T>` interfaces in Reactive Extensions (Rx).
    The `EventHandler` delegate and event keyword in C#.
    The `INotifyPropertyChanged` interface for data binding in WPF and Xamarin.
    
    Other examples:
    Implementing custom event systems.
    Building notification systems where multiple components need to react to changes.
*/

using System;
using System.Collections.Generic;
namespace DesignPatterns.BehavioralDesignPatterns;

public interface IInverstorObeserver
{
    void Update(string stockName, double price);
}

public class Stock
{
    private readonly List<IInverstorObeserver> _observers = new List<IInverstorObeserver>();
    private double _price;
    public string Name { get; }

    public Stock(string name, double price)
    {
        Name = name;
        _price = price;
    }

    public void Attach(IInverstorObeserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IInverstorObeserver observer)
    {
        _observers.Remove(observer);
    }

    public void SetPrice(double price)
    {
        if (_price != price)
        {
            _price = price;
            Notify();
        }
    }

    private void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(Name, _price);
        }
    }
}

public class Investor : IInverstorObeserver
{
    public string Name { get; }

    public Investor(string name)
    {
        Name = name;
    }

    public void Update(string stockName, double price)
    {
        Console.WriteLine($"Notified {Name} of {stockName}'s price change to {price}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Stock appleStock = new Stock("AAPL", 150.00);
        Investor investor1 = new Investor("John");
        Investor investor2 = new Investor("Jane");

        appleStock.Attach(investor1);
        appleStock.Attach(investor2);

        appleStock.SetPrice(155.00);
        appleStock.SetPrice(160.00);

        appleStock.Detach(investor1);

        appleStock.SetPrice(165.00);
    }
}
