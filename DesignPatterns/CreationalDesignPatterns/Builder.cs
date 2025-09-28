/* Definition - The Builder pattern is a creational design pattern that allows constructing complex objects step by step. It separates the construction of a complex object from its representation, allowing the same construction process to create different representations. It is used when the construction process of an object is complex and needs to be separated from its representation.

Problem Solved - You want to construct a complex object step by step and the construction process must allow different representations for the object that is constructed.
Common use cases for the Builder pattern include:
1. Complex Object Creation: When creating complex objects with many optional parameters, the Builder pattern can help simplify the construction process and improve code readability.
2. Fluent Interfaces: The Builder pattern is often used to create fluent interfaces, allowing method chaining for setting properties of an object in a readable manner.
3. Immutable Objects: The Builder pattern can be used to create immutable objects, where the object's state cannot be changed after it is constructed.  The Builder pattern allows setting properties during construction, resulting in an immutable object.
4. Configuration Objects: The Builder pattern is useful for creating configuration objects that require multiple settings to be specified before use.
5. Object Pooling: The Builder pattern can be used in conjunction with object pooling to create objects that are expensive to create, allowing for efficient reuse of existing objects.*/

// string builder 
// webhost builder
// configuration builder
// entity framework dbcontext options builder

using System;
namespace DesignPatterns.CreationalDesignPatterns;

public class Report{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Footer { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}\nContent: {Content}\nFooter: {Footer}";
    }
}

public class ReportBuilder
{
    private readonly Report _report;

    public ReportBuilder()
    {
        _report = new Report();
    }

    public ReportBuilder SetTitle(string title)
    {
        _report.Title = title;
        return this;
    }

    public ReportBuilder SetContent(string content)
    {
        _report.Content = content;
        return this;
    }

    public ReportBuilder SetFooter(string footer)
    {
        _report.Footer = footer;
        return this;
    }

    public Report Build()
    {
        return _report;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ReportBuilder builder = new ReportBuilder();
        Report report = builder.SetTitle("Annual Report")
                               .SetContent("This is the content of the annual report.")
                               .SetFooter("Confidential")
                               .Build();

        Console.WriteLine(report);
    }
}