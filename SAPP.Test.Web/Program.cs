using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SAPP.Test.Domain.Repositories;
using SAPP.Test.Persistance.Repositories;
using SAPP.Test.Presentation.Controllers;
using SAPP.Test.Services;
using SAPP.Test.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(TestParentController).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();

builder.Services.AddDbContext<RepositoryDbContext>(dbBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");

    dbBuilder.UseSqlServer(connectionString);

});
var mapConfig = new MapperConfiguration(mc =>
  mc.AddProfile(new MapperProfile())
);

IMapper mapper=mapConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

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
