using BNI.Models;
using BNI.Models.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BNIContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BNI")));

builder.Services.AddSession();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

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

app.UseSession();

app.Run();
