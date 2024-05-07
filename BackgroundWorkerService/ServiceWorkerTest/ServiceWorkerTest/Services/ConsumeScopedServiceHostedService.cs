
namespace ServiceWorkerTest.Services
{
    public class ConsumeScopedServiceHostedService : BackgroundService
    {
        #region Fields
        public IServiceProvider Services { get; } //Thêm dòng này
        private readonly ILogger<ConsumeScopedServiceHostedService> _logger;
        #endregion

        #region Ctors
        public ConsumeScopedServiceHostedService(IServiceProvider services,
        ILogger<ConsumeScopedServiceHostedService> logger)
        {
            Services = services;
            _logger = logger;
        }
        #endregion

        #region Methods
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service is working.");

            //Sử dụng using, tạo một scope mới từ IServiceProvider
            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedProcessingService>(); //Inject Service cần gọi ở đây

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
        #endregion
    }
}
