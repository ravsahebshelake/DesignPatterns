namespace DesignPatterns.CreationalDesignPatterns;

/// <summary>
/// Sealed is used to avoid inheritance of the sigleton class through 
/// which another instance can be created within the same class
/// </summary>
public sealed class Singleton
{
    private static Singleton instance;
    private static readonly object obj = new object();

    /// <summary>
    /// Its a private constructor which restricts access to only within this class
    /// </summary>
    private Singleton() { }

    /// <summary>
    /// Public method to get the instance of singleton class
    /// </summary>
    /// <returns></returns>
    public static Singleton GetInstance()
    {
        lock (obj)
        {
            if(instance == null)
            {
                instance = new Singleton();
            }
        }

        return instance;
    }
}
