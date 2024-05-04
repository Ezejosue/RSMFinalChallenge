using System.Reflection;
using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Infraestructure;
using FinallChallenge.Infraestructure.Repositories;
using FinallChallenge.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{


    c.SwaggerDoc("v1", new OpenApiInfo
    {


        Title = "RSMFinalChallengeAPI",
        Version = "v1",
        Description = "This is an API developed to solve the final challenge of RSM.",
        Contact = new OpenApiContact
        {
            Name = "API Support",
            Email = "support@api.com",
            Url = new Uri("https://api.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Use under MIT license",
            Url = new Uri("https://api.com/license")
        }



    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddDbContext<AdvWorksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        opt => opt.MigrationsAssembly(typeof(AdvWorksDbContext).Assembly.FullName));
});

/* This code snippet is configuring CORS (Cross-Origin Resource Sharing) in an ASP.NET Core
application. */
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


/* These lines of code are registering dependencies in the dependency injection container of the
ASP.NET Core application. */
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
