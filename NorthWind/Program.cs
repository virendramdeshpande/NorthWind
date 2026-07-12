using Customer.QueryHandlers;
using Customers.Contracts;
using Microsoft.EntityFrameworkCore;
using NorthWind;
using Ropositories.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPooledDbContextFactory<NorthwindContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));





// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(NorthwindContext).Assembly,
    typeof(EmployeeQuery).Assembly,
     typeof(EmployeeQueryHandle).Assembly,
        typeof(NorthwindContext).Assembly,
        typeof(Result<>).Assembly
        ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
