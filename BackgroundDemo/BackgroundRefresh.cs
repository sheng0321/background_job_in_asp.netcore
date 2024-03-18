
namespace BackgroundDemo;

public class BackgroundRefresh : IHostedService, IDisposable
{
    private Timer? _timer;
    private readonly SampleData _data;

    public BackgroundRefresh(SampleData data)
    {
        _data = data;   
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(AddToCache,null,TimeSpan.Zero,TimeSpan.FromSeconds(2));
        return Task.CompletedTask;
    }

    private void AddToCache(object? state)
    {
        _data.Data.Add($"The new data was added at {DateTime.Now.ToLongTimeString()}");
       
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }
    public void Dispose()
    {
        _timer?.Dispose();
    }
}
