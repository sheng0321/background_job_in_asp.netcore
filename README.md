# background_job_in_asp.netcore
how to add a background job to the Asp.net core project.  
This code is based on [TimCorey YouTube video](https://www.youtube.com/watch?v=ip3Z4ZcAgA8).
In this example code, there is a special data ConcurrentDataBag.The following code is an example:
```C#
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

class ConcurrentBagDemo
{
    static void Main()
    {
        ConcurrentBag<int> cb = new ConcurrentBag<int>();

        // Add to ConcurrentBag concurrently
        List<Task> bagAddTasks = new List<Task>();
        for (int i = 0; i < 500; i++)
        {
            var numberToAdd = i;
            bagAddTasks.Add(Task.Run(() => cb.Add(numberToAdd)));
        }
        Task.WaitAll(bagAddTasks.ToArray());

        // Consume the items in the bag
        List<Task> bagConsumeTasks = new List<Task>();
        int itemsInBag = 0;
        while (!cb.IsEmpty)
        {
            bagConsumeTasks.Add(Task.Run(() =>
            {
                int item;
                if (cb.TryTake(out item))
                {
                    Console.WriteLine(item);
                    Interlocked.Increment(ref itemsInBag);
                }
            }));
        }
        Task.WaitAll(bagConsumeTasks.ToArray());

        Console.WriteLine($"There were {itemsInBag} items in the bag");
    }
}


```

