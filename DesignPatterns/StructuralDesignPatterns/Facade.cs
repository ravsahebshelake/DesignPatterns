/* Facade Design Pattern

Definition: 
Provides a simplified interface to a complex subsystem.

Problem it solves: 
Reduces the complexity of interacting with a system by providing a higher-level interface.

Real-time use cases:
Simplifying interactions with complex libraries or frameworks.
Providing a unified API for a set of related classes.

.NET examples:
The `System.IO` namespace provides a simplified interface for file operations.
The `Entity Framework` provides a simplified interface for database operations.
The `ASP.NET Core` framework provides a simplified interface for building web applications.

*/

using System;
namespace DesignPatterns.StructuralDesignPatterns;

Public class PaymentGateway
{
    public void Pay(double amount) => Console.WriteLine($"Processing payment of {amount}");
}

public class NotificationService
{
    public void Notify(string message) => Console.WriteLine($"Sending notification: {message}");
}

public class InventoryService
{
    public void UpdateStock(int productId, int quantity) => Console.WriteLine($"Updating stock for product {productId} by {quantity}");
}

public class OrderFacade
{
    private readonly PaymentGateway _paymentGateway;
    private readonly NotificationService _notificationService;
    private readonly InventoryService _inventoryService;

    public OrderFacade()
    {
        _paymentGateway = new PaymentGateway();
        _notificationService = new NotificationService();
        _inventoryService = new InventoryService();
    }

    public void PlaceOrder(double amount, int productId, int quantity = 1)
    {
        _inventoryService.UpdateStock(productId, -quantity);        
        _paymentGateway.Pay(amount);
        _notificationService.Notify("Order placed successfully.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        OrderFacade orderFacade = new OrderFacade();
        orderFacade.PlaceOrder(99.99);
    }
}