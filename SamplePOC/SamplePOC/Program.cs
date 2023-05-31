using Microsoft.Extensions.Configuration;
using SamplePOC.Domain.Interfaces;
using SamplePOC.Infrastructure;
using System.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");




app.Run();
