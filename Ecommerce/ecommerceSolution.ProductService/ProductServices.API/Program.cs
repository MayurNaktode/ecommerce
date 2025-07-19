using BusinessLogicLayer;
using DataAccessLayer;
using FluentValidation.AspNetCore;
using ProductServices.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add DAL AND BAL Services
builder.Services.AddDataAccesslayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();

builder.Services.AddControllers();

// Fluent Validations
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
