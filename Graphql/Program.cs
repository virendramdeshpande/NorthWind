using Graphql;
using Microsoft.EntityFrameworkCore;
using Ropositories.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


builder.Services.AddPooledDbContextFactory<NorthwindContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
      .AddProjections() // Ensure this is registered
    .AddFiltering()
    .AddSorting();
var app = builder.Build();
app.MapGraphQL();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
