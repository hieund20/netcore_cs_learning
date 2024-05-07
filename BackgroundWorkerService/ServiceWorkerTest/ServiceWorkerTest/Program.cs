using ServiceWorkerTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Cấu hình một BackgroundWorkerService đơn giản - Thêm dòng này
builder.Services.AddHostedService<BackgroundWorkerService>();

//Consuming a scoped service in a background task (Sử dụng Service bên trong một BackgroundWorkerService)
builder.Services.AddHostedService<ConsumeScopedServiceHostedService>();

//Thêm service vào Scoped
builder.Services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
