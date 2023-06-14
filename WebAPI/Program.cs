using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CompanyAPI.Data;
using AutoMapper;
using CompanyAPI.Service.Interfaces;
using CompanyAPI.Service;
using CompanyAPI.Repositories.Interfaces;
using CompanyAPI.Repositories;
using CompanyAPI.WebAPI.Models.Profiles;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CompanyAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyAPIContext") ?? throw new InvalidOperationException("Connection string 'CompanyAPIContext' not found.")));

//Used In Memory Database for testing
/*builder.Services.AddDbContext<CompanyAPIContext>(options => options.UseInMemoryDatabase(databaseName: "CompanyAPIContext"));*/

// Add services to the container.

builder.Services.AddControllers();
//Add auto mapper to the container
builder.Services.AddAutoMapper(typeof(MapperProfiles));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
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
