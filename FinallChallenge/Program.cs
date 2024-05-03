using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Infraestructure;
using FinallChallenge.Infraestructure.Repositories;
using FinallChallenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AdvWorksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        opt => opt.MigrationsAssembly(typeof(AdvWorksDbContext).Assembly.FullName));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


builder.Services.AddTransient<ISaleRepository, SaleRepository>();
builder.Services.AddTransient<ISaleService, SaleReportService>();
builder.Services.AddTransient<ISaleByEmployeeRepository, SaleByEmployeeRepository>();
builder.Services.AddTransient<ISaleByEmployeeService, SaleByEmployeeService>();
builder.Services.AddTransient<IProductCateRepository, ProductCateRepository>();
builder.Services.AddTransient<IProductCateService, ProductCateService>();
builder.Services.AddTransient<ISaleTerritoryRepository, SaleTerritoryRepository>();
builder.Services.AddTransient<ISaleTerritoryService, SaleTerritoryService>();

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

app.UseCors();

app.Run();
