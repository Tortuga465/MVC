using MVC.databaseClasses;
using MVC.Reps;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IWForecastRepo, WForecastRepo>();    
builder.Services.AddRazorPages();
builder.Services.AddDbContext<applicationDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("localDb")
    ));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHostedService<BackgroundWorkerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Weather}/{action=CitySearch}/{id?}");

app.Run();
