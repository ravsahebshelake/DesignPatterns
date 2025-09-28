/* Single Responsibility Principle
    * A class should have only one reason to change, meaning it should have only one job or responsibility.
    * This principle helps in making the code more maintainable, understandable, and testable.
    * It encourages separation of concerns, where each class or module focuses on a specific functionality.
    * This leads to a cleaner architecture and reduces the impact of changes in one part of the system on others.
    * It also facilitates easier debugging and testing since each class has a well-defined purpose.
    * Adhering to the Single Responsibility Principle can lead to a more modular and flexible codebase.
*/

using System;
using System.Globalization;
namespace DesignPatterns.SolidPrinciples;

public interface IInvoiceRepository
{
    void Save(Invoice invoice);
    Invoice GetById(int id);
}

public interface IInvoicePrinter
{
    void PrintInvoice(Invoice invoice);
}

public interface INotificationService
{
    void SendInvoiceProcessedNotification(Invoice invoice);
}

public class Invoice
{
    private readonly int _id;
    private readonly decimal _amount;
    private readonly DateTime _date;

    public int Id => _id;
    public decimal Amount => _amount;
    public DateTime Date => _date;

    public Invoice(int id, decimal amount, DateTime? date = null)
    {
        _id = id;
        _amount = amount;
        _date = date ?? DateTime.Now;
    }

    public override string ToString()
    {
        return $"Invoice #{Id}: {Amount:C} on {Date:yyyy-MM-dd}";
    }
}

public class InvoiceRepository : IInvoiceRepository
{
    public void Save(Invoice invoice)
    {
        Console.WriteLine($"Saving invoice {invoice.Id} to database...");
        Console.WriteLine($"Invoice {invoice.Id} saved successfully");
    }

    public Invoice GetById(int id)
    {
        Console.WriteLine($"Retrieving invoice {id} from database...");
        return new Invoice(id, 100.50m, DateTime.Now.AddDays(-1));
    }
}

public class InvoiceProcessor
{
    private readonly IInvoiceRepository _repository;
    private readonly INotificationService _notificationService;

    public InvoiceProcessor(
        IInvoiceRepository repository, 
        INotificationService notificationService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository))
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
    }

    public bool ProcessInvoice(Invoice invoice)
    {
        _repository.Save(invoice);
        _notificationService.SendInvoiceProcessedNotification(invoice);
    }
}

public class ConsoleInvoicePrinter : IInvoicePrinter
{
    public string FormatInvoice(Invoice invoice)
    {
        return $"""
            ================================
            INVOICE DETAILS
            ================================
            Invoice ID:     {invoice.Id}
            Amount:         {invoice.Amount.ToString("C", CultureInfo.CurrentCulture)}
            Date:           {invoice.Date.ToString("F", CultureInfo.CurrentCulture)}
            ================================
            """;
    }

    public void PrintInvoice(Invoice invoice)
    {
        Console.WriteLine(FormatInvoice(invoice));
    }
}

public class ConsoleNotificationService : INotificationService
{
    public void SendInvoiceProcessedNotification(Invoice invoice)
    {
        if (invoice == null)
        {
            Console.WriteLine("Cannot send notification: Invoice is null");
            return;
        }

        var message = $"Invoice #{invoice.Id} for {invoice.Amount:C} has been processed successfully on {invoice.Date:yyyy-MM-dd HH:mm:ss}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        IInvoiceRepository repository = new InvoiceRepository();
        INotificationService notificationService = new ConsoleNotificationService();
        IInvoicePrinter printer = new ConsoleInvoicePrinter();

        var processor = new InvoiceProcessor(repository, notificationService);
        var validInvoice = new Invoice(1, 150.75m);
        printer.PrintInvoice(validInvoice);
        bool success = processor.ProcessInvoice(validInvoice);
        notificationService.SendInvoiceProcessedNotification(validInvoice);
    }
}