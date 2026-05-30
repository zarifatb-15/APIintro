using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using WebApplication1;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);
var config=builder.Configuration;

// Add services to the container.

builder.Services.AddServices(config);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

// Configure the HTTP request pipeline.
// SWAGGER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Scalar
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
//     app.MapScalarApiReference();
// }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();