using Microsoft.EntityFrameworkCore;
using RINHABACKEND.Data;
using RINHABACKEND.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Databasecontext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("connect")));
builder.Services.AddScoped<Service>();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
