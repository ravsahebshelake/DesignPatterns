/* Definition -  The Abstract Factory pattern is a creational design pattern that provides an interface for creating families of
related or dependent objects without specifying their concrete classes. It is used when the system needs to be independent of how its objects are created, composed, and represented.

Problem Solved - You need a family of related objects without knowing their concrete classes.

Common use cases for the Abstract Factory pattern include:
1. GUI Toolkits: Creating UI components (buttons, text fields, checkboxes) for  different operating systems (Windows, macOS, Linux) without specifying their concrete classes.
2. Database Connectivity: Creating database connection objects for different database systems (MySQL, PostgreSQL
, SQL Server) without specifying their concrete classes.
3. Cross-Platform Applications: Creating platform-specific objects (file system, network, graphics) for different platforms (Windows, macOS, Linux) without specifying their concrete classes.
4. Game Development: Creating different types of game objects (enemies, weapons, power-ups) for different game levels or themes without specifying their concrete classes.
5. Document Generation: Creating different types of documents (PDF, Word, Excel) for different document formats without specifying their concrete classes.*/    

using System;

namespace DesignPatterns.CreationalDesignPatterns;

public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

public interface IDocument
{
    void Print();
}

public class PdfDocument : IDocument
{
    public void Print()
    {
        Console.WriteLine("Printing PDF Document");
    }
}

public class WordDocument : IDocument
{
    public void Print()
    {
        Console.WriteLine("Printing Word Document");
    }
}

public class PdfDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

public class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        IDocument pdfDoc = pdfFactory.CreateDocument();
        pdfDoc.Print();

        DocumentFactory wordFactory = new WordDocumentFactory();
        IDocument wordDoc = wordFactory.CreateDocument();
        wordDoc.Print();
    }
}