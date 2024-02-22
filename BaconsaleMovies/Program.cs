using BaconsaleMovies.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adding Sqlite Connection
builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:JoelHilton"]);
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
