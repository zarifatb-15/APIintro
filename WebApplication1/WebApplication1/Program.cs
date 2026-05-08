using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);
var config=builder.Configuration;

// Add services to the container.

builder.Services.AddServices(config);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
// SWAGGER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();

app.Run();