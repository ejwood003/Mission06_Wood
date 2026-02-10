// Ethan Wood - Section 2
// Program.cs - Application entry point and service configuration

using Mission6_Wood.Models;
using Microsoft.EntityFrameworkCore;

// Build the web application host and load configuration (appsettings.json, environment variables, etc.)
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddControllersWithViews registers MVC with views (Razor) for the dependency injection container
builder.Services.AddControllersWithViews();

// Register the Entity Framework DbContext for SQLite. AddedMovieContext is used to access the Movies table.
// Connection string is read from appsettings.json under ConnectionStrings:MovieConnection
builder.Services.AddDbContext<AddedMovieContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]);
});

// Build the application pipeline
var app = builder.Build();

// Configure the HTTP request pipeline.
// In non-Development environments, use the global exception handler and HSTS for security
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirect HTTP to HTTPS for secure connections
app.UseHttpsRedirection();
// Enable endpoint routing so requests are matched to controller actions
app.UseRouting();
// Enable authorization middleware (used when you add [Authorize] to controllers or actions)
app.UseAuthorization();
// Serve static files (CSS, JS, images) from wwwroot
app.MapStaticAssets();

// Define the default route: {controller}/{action}/{id?} maps to Home/Index by default
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


// Start listening for HTTP requests
app.Run();