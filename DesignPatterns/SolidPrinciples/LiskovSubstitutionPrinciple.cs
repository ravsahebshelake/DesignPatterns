/* Liskov Substitution Principle (LSP)
    
    * The Liskov Substitution Principle states that objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.
    * In other words, if class S is a subtype of class T, then objects of type T should be replaceable with objects of type S without altering any of the desirable properties of the program (e.g., correctness).
    * This principle ensures that a subclass can stand in for its superclass without causing unexpected behavior.
    
    * Adhering to the Liskov Substitution Principle can lead to more robust and maintainable code.
    * It encourages the design of class hierarchies that are logical and consistent.
    * Violations of LSP often indicate that a subclass is not truly a subtype of its superclass, which can lead to runtime errors and unexpected behavior.
    
    * When designing class hierarchies, ensure that subclasses extend the behavior of their superclasses without changing their expected behavior.
    * This can involve careful consideration of method signatures, return types, and exception handling.

    Real-time use cases:
    Collections (List<T>, IEnumerable<T>).
    UI controls inheritance (Button, TextBox should behave like Control).
    
    .NET examples:
    Stream classes (FileStream, MemoryStream work as Stream).
    EF Core DbContext subclasses.

    Benefits:
    - Enhances code reliability and predictability.
    - Promotes better design of class hierarchies.
    - Reduces the likelihood of runtime errors due to type mismatches.
    - Encourages the use of polymorphism and interface-based design.

    Other examples:
    - Geometric shapes (Square, Rectangle) where substitutability can be tricky.    
    - Payment processing systems where different payment methods should adhere to a common interface without breaking functionality.
*/

using System;
namespace DesignPatterns.SolidPrinciples;

public abstract class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; protected set; }

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public abstract decimal GetBalance();
}

// Accounts that allow withdrawal
public abstract class WithdrawableAccount : Account
{
    public virtual void Withdraw(decimal amount)
    {
        if (Balance >= amount)
            Balance -= amount;
        else
            throw new InvalidOperationException("Insufficient balance.");
    }
}

// Savings account allows withdraw
public class SavingsAccount : WithdrawableAccount
{
    public override decimal GetBalance() => Balance;
}

// Fixed deposit doesn’t support withdraw, no broken contract
public class FixedDepositAccount : Account
{
    public override decimal GetBalance() => Balance;
}

public static void PrintBalance(Account account)
{
    Console.WriteLine($"{account.AccountNumber} Balance: {account.GetBalance()}");
}

public static void Main()
{
    WithdrawableAccount savings = new SavingsAccount { AccountNumber = "S123" };
    savings.Deposit(1000);
    savings.Withdraw(200);
    PrintBalance(savings);  

    Account fd = new FixedDepositAccount { AccountNumber = "FD456" };
    fd.Deposit(5000);
    PrintBalance(fd);       
}


//======================= Another Example =======================
using System;

public abstract class Bird
{
    public abstract void Fly();
}

public class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow is flying.");
    }
}

public class Ostrich : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Ostriches cannot fly.");
    }
}

public class BirdWatcher
{
    public void Observe(Bird bird)
    {
        bird.Fly();
    }
}   

class Program2
{
    static void Main(string[] args)
    {
        BirdWatcher watcher = new BirdWatcher();

        Bird sparrow = new Sparrow();
        watcher.Observe(sparrow);  

        Bird ostrich = new Ostrich();
        try
        {
            watcher.Observe(ostrich);  
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

// Compliant Example

public interface IMove
{
    void Move();
}

public interface IFly{
    void Fly();
}

public class Sparrow2 : IMove, IFly
{
    public void Move()
    {
        Console.WriteLine("Sparrow is flying.");
    }

    public void Fly()
    {
        Console.WriteLine("Sparrow is soaring through the sky.");
    
    }
}

public class Ostrich2 : IMove
{
    public void Move()
    {
        Console.WriteLine("Ostrich is running.");
    }
}

public class BirdWatcher2
{
    public void Observe(IMove bird)
    {
        bird.Move();
    }
}

class Program3
{
    static void Main(string[] args)
    {
        BirdWatcher2 watcher = new BirdWatcher2();

        IMove sparrow = new Sparrow2();
        watcher.Observe(sparrow);  

        IMove ostrich = new Ostrich2();
        watcher.Observe(ostrich);  
    }
}