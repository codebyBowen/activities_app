using Microsoft.EntityFrameworkCore;
using Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// goes to the config and find connect string called DefaultConnection
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// provide routine -> know goes to the controller
app.MapControllers();
// service locator pattern
// it will be cleaned up or disposed the unused resources via garbage collector when they are out of the scope?
using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<AppDbContext>();
    // if not DB not exist then create DB
    await context.Database.MigrateAsync();
    // its a static data so do not need to create Instance of the Db Intializer
    await Dbinitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration.");  
    throw;
}
app.Run();
