/* Interface Segregation Principle (ISP)
Definition: Clients should not be forced to depend on interfaces they do not use. This principle encourages the creation of smaller, more specific interfaces rather than a large, general-purpose interface.

Problem it solves:
Reduces the impact of changes in interfaces, as clients are only affected by the interfaces they actually use.
Improves code maintainability and readability by keeping interfaces focused and relevant.

Real-time use cases:
Different types of users (e.g., Admin, Guest) requiring different sets of functionalities.
Devices with varying capabilities (e.g., Printer with color and black-and-white modes).

.NET examples:
- IEnumerable<T> and ICollection<T> interfaces in collections.
- Different interfaces for different types of streams (e.g., Stream, FileStream, MemoryStream).
- ASP.NET Core's IActionResult interface with specific result types (e.g., JsonResult, ViewResult).
- IRepository<T> often split into IReadRepository<T> and IWriteRepository<T>.
- ASP.NET Core authentication separates IAuthenticationService, IAuthorizationService.

Benefits:
- Enhances flexibility and adaptability of the codebase.
- Reduces the likelihood of breaking changes when interfaces evolve.
- Promotes better separation of concerns and single responsibility for interfaces.

Other examples:
- Segregating user roles in an application (e.g., Admin vs. Regular User interfaces
*/

using System;
namespace DesignPatterns.SolidPrinciples;
public interface IPrinter
{
    void Print(string content);
}
public interface IScanner
{
    void Scan(string content);
}
public interface IFax
{
    void Fax(string content);
}
public class MultiFunctionPrinter : IPrinter, IScanner, IFax
{
    public void Print(string content)
    {
        Console.WriteLine($"Printing: {content}");
    }

    public void Scan(string content)
    {
        Console.WriteLine($"Scanning: {content}");
    }

    public void Fax(string content)
    {
        Console.WriteLine($"Faxing: {content}");
    }
}

public class SimplePrinter : IPrinter
{
    public void Print(string content)
    {
        Console.WriteLine($"Printing: {content}");
    }
}

public static void Main()
{
    IPrinter printer = new SimplePrinter();
    printer.Print("Hello, World!");

    MultiFunctionPrinter mfp = new MultiFunctionPrinter();
    mfp.Print("Document");
    mfp.Scan("Photo");
    mfp.Fax("Contract");
}