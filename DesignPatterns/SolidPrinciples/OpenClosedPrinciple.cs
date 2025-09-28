/* Open Closed Principle (OCP)
    * Software entities (classes, modules, functions, etc.) should be open for extension but closed for modification.
    * This means that the behavior of a module can be extended without modifying its source code.
    * 
    * Adhering to the Open Closed Principle can lead to a more maintainable and scalable codebase.
    * New functionality can be added with minimal risk of introducing bugs into existing code.
    * It encourages the use of interfaces and abstract classes to define contracts that can be implemented by new classes.
    * This principle is often achieved through polymorphism and composition.
    
    * When designing systems, consider how new features might be added in the future and structure your code to accommodate those changes without altering existing functionality.
    * This can lead to a more modular and flexible codebase.
*/

using System;
namespace DesignPatterns.SolidPrinciples;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public class CreditCardPayment : IPaymentProcessor  
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount:C}");
    }
}

public class PayPalPayment : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount:C}");
    }
}

public class PaymentProcessor
{
    private readonly IPaymentProcessor _paymentProcessor;

    public PaymentProcessor(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor ?? throw new ArgumentNullException(nameof(paymentProcessor));
    }

    public void Process(decimal amount)
    {
        _paymentProcessor.ProcessPayment(amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IPaymentProcessor creditCardPayment = new CreditCardPayment();
        PaymentProcessor paymentProcessor1 = new PaymentProcessor(creditCardPayment);
        paymentProcessor1.Process(100.00m);

        IPaymentProcessor payPalPayment = new PayPalPayment();
        PaymentProcessor paymentProcessor2 = new PaymentProcessor(payPalPayment);
        paymentProcessor2.Process(200.00m);
    }
}

//======================= Another Example =======================

// using abstract class

public abstract class ImageService
{
    public abstract void DisplayImage(string imagePath);
}

public class JpegImageService : ImageService
{
    public override void DisplayImage(string imagePath)
    {
        Console.WriteLine($"Displaying JPEG image from {imagePath}");
    }
}

public class PngImageService : ImageService
{
    public override void DisplayImage(string imagePath)
    {
        Console.WriteLine($"Displaying PNG image from {imagePath}");
    }
}
public class ImageViewer
{
    private readonly ImageService _imageService;

    public ImageViewer(ImageService imageService)
    {
        _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
    }

    public void ShowImage(string imagePath)
    {
        _imageService.DisplayImage(imagePath);
    }
}

class ImageProgram
{
    static void Main(string[] args)
    {
        ImageService jpegService = new JpegImageService();
        ImageViewer viewer1 = new ImageViewer(jpegService);
        viewer1.ShowImage("photo.jpeg");

        ImageService pngService = new PngImageService();
        ImageViewer viewer2 = new ImageViewer(pngService);
        viewer2.ShowImage("graphic.png");
    }
}