/* Strategy Design Pattern
   The Strategy Pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. 
   This pattern lets the algorithm vary independently from clients that use it.
   
   Problem it solves: Allows changing algorithm behavior at runtime without modifying the client.
   Avoids if/else or switch statements scattered in code.
   
   .NET examples:
   IComparer<T> and Comparison<T> for sorting.
   ASP.NET Core middleware pipeline can switch behaviors.
   
   Real-world .NET examples:
   - IComparer<T> interface for custom sorting strategies in collections.
   - ASP.NET Core middleware components for request processing strategies.
   - Logging frameworks (like Serilog, NLog) allowing different logging strategies.
   - Entity Framework's query strategies using LINQ expressions.
   - Payment processing systems with different payment method strategies (e.g., credit card, PayPal).

*/

using System;
namespace DesignPatterns.BehavioralDesignPatterns;

public interface ICompressionStrategy
{
    void Compress(string filePath);
}

public class ZipCompressionStrategy : ICompressionStrategy
{
    public void Compress(string filePath)
    {
        Console.WriteLine($"Compressing {filePath} using ZIP compression.");
    }
}

public class RarCompressionStrategy : ICompressionStrategy
{
    public void Compress(string filePath)
    {
        Console.WriteLine($"Compressing {filePath} using RAR compression.");
    }
}

public class CompressionContext
{
    private ICompressionStrategy _strategy;

    public void SetStrategy(ICompressionStrategy strategy)
    {
        _strategy = strategy;
    }

    public void CreateArchive(string filePath)
    {
        _strategy.Compress(filePath);
    }
}

class Program
{
    static void Main(string[] args)
    {
        CompressionContext context = new CompressionContext();

        context.SetStrategy(new ZipCompressionStrategy());
        context.CreateArchive("file1.txt");

        context.SetStrategy(new RarCompressionStrategy());
        context.CreateArchive("file2.txt");
    }
}

#region //======================= Another Example =======================

public interface IShippingStrategy
{
    void Ship(string item);
}

public class FedExShippingStrategy : IShippingStrategy
{
    public void Ship(string item)
    {
        Console.WriteLine($"Shipping {item} via FedEx.");
    }
}
public class UPSShippingStrategy : IShippingStrategy
{
    public void Ship(string item)
    {
        Console.WriteLine($"Shipping {item} via UPS.");
    }
}

public class ShippingContext
{
    private IShippingStrategy _strategy;

    public void SetStrategy(IShippingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ShipItem(string item)
    {
        _strategy.Ship(item);
    }
}

class ShippingProgram
{
    static void Main(string[] args)
    {
        ShippingContext context = new ShippingContext();

        context.SetStrategy(new FedExShippingStrategy());
        context.ShipItem("Laptop");

        context.SetStrategy(new UPSShippingStrategy());
        context.ShipItem("Phone");
    }
}

#endregion


#region //======================= Another Example =======================

public interface IMessagingStrategy
{
    void SendMessage(string message);
}

public class EmailMessage : IMessagingStrategy
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class SMSMessage : IMessagingStrategy
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class MessageContext
{
    private IMessagingStrategy _messageStrategy;

    public void SetMessageStrategy(IMessagingStrategy messageStrategy)
    {
        _messageStrategy = messageStrategy;
    }

    public void SendMessage(string message)
    {
        _messageStrategy.SendMessage(message);
    }
}

class MessageProgram
{
    static void Main(string[] args)
    {
        MessageContext context = new MessageContext();

        context.SetMessageStrategy(new EmailMessage());
        context.SendMessage("Hello via Email!");

        context.SetMessageStrategy(new SMSMessage());
        context.SendMessage("Hello via SMS!");
    }
}
#endregion


#region //======================= Another Example =======================

public interface IPaymentProcessingStrategy
{
    void ProcessPayment(decimal amount);
}

public class PayPalPaymentProcessor : IPaymentProcessingStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} via PayPal.");
    }
}

public class StripePaymentProcessor : IPaymentProcessingStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} via Stripe.");
    }
}

public class PaymentContext
{
    private IPaymentProcessingStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentProcessingStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(decimal amount)
    {
        _paymentStrategy.ProcessPayment(amount);
    }
}

class PaymentProgram
{
    static void Main(string[] args)
    {
        PaymentContext context = new PaymentContext();

        context.SetPaymentStrategy(new PayPalPaymentProcessor());
        context.ProcessPayment(100.00m);

        context.SetPaymentStrategy(new StripePaymentProcessor());
        context.ProcessPayment(200.00m);
    }
}

#endregion