
using System.Threading;

public class BackgroundWorkerService : BackgroundService
{
    #region Fields
    readonly ILogger<BackgroundWorkerService> _logger;
    #endregion 

    #region Ctor
    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger)
    {
        _logger = logger;
    }
    #endregion

    #region Methods
    //StartAsync và StopAsync là hai phương thức được implement từ Interface
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service started");

        while (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            Task.Delay(1000, cancellationToken).Wait();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service stopped");
        return Task.CompletedTask;
    }

    //Khi run project, hàm này được chạy đầu tiên
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //Kiểm tra xem token dừng (stoppingToken) có được yêu cầu hủy bỏ không.
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //Worker chờ 1 giây trước khi kiểm tra lại token dừng
            await Task.Delay(1000, stoppingToken);
        }
    }
    #endregion
}