using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("===== SYNCHRONOUS =====");
        RunSynchronous();

        Console.WriteLine("\n===== ASYNCHRONOUS =====");
        await RunAsynchronous();
    }

    // Synchronous
    static void RunSynchronous()
    {
        Stopwatch sw = Stopwatch.StartNew();

        GetData1();
        GetData2();
        GetData3();

        sw.Stop();
        Console.WriteLine($"Time (Sync): {sw.ElapsedMilliseconds} ms");
    }

    static void GetData1()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Data1 Loaded");
    }

    static void GetData2()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Data2 Loaded");
    }

    static void GetData3()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Data3 Loaded");
    }

    // Asynchronous
    static async Task RunAsynchronous()
    {
        Stopwatch sw = Stopwatch.StartNew();

        Task t1 = GetDataAsync("Data1");
        Task t2 = GetDataAsync("Data2");
        Task t3 = GetDataAsync("Data3");

        await Task.WhenAll(t1, t2, t3);

        sw.Stop();
        Console.WriteLine($"Time (Async): {sw.ElapsedMilliseconds} ms");
    }

    static async Task GetDataAsync(string name)
    {
        await Task.Delay(2000);
        Console.WriteLine($"{name} Loaded");
    }
}
