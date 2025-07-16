using ecommerce.API.MiddleWares;
using ecommerce.Core;
using ecommerce.Core.Mappers;
using ecommerce.InfraStructure;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Call AddInfraStructure services
builder.Services.AddInfraStructure();

// Call AddCore services
builder.Services.AddCore();

// Add Controllers to the service collection
// AddJsonOptions - Because wanted to convert the enmum object or value by default.
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


//this will register all AutoMapper service globally
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);


// register Fluent Validation Services;
builder.Services.AddFluentValidationAutoValidation();


// Add Api explorer services
builder.Services.AddEndpointsApiExplorer();

// Add swagger generation services to create swagger specification
builder.Services.AddSwaggerGen();

//Add CORS services

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(i =>
    {
        i.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

//Build the  Application
var app = builder.Build();

//Custom Exception Handling Middleware
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

// Adds endpoints that can serve the swagger.json
app.UseSwagger();
//Add Swagger UI (interactive page to explore and test the API endpoints)
app.UseSwaggerUI();

//Enable Cores
app.UseCors();

//Auth
app.UseAuthentication();
app.UseAuthorization();


//Controllers routers
app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
