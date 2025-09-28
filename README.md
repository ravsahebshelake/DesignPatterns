# Design Patterns & SOLID Principles

This repository contains comprehensive examples and explanations of various **Design Patterns** and **SOLID Principles** in software development using C#. Design patterns are proven solutions to common problems that arise in software design, while SOLID principles provide guidelines for writing maintainable, scalable, and robust object-oriented code.

## Table of Contents

- [Introduction](#introduction)
- [Design Patterns](#design-patterns)
  - [Creational Patterns](#creational-patterns)
  - [Structural Patterns](#structural-patterns)
  - [Behavioral Patterns](#behavioral-patterns)
- [SOLID Principles](#solid-principles)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Running the Examples](#running-the-examples)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This project demonstrates best practices in software architecture through:

- **Design Patterns**: Reusable solutions to commonly occurring problems in software design
- **SOLID Principles**: Five design principles that make software designs more understandable, flexible, and maintainable

All examples are implemented in C# with clear documentation and practical use cases.

## Design Patterns

### Creational Patterns
These patterns deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.

- **Abstract Factory** - Creates families of related objects without specifying their concrete classes
- **Builder** - Constructs complex objects step by step
- **Factory Method** - Creates objects without specifying the exact class to create
- **Prototype** - Creates objects by cloning an existing instance
- **Singleton** - Ensures a class has only one instance and provides global access to it

### Structural Patterns
These patterns deal with object composition and typically identify simple ways to realize relationships between different objects.

- **Adapter** - Allows incompatible interfaces to work together
- **Decorator** - Adds new functionality to objects without altering their structure
- **Facade** - Provides a simplified interface to a complex subsystem
- **Proxy** - Provides a placeholder or surrogate for another object to control access to it

### Behavioral Patterns
These patterns focus on communication between objects and the assignment of responsibilities between objects.

- **Memento** - Captures and restores an object's internal state without violating encapsulation
- **Observer** - Defines a one-to-many dependency between objects so that when one object changes state, all dependents are notified
- **State** - Allows an object to alter its behavior when its internal state changes
- **Strategy** - Defines a family of algorithms, encapsulates each one, and makes them interchangeable

## SOLID Principles

The SOLID principles are five design principles intended to make software designs more understandable, flexible, and maintainable:

- **S - Single Responsibility Principle (SRP)** - A class should have only one reason to change
- **O - Open/Closed Principle (OCP)** - Software entities should be open for extension but closed for modification
- **L - Liskov Substitution Principle (LSP)** - Objects of a superclass should be replaceable with objects of its subclasses without breaking the application
- **I - Interface Segregation Principle (ISP)** - No client should be forced to depend on methods it does not use
- **D - Dependency Inversion Principle (DIP)** - Depend upon abstractions, not concretions

## Project Structure

```
DesignPatterns/
├── DesignPatterns.sln                    # Solution file
├── README.md                             # This file
└── DesignPatterns/                       # Main project folder
    ├── DesignPatterns.csproj            # Project file
    ├── Program.cs                        # Main entry point
    ├── CreationalDesignPatterns/         # Creational pattern implementations
    │   ├── AbstractFactory.cs           # Abstract Factory pattern
    │   ├── Builder.cs                    # Builder pattern
    │   ├── FactoryMethod.cs             # Factory Method pattern
    │   ├── Prototype.cs                  # Prototype pattern
    │   └── Singleton.cs                  # Singleton pattern
    ├── StructuralDesignPatterns/         # Structural pattern implementations
    │   ├── Adapter.cs                    # Adapter pattern
    │   ├── Decorator.cs                  # Decorator pattern
    │   ├── Facade.cs                     # Facade pattern
    │   └── Proxy.cs                      # Proxy pattern
    ├── BehavioralDesignPatterns/         # Behavioral pattern implementations
    │   ├── Memento.cs                    # Memento pattern
    │   ├── Observer.cs                   # Observer pattern
    │   ├── State.cs                      # State pattern
    │   └── Strategy.cs                   # Strategy pattern
    └── SolidPrinciples/                  # SOLID principles demonstrations
        ├── SingleResponsibilityPrinciple.cs    # SRP with Invoice system example
        ├── OpenClosedPrinciple.cs              # OCP implementation
        ├── LiskovSubstitutionPrinciple.cs      # LSP examples
        ├── InterfaceSegregationPrinciple.cs    # ISP demonstration
        └── DependencyInversionPrinciple.cs     # DIP implementation
```

## Getting Started

### Prerequisites
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- Any C# IDE (Visual Studio, Visual Studio Code, JetBrains Rider, etc.)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/ravsahebshelake/DesignPatterns.git
   ```

2. **Navigate to the project directory:**
   ```bash
   cd DesignPatterns
   ```

3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

4. **Build the project:**
   ```bash
   dotnet build
   ```

## Running the Examples

### Run the entire project:
```bash
dotnet run --project DesignPatterns
```

### Compile and run specific examples:
```bash
# Build the project
dotnet build

# Run the executable
dotnet run --project DesignPatterns/DesignPatterns.csproj
```

### Explore Individual Patterns:
Each `.cs` file contains a complete, runnable example with:
- Clear documentation and comments
- Practical use cases
- Console output demonstrating the pattern in action

## Key Features

- ✅ **Complete Implementation**: All patterns include working code examples
- ✅ **Well Documented**: Each pattern has detailed comments explaining the concepts
- ✅ **Real-world Examples**: Practical scenarios showing when and how to use each pattern
- ✅ **SOLID Principles**: Demonstrates how design patterns align with SOLID principles
- ✅ **Best Practices**: Code follows C# coding conventions and best practices
- ✅ **Educational**: Perfect for learning and teaching software design principles

## Learning Path

### For Beginners:
1. Start with **SOLID Principles** to understand the foundation
2. Move to **Creational Patterns** (especially Singleton and Factory Method)
3. Progress to **Structural Patterns** (Adapter and Decorator)
4. Finish with **Behavioral Patterns** (Observer and Strategy)

### For Intermediate Developers:
- Focus on understanding when NOT to use certain patterns
- Study the trade-offs between different approaches
- Practice refactoring existing code to implement these patterns

## Contributing

We welcome contributions! Here's how you can help:

### Ways to Contribute:
- 🐛 **Bug Reports**: Found an issue? Create a detailed bug report
- 💡 **Feature Requests**: Suggest new patterns or improvements
- 📝 **Documentation**: Improve comments, add examples, or enhance README
- 🔧 **Code Contributions**: Implement new patterns or fix existing ones
- 🎯 **Pattern Suggestions**: Suggest additional design patterns to implement

### Contribution Guidelines:
1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/new-pattern`)
3. **Follow** the existing code style and structure
4. **Add** comprehensive comments and documentation
5. **Include** practical examples and use cases
6. **Test** your implementation thoroughly
7. **Commit** your changes (`git commit -am 'Add new pattern: [PatternName]'`)
8. **Push** to the branch (`git push origin feature/new-pattern`)
9. **Submit** a Pull Request

### Code Standards:
- Follow C# naming conventions
- Include XML documentation comments
- Provide real-world examples
- Ensure code is self-documenting
- Add appropriate console output for demonstrations

## Resources & References

- **Design Patterns**: "Design Patterns: Elements of Reusable Object-Oriented Software" by Gang of Four
- **SOLID Principles**: Robert C. Martin's principles for object-oriented design
- **C# Documentation**: [Microsoft C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- **Best Practices**: [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)

## License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Gang of Four for the foundational design patterns
- Robert C. Martin for SOLID principles
- The C# and .NET community for best practices and conventions

---

**Happy Coding!** 🚀

*"Design patterns should not be applied indiscriminately. Often they achieve flexibility and variability by introducing additional levels of indirection, and that can complicate a design and/or cost you some performance."* - Gang of Four