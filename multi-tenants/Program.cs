using BuildingModels;
using Microsoft.EntityFrameworkCore;
using multi_tenants.DTOs;
using SuperOwnerModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SuperOwnerContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SuperOwner"));
});
builder.Services.AddDbContext<BuildingContext>(option =>
    option.UseSqlServer()
    );
builder.Services.AddAutoMapper(typeof(MyAutoMapper));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
