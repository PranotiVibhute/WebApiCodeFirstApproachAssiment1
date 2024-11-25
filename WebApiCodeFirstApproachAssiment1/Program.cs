using Microsoft.EntityFrameworkCore;
using WebApiCodeFirstApproachAssiment1.Context;
using WebApiCodeFirstApproachAssiment1.Interface;
using WebApiCodeFirstApproachAssiment1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddScoped<IOrderHistory,OrderHistoryServices>();

builder.Services.AddDbContext<CustomerDbContext>(db => db.UseSqlServer
(builder.Configuration.GetConnectionString("EcommerceDBLocalConnection")), ServiceLifetime.Singleton);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
