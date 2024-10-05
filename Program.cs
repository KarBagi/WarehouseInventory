using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WarehouseInventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseInventoryContext") ?? throw new InvalidOperationException("Connection string 'WarehouseInventoryContext' not found.")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.2",
        Title = "Warehouse Inventory API",
        Description = "",
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WarehouseInventory v1.2");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();