using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WarehouseInventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseInventoryContext") ?? throw new InvalidOperationException("Connection string 'WarehouseInventoryContext' not found.")));

// Dodaj usługi kontrolerów do kontenera
builder.Services.AddControllers();

// Dodaj usługę Swaggera do kontenera
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "My API",
        Description = "Opis mojej API",
    });
});

var app = builder.Build();

// Konfiguracja Swaggera i interfejsu Swagger UI tylko w środowiskach deweloperskich
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
    });
}

app.UseHttpsRedirection();

// Dodaj mapowanie kontrolerów
app.MapControllers();

app.Run();