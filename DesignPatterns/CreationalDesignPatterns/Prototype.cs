/* Prototype Pattern
Definition:
Creates new objects by cloning existing ones, instead of creating from scratch.

Problem it solves:
Avoids costly object creation when instantiating from scratch is expensive.
Helps maintain object structure and configuration.

Real-time use cases: 
Cloning user profiles/settings.
Duplicating documents/templates.
When object initialization is expensive (like parsing large data).

.NET examples
ICloneable interface.
Object.MemberwiseClone() method.
*/

using System;
namespace DesignPatterns.CreationalDesignPatterns;

public class Configuration : ICloneable
{
    public string SomeSetting { get; set; }
    public int AnotherSetting { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"SomeSetting: {SettingA}, AnotherSetting: {SettingB}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Configuration originalConfig = new Configuration
        {
            SomeSetting = "Original",
            AnotherSetting = 42
        };

        Configuration clonedConfig = (Configuration)originalConfig.Clone();
        clonedConfig.SomeSetting = "Cloned";

        Console.WriteLine("Original Config: " + originalConfig);
        Console.WriteLine("Cloned Config: " + clonedConfig);
    }
}

