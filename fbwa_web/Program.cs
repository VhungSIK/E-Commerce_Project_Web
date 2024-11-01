using Microsoft.EntityFrameworkCore;
using fbwa_web.Data;
using Microsoft.AspNetCore.Identity;
using fbwa_web.Models;

var builder = WebApplication.CreateBuilder(args);

// ??ng ký DB Context
builder.Services.AddDbContext<FBWAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FBWA_Database")));

// ??ng ký d?ch v? IPasswordHasher cho User
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Thêm các d?ch v? cho container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
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
