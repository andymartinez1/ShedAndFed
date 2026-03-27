using Microsoft.EntityFrameworkCore;
using ShedAndFed.Components;
using ShedAndFed.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ReptileDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Initialize and seed the database
using (var scope = app.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // await SeedData.InitializeDataAsync(services);
        app.Logger.LogInformation("Seeding database succeeded.");
    }
    catch (Exception e)
    {
        app.Logger.LogError(e, "An error occured while seeding the database.");
        throw;
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
