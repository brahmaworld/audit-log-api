using AuditApp.Emp.Service.IServices;
using AuditApp.Emp.Service.Services;
using AuditApp.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using AuditApp.Log.Service.Interfaces;
using AuditApp.Log.Service.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add CORS policy to allow requests from any origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Register DbContext
builder.Services.AddDbContext<EmpAuditPgsqlDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString"));
});

// Register application services with lifetimes
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
