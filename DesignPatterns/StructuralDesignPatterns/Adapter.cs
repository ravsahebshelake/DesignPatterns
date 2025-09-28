/* Adapter Design Pattern
Definition: Adapter Pattern is a structural design pattern that converts the interface of a class into another interface clients expect.

Problem it solves: 
Makes incompatible interfaces work together without modifying existing code.

Real-time use cases:
Using old legacy code with a new system.
Making a third-party library fit into your project.

.NET examples: 
StreamReader adapts a Stream into a text reader.
XmlReader adapts different XML sources (string, file, stream).
StreamReader / StreamWriter wrap Stream (adapting byte streams to text).
IDataAdapter in ADO.NET (adapts data between DataSet and database).
MemoryStream vs. NetworkStream adapters for working with different sources.
*/

using System;
namespace DesignPatterns.StructuralDesignPatterns;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public class PayPalLegacyPaymentService
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} using PayPal.");
    }
}

public class PayPalAdapter : IPaymentProcessor
{
    private readonly PayPalLegacyPaymentService _payPalLegacyPaymentService;

    public PayPalAdapter(PayPalLegacyPaymentService payPalLegacyPaymentService)
    {
        _payPalLegacyPaymentService = payPalLegacyPaymentService;
    }

    public void ProcessPayment(decimal amount)
    {
        _payPalLegacyPaymentService.MakePayment(amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IPaymentProcessor paymentProcessor = new PayPalAdapter(new PayPalLegacyPaymentService());
        paymentProcessor.ProcessPayment(100.00m);
    }
}
