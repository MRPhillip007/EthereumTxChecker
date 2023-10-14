using EthereumTxChecker.Models;
using EthereumTXChecker.BLL.Services.FileManagerService;
using EthereumTXChecker.BLL.Services.RequestManagerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// My Services
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IRequester, Requester>();

// Configs and Secrets init
builder.Services.Configure<FileManagerConfig>(builder.Configuration.GetSection("FileManagerConfig"));
builder.Services.Configure<RequestManagerConfig>(builder.Configuration.GetSection("RequestManager"));

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
