using TBC.PersonRegistry.API;
using TBC.PersonRegistry.API.Extensions;
using TBC.PersonRegistry.API.Extensions.Middlewares;
using TBC.PersonRegistry.Application;
using TBC.PersonRegistry.FileService.Implementations;
using TBC.PersonRegistry.Persistence;
using TBC.PersonRegistry.Persistence.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddThisLayer();

builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddPersistenceLayer(builder.Configuration);

builder.Services.AddFileServiceLayer(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MigrateDatabase(); 


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerMiddleware();
}
app.UseMiddleware<LocalizationMiddleware>();

app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
