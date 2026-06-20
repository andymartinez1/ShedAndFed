using Microsoft.EntityFrameworkCore;
using ShedAndFed.Components;
using ShedAndFed.Data;
using ShedAndFed.ServiceContracts;
using ShedAndFed.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ReptileDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IReptileService, ReptileService>();
builder.Services.AddScoped<IFeedingLogService, FeedingLogService>();
builder.Services.AddScoped<IShedLogService, ShedLogService>();
builder.Services.AddScoped<IWasteLogService, WasteLogService>();
builder.Services.AddScoped<IGrowthLogService, GrowthLogService>();
builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ReptileDbContext>();
    try
    {
        db.Database.Migrate();
        var seeder = new SeedDatabase();
        await seeder.SeedDatabaseAsync(db);

        app.Logger.LogInformation("Database migrated and seeded successfully.");
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
