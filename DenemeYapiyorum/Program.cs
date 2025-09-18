using DenemeYapiyorum.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 🔹 DbBaglantisi'yi DI container'a ekliyoruz
builder.Services.AddDbContext<DbBaglantisi>(options =>
    options.UseSqlServer("Server=DESKTOP-657V3F7\\SQLEXPRESS03;Database=DenemeDbsi;Integrated Security=True;TrustServerCertificate=True;"));

var app = builder.Build();

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
