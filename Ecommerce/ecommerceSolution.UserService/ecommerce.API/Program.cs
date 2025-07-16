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

//Build the  Application
var app = builder.Build();

//Custom Exception Handling Middleware
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();


//Controllers routers
app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
