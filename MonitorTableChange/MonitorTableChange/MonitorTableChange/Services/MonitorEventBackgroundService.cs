using Microsoft.EntityFrameworkCore;
using MonitorTableChange.Data;
using Newtonsoft.Json;
using System.Text;

namespace MonitorTableChange.Services
{
    public class MonitorEventBackgroundService : BackgroundService
    {
        #region Fields
        private readonly ILogger<MonitorEventBackgroundService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpClientFactory _httpClientFactory;
        #endregion

        #region Ctor
        public MonitorEventBackgroundService(
            ILogger<MonitorEventBackgroundService> logger, 
            IServiceProvider serviceProvider, 
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _httpClientFactory = httpClientFactory;
        }
        #endregion

        #region Methods
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MonitorTableChangeDBContext>();

                while (!stoppingToken.IsCancellationRequested)
                {
                    // Lắng nghe sự thay đổi trong bảng MonitorEvent
                    var monitorEvent = await dbContext.MonitorEvents
                        .OrderByDescending(e => e.CreateDate)
                        .FirstOrDefaultAsync(stoppingToken);

                    if (monitorEvent != null)
                    {
                        // Gửi thông báo đến API Enpoint thông qua HttpClient
                        await SendNotificationToClients(monitorEvent.TableName);
                    }

                    // Đợi 5 giây trước khi kiểm tra lại
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken); 
                }
            }
        }

        private async Task SendNotificationToClients(string monitorEventTableName)
        {
            // Gửi thông báo đến API endpoint
            var client = _httpClientFactory.CreateClient();
            var apiUrl = "https://39e471098d4446878e9c87565eb9e7ec.api.mockbin.io/";
            
            var jsonBody = new { tableName = monitorEventTableName };
            var content = new StringContent(JsonConvert.SerializeObject(jsonBody), Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync(apiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to send notification to API endpoint. Status code: {response.StatusCode}");
            }
        }
        #endregion
    }
}
