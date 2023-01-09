using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Abstract;
using Repository.Context;
using Service;
using Service.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IIsPrimeNumberRepository, IsPrimeNumberRepository>();
builder.Services.AddScoped<IIsPrimeNumberService, IsPrimeNumberService>();

// Add connection to databases
builder.Services.AddDbContext<DataContext>(options =>
{
    // Local connection
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PrimeNumbersProject"));
});

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
