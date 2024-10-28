using Microsoft.EntityFrameworkCore;
using fbwa_web.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FBWAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FBWA_Database")));

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
