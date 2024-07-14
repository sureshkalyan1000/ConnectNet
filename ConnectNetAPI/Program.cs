using ConnectNet.Entities;
using ConnectNet.Extensions;
using ConnectNet.middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.addIdentityServices(builder.Configuration);
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
//try
//{
//    var context = service.GetRequiredService<DataContext>();
//    await context.Database.MigrateAsync();
//    await Seed.SeedUser(context);
//}
//catch (Exception ex)
//{
//    var logger = service.GetRequiredService<ILogger<Program>>();
//    logger.LogError(ex, "An Error Occured During The Migration");
//}

app.Run();
