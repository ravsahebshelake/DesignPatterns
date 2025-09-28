/* State Design Pattern
Definition: 
Allows an object to alter its behavior when its internal state changes. The object will appear to change
its class.

Problem it solves:
Encapsulates state-specific behavior and transitions, avoiding large conditional statements.

Real-time use cases:
Managing state in UI components (e.g., buttons, forms).
Workflow engines where the process can be in different states (e.g., draft, review, approved).

.NET examples:
HttpContext in ASP.NET Core manages request state.
WPF's VisualStateManager manages visual states of controls.
*/

using System;
namespace DesignPatterns.BehavioralDesignPatterns;

public interface IState
{
    void Handle(OrderContext context);
}

public class PendingState : IState
{
    public void Handle(OrderContext context)
    {
        Console.WriteLine("Order is in Pending state. Moving to Processing state.");
        context.SetState(new ProcessingState());
    }
}

public class ProcessingState : IState
{
    public void Handle(OrderContext context)
    {
        Console.WriteLine("Order is in Processing state. Moving to Shipped state.");
        context.SetState(new ShippedState());
    }
}

public class ShippedState : IState
{
    public void Handle(OrderContext context)
    {
        Console.WriteLine("Order is in Shipped state. Moving to Delivered state.");
        context.SetState(new DeliveredState());
    }
}

public class DeliveredState : IState
{
    public void Handle(OrderContext context)
    {
        Console.WriteLine("Order is in Delivered state. No further transitions.");
    }
}

public class OrderContext
{
    private IState _state;

    public OrderContext(IState state)
    {
        _state = state;
    }

    public void SetState(IState state)
    {
        _state = state;
    }

    public void Request()
    {
        _state.Handle(this);
    }
}

class StateProgram
{
    static void Main(string[] args)
    {
        OrderContext context = new OrderContext(new PendingState());

        context.Request(); // Pending -> Processing
        context.Request(); // Processing -> Shipped
        context.Request(); // Shipped -> Delivered
        context.Request(); // Delivered -> No further transitions
    }
}
