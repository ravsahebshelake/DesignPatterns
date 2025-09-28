/* Factory Method Pattern
Definition: The Factory Method pattern is a creational design pattern that defines an interface for creating an object, but allows subclasses to alter the type of objects that will be created. It is used when a class cannot anticipate the class of objects it needs to create beforehand, or when a class wants its subclasses to specify the objects it creates.

Problem Solved - You don’t want to expose object creation logic; instead, let a factory method decide which class to instantiate.

Common use cases for the Factory Method pattern include:
Document creation in applications like Microsoft Word, which can create different types of documents (e.g PDF, Word, Excel) based on user selection.
DbProviders in ADO.NET use the Factory Method pattern to create database connections, commands, and other objects specific to a database type (e.g., SQL Server, Oracle, MySQL).
Logging frameworks like log4net or NLog use the Factory Method pattern to create different types of loggers (e.g., file logger, database logger, event logger) based on configuration settings.
UI Component Libraries often use the Factory Method pattern to create different types of UI components (e.g., buttons, text boxes, dropdowns) based on the platform (e.g., Windows, macOS, Linux).*/

using System;

namespace DesignPatterns.CreationalDesignPatterns;

public abstract class Document
{
    public abstract void Print();
}

public class PdfDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing PDF Document");
    }
}

public class WordDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing Word Document");
    }
}

public abstract class DocumentFactory
{
    public abstract Document CreateDocument();
}

public class PdfDocumentFactory : DocumentFactory
{
    public override Document CreateDocument()
    {
        return new PdfDocument();
    }
}

public class WordDocumentFactory : DocumentFactory
{
    public override Document CreateDocument()
    {
        return new WordDocument();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdfDoc = pdfFactory.CreateDocument();
        pdfDoc.Print();

        DocumentFactory wordFactory = new WordDocumentFactory();
        Document wordDoc = wordFactory.CreateDocument();
        wordDoc.Print();
    }
}
