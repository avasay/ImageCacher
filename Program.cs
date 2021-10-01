using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddMemoryCache())
    .Build();

IMemoryCache cache = host.Services.GetRequiredService<IMemoryCache>();

string image1 = Environment.CurrentDirectory + @"\Images\abstract\" + "timur-kozmenko-GS84KG8yNDo-unsplash.jpg";
string image2 = Environment.CurrentDirectory + @"\Images\abstract\" + "timur-kozmenko-VJj70LBdrnM-unsplash.jpg";
string image3 = Environment.CurrentDirectory + @"\Images\abstract\" + "timur-kozmenko-zxVdi0iEO7M-unsplash.jpg";

ImageCacherConsoleApp.ImageCacher image1Cacher = new ImageCacherConsoleApp.ImageCacher(cache, image1);
ImageCacherConsoleApp.ImageCacher image2Cacher = new ImageCacherConsoleApp.ImageCacher(cache, image2);
ImageCacherConsoleApp.ImageCacher image3Cacher = new ImageCacherConsoleApp.ImageCacher(cache, image3);

// First Pass

Console.WriteLine(image1Cacher.GetImage());

Console.WriteLine(image2Cacher.GetImage());

Console.WriteLine(image2Cacher.GetImage());

// Second Pass

Console.WriteLine(image1Cacher.GetImage());

Console.WriteLine(image2Cacher.GetImage());

Console.WriteLine(image3Cacher.GetImage());