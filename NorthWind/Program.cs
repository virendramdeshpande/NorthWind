using Customer.QueryHandlers;
using Customers.Contracts;
using Microsoft.EntityFrameworkCore;
using NorthWind;
using Ropositories.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPooledDbContextFactory<NorthwindContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// 2. Register native .NET OpenAPI support
builder.Services.AddOpenApi();

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
// 3. Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Generates the OpenAPI JSON schema at /openapi/v1.json
    app.MapOpenApi();

    // Renders the modern, interactive Scalar documentation UI
    app.MapScalarApiReference();
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
