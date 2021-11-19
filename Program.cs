using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddMemoryCache())
    .Build();

IMemoryCache cache = host.Services.GetRequiredService<IMemoryCache>();

string image1 = Environment.CurrentDirectory + @"\Images\abstract\" + "timur-kozmenko-GS84KG8yNDo-unsplash.jpg";
string image2 = Environment.CurrentDirectory + @"\Images\abstract\" + "timur-kozmenko-VJj70LBdrnM-unsplash.jpg";
string image3 = Environment.CurrentDirectory + @"\Images\abstract\" + "timur-kozmenko-zxVdi0iEO7M-unsplash.jpg";

ImageCacherConsoleApp.ImageCacher imageCacher = new ImageCacherConsoleApp.ImageCacher(cache);

try
{
    // 1st Pass
    Console.WriteLine(imageCacher.GetImage(image1));
    Console.WriteLine(imageCacher.GetImage(image2));
    Console.WriteLine(imageCacher.GetImage(image3));

    // 2nd Pass
    Console.WriteLine(imageCacher.GetImage(image1));
    Console.WriteLine(imageCacher.GetImage(image2));
    Console.WriteLine(imageCacher.GetImage(image3));
}
catch (Exception ex)
{
    // Do something
}