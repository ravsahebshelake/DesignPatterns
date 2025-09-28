/* Decorator Design Pattern

Definition: 
Adds new behavior to an object dynamically, without modifying its class.

Problem it solves: 
Avoids creating subclasses for every possible combination of features. Enables adding features on the fly.

Real-time use cases: 
Adding logging, caching, or retry logic around service calls.
Adding compression/encryption around streams.

.NET examples:
Stream classes (BufferedStream, GZipStream, CryptoStream) decorate Stream.
StringReader, StringWriter decorate TextReader and TextWriter.
*/

using System;

public interface IMessage
{
    string GetContent();
}

public class SimpleMessage : IMessage
{
    private readonly string _content;

    public SimpleMessage(string content)
    {
        _content = content;
    }

    public string GetContent()
    {
        return _content;
    }
}

public abstract class MessageDecorator : IMessage
{
    protected readonly IMessage _message;

    protected MessageDecorator(IMessage message)
    {
        _message = message;
    }

    public abstract string GetContent();
}

public class EncryptedMessage : MessageDecorator
{
    public EncryptedMessage(IMessage message) : base(message) { }

    public override string GetContent()
    {
        // Simple "encryption" for demonstration
        char[] content = _message.GetContent().ToCharArray();
        Array.Reverse(content);
        return new string(content);
    }
}

public class CompressedMessage : MessageDecorator
{
    public CompressedMessage(IMessage message) : base(message) { }

    public override string GetContent()
    {
        // Simple "compression" for demonstration
        return _message.GetContent().Replace(" ", "");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IMessage message = new SimpleMessage("Hello World");
        Console.WriteLine("Original Message: " + message.GetContent());

        IMessage encryptedMessage = new EncryptedMessage(message);
        Console.WriteLine("Encrypted Message: " + encryptedMessage.GetContent());

        IMessage compressedMessage = new CompressedMessage(encryptedMessage);
        Console.WriteLine("Compressed & Encrypted Message: " + compressedMessage.GetContent());
    }
}

  