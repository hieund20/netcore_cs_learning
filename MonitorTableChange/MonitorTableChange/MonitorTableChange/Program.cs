using Microsoft.EntityFrameworkCore;
using MonitorTableChange.Data;
using MonitorTableChange.Services;

// Microsoft.EntityFrameworkCore.SqlSerser
// Microsoft.EntityFrameworkCore
// Microsoft.EntityFrameworkCore.Tools
// Generate DB: Add-Migration Initial -> Update-Database

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MonitorTableChangeDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MonitorTableChange")));

builder.Services.AddHttpClient();

builder.Services.AddHostedService<MonitorEventBackgroundService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
