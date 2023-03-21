using CustomersApi.Context;
using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CompanyDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("CompanySql");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Obtener todos los empleados
app.MapGet("/api/customers", async (CompanyDbContext db) =>
    await db.Customers.ToListAsync()
)
.Produces<List<Customer>>(StatusCodes.Status200OK)
.WithName("GetCustomers").WithTags("Customers");

app.UseHttpsRedirection();

app.Run();