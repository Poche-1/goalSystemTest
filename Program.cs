using webapi;
using webapi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventoryContext>(options =>
{
    var connectionString =  builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connectionString);

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<IMainService>(p => new MainService());
builder.Services.AddScoped<ICategorieService, CategorieService>();
builder.Services.AddScoped<IInputService, InputService>();
builder.Services.AddScoped<IOutputService, OutputService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAutenticationMiddleware();

app.MapControllers();

app.Run();
