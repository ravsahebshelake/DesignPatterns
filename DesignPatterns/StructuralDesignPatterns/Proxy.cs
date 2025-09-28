/* Proxy Design Pattern
 Proxy pattern provides a surrogate or placeholder for another object to control access to it.
 
 Common use cases:
 - Lazy initialization: Delay the creation of an expensive object until it's actually needed.
 - Access control: Control access to the original object, e.g., for authentication or logging.
 - Remote proxy: Represent a remote object locally, handling communication details.
 
 .NET examples:
 - VirtualProxy: Lazy loading of images in UI frameworks.
 - RemoteProxy: WCF (Windows Communication Foundation) proxies for remote services.
 - ProtectionProxy: File system access control using FileStream with specific permissions.
 
 Other examples:
 - CachingProxy: Cache results of expensive operations to improve performance.
 - SmartReference: Manage reference counting for shared resources.
*/

using System;
namespace DesignPatterns.StructuralDesignPatterns;

public interface ICache
{
    string GetData(string key);
}

public class RealCache : ICache
{
    public string GetData(string key)
    {
        // Simulate fetching data from a slow source
        Console.WriteLine($"Fetching data for {key} from the real cache.");
        return $"Data for {key}";
    }
}

public class CacheProxy : ICache
{
    private RealCache _realCache;
    private Dictionary<string, string> _cache = new Dictionary<string, string>();

    public string GetData(string key)
    {
        if (_cache.ContainsKey(key))
        {
            Console.WriteLine($"Fetching data for {key} from the proxy cache.");
            return _cache[key];
        }

        _realCache ??= new RealCache();
        var data = _realCache.GetData(key);
        _cache[key] = data;
        return data;
    }
}
class Program
{
    static void Main(string[] args)
    {
        ICache cache = new CacheProxy();

        // First access, data will be fetched from the real cache
        Console.WriteLine(cache.GetData("item1"));

        // Second access, data will be fetched from the proxy cache
        Console.WriteLine(cache.GetData("item1"));
    }
}


//======================= Another Example =======================

public interface IImageService
{
    void DisplayImage(string imagePath);
}

public class RealImageService : IImageService
{
    private readonly string _imagePath;

    public RealImageService(string imagePath = "")
    {
        _imagePath = imagePath;
    }

    public void DisplayImage()
    {
        Console.WriteLine($"Displaying image from {_imagePath}");
    }
}

public class ImageServiceProxy : IImageService
{
    private readonly IImageService _realImageService;

    public ImageServiceProxy(IImageService realImageService)
    {
        _realImageService = realImageService;
    }

    public void DisplayImage()
    {
        _realImageService.DisplayImage();
    }
}

class ProxyProgram
{
    static void Main(string[] args)
    {
        IImageService realImageService = new RealImageService("path/to/image.jpg");
        IImageService proxy = new ImageServiceProxy(realImageService);

        // Image will be loaded and displayed via the proxy
        proxy.DisplayImage();
    }
}