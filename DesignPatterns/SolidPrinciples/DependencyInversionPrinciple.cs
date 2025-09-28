/* Dependency Inversion Principle (DIP)
Definition: High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

Problem it solves:
Reduces the coupling between high-level and low-level components, making the system more flexible and easier to maintain.

Real-time use cases:
Decoupling business logic from data access layers.
Enabling easier testing by allowing the use of mock implementations.

.NET examples:
Using interfaces or abstract classes to define contracts between components.
Dependency Injection frameworks like Microsoft.Extensions.DependencyInjection, Autofac, Ninject.
IConfiguration, ILogger<T>, IOptions<T>.

Benefits:
Improved maintainability: Changes in low-level modules do not affect high-level modules.
Enhanced testability: High-level modules can be tested in isolation using mock implementations of abstractions.
Increased flexibility: Easier to swap out implementations without affecting dependent code.

Other examples:
Using repository patterns to abstract data access.
*/


using System;
namespace DesignPatterns.SolidPrinciples;

public interface IMessageService
{
    void SendMessage(string message, string recipient);
}

public class EmailService : IMessageService
{
    public void SendMessage(string message, string recipient)
    {
        Console.WriteLine($"Email sent to {recipient} with message: {message}");
    }
}

public class SMSService : IMessageService
{
    public void SendMessage(string message, string recipient)
    {
        Console.WriteLine($"SMS sent to {recipient} with message: {message}");
    }
}

public class Notification
{
    private readonly IMessageService _messageService;

    public Notification(IMessageService messageService)
    {
        _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
    }

    public void Notify(string message, string recipient)
    {
        _messageService.SendMessage(message, recipient);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IMessageService emailService = new EmailService();
        Notification emailNotification = new Notification(emailService);
        emailNotification.Notify("Hello via Email!", "user@example.com");

        IMessageService smsService = new SMSService();
        Notification smsNotification = new Notification(smsService);
        smsNotification.Notify("Hello via SMS!", "123-456-7890");
    }
}