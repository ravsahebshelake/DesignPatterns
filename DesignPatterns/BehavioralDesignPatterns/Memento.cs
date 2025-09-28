/* Memento Design Pattern
Definition:
Captures and externalizes an object's internal state so that the object can be restored to this state later, without violating encapsulation.

Problem it solves:
Allows for easy state restoration without exposing the internal structure of the object.

Real-time use cases:
Undo mechanisms in text editors.
Game development for saving and restoring game states.

.NET examples:
System.Windows.Input.StylusPointCollection uses Memento for storing and restoring stylus points.
Entity Framework's Change Tracker can be seen as a Memento, keeping track of changes to entities.
*/

using System;
using System.Collections.Generic;

namespace DesignPatterns.BehavioralDesignPatterns
{
    public class Memento
    {
        public string State { get; }

        public Memento(string state)
        {
            State = state;
        }
    }

    public class Originator
    {
        private string _state;

        public void SetState(string state)
        {
            _state = state;
            Console.WriteLine($"Originator: Setting state to {state}");
        }

        public Memento SaveStateToMemento()
        {
            Console.WriteLine("Originator: Saving to Memento.");
            return new Memento(_state);
        }

        public void RestoreStateFromMemento(Memento memento)
        {
            _state = memento.State;
            Console.WriteLine($"Originator: State after restoring from Memento: {_state}");
        }
    }

    public class Caretaker
    {
        private readonly List<Memento> _mementoList = new List<Memento>();

        public void AddMemento(Memento memento)
        {
            _mementoList.Add(memento);
        }

        public Memento GetMemento(int index)
        {
            return _mementoList[index];
        }
    }

    class MementoProgram
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();

            originator.SetState("State1");
            originator.SetState("State2");
            caretaker.AddMemento(originator.SaveStateToMemento());

            originator.SetState("State3");
            caretaker.AddMemento(originator.SaveStateToMemento());

            originator.SetState("State4");

            originator.RestoreStateFromMemento(caretaker.GetMemento(0));
            originator.RestoreStateFromMemento(caretaker.GetMemento(1));
        }
    }
}
//======================= Another Example =======================

using System;
using System.Collections.Generic;

namespace DesignPatterns.BehavioralDesignPatterns;

public class TextEditor
{
    private string _content;

    public void Type(string words)
    {
        _content += words;
    }

    public string GetContent()
    {
        return _content;
    }

    public Memento Save()
    {
        return new Memento(_content);
    }

    public void Restore(Memento memento)
    {
        _content = memento.State;
    }
}

public class Memento
{
    public string State { get; }

    public Memento(string state)
    {
        State = state;
    }
}

public class History
{
    private readonly Stack<Memento> _mementos = new Stack<Memento>();

    public void Push(Memento memento)
    {
        _mementos.Push(memento);
    }

    public Memento Pop()
    {
        return _mementos.Pop();
    }
}

class TextEditorProgram
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        History history = new History();

        editor.Type("Hello, ");
        history.Push(editor.Save());

        editor.Type("world!");
        history.Push(editor.Save());
        
        editor.Type("!");
        history.Push(editor.Save());

        Console.WriteLine("Current content: " + editor.GetContent());

        editor.Restore(history.Pop());
        Console.WriteLine("Restored content: " + editor.GetContent());

        editor.Restore(history.Pop());
        Console.WriteLine("Restored content: " + editor.GetContent());
    }
}