
using AuctionApplication.Interfaces;
using AuctionApplication.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();

builder.Services.AddScoped<IAuctionService, AuctionService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();



app.MapControllers();

app.Run();

public partial class Program { }
