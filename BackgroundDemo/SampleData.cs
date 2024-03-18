using System.Collections.Concurrent;

namespace BackgroundDemo;

public class SampleData
{
    public ConcurrentBag<string> Data { get; set; } = [];

}
